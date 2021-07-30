using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Serilog;
using System.IO;

namespace LoggingTest
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; private set; }

        public static void Main(string[] args)
        {
            //Log.Logger = new LoggerConfiguration()
            //.Enrich.FromLogContext()
            //.WriteTo.Console()
            //.CreateLogger();

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
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                        .AddEnvironmentVariables();
                    Configuration = config.Build();
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
                    services.AddScoped<IClass1, Class1>();
                    services.AddScoped<IClass2, Class2>();

                    services.AddScoped<Service1>();
                    services.AddSingleton<Service2>();

                    var myKey = Configuration["MyKey"];
                    services.AddSingleton<IService3>(sp => new Service3(myKey));

                    //services.AddHostedService<Worker>();
                })
                //.UseSerilog()
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging
                        .AddConsole();
                    //.AddSerilog();
                })
            ;
    }
}