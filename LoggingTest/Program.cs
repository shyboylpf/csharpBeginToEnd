using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

public class Program
{
    public static IConfigurationRoot Configuration { get; private set; }

    public static void Main(string[] args)
    {
        BuildConfig(new ConfigurationBuilder());

        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
            {
                logging
                    .SetMinimumLevel(LogLevel.Information)
                    .AddConsole();
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
            });

    public static void BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables();

        Configuration = builder.Build();
    }
}