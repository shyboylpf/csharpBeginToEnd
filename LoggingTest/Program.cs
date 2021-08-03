using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Serilog;
using System.IO;
using Serilog.Sinks.SumoLogic;

namespace LoggingTest
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; private set; }

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var myDependency = services.GetRequiredService<IClass2>();
                    myDependency.Run();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-5.0#environmentname
                // Framework-defined values include Development, Staging, and Production. Values aren't case-sensitive.
                // you can also add by environment provider with prefix DOTNET_ENVIRONMENT - console app, ASPNETCORE_ENVIRONMENT - asp.net app.
                //.UseEnvironment("Development")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                        .AddEnvironmentVariables();
                    //Configuration = config.Build();
                })
                //.ConfigureContainer<Worker>((hostingContext, container) =>
                //{
                //})
                //.ConfigureHostConfiguration(config =>
                //{
                //    config.Build();
                //})
                .ConfigureServices((hostContext, services) =>
                {
                    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-5.0#app-configuration
                    // The configuration created by ConfigureAppConfiguration is available at HostBuilderContext.Configuration for subsequent operations and as a service from DI. The host configuration is also added to the app configuration.
                    // hostContext.Configuration == Configuration

                    // https://docs.microsoft.com/en-us/dotnet/core/extensions/options#bind-hierarchical-configuration
                    /// When using the options pattern, an options class:
                    /// Must be non-abstract with a public parameterless constructor
                    /// Contain public read-write properties to bind(fields are not bound)
                    TransientFaultHandlingOptions options = new();
                    hostContext.Configuration.GetSection(nameof(TransientFaultHandlingOptions)).Bind(options);
                    Console.WriteLine($"TransientFaultHandlingOptions.Enabled={options.Enabled}");
                    Console.WriteLine($"TransientFaultHandlingOptions.AutoRetryDelay={options.AutoRetryDelay}");

                    // add configure into DI
                    services.Configure<TransientFaultHandlingOptions>(hostContext.Configuration.GetSection(key: nameof(TransientFaultHandlingOptions)));

                    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-5.0#shutdowntimeout
                    //  <PREFIX_>SHUTDOWNTIMEOUTSECONDS
                    services.Configure<HostOptions>(option =>
                    {
                        option.ShutdownTimeout = System.TimeSpan.FromSeconds(20);   // delay 20s to shut down application, leave some time for services to stop.
                    });

                    services.AddTransient<IClass1, Class1>();
                    services.AddScoped<IClass2, Class2>();

                    services.AddScoped<Service1>();
                    services.AddSingleton<Service2>();

                    var myKey = hostContext.Configuration["MyKey"];
                    services.AddSingleton<IService3>(sp => new Service3(myKey));

                    services.AddHostedService<LifetimeEventsHostedService>();
                    services.AddHostedService<Worker>();
                })
                .UseSerilog((hostContext, config) =>
                {
                    config.Enrich.FromLogContext()
                        //.Enrich.WithProperty("IPAddress", hostContext. .RemoteIpAddress)
                        .WriteTo.Console()
                        .WriteTo.SumoLogic("https://endpoint1.collection.us2.sumologic.com/receiver/v1/example", "xGlobalETF-Pusher");
                })
            //.ConfigureLogging((hostingContext, logging) =>
            //{
            //    logging
            //        .AddConsole();
            //})
            ;
    }
}