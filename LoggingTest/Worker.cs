using LoggingTest;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

internal class Worker : IHostedService
{
    private ILogger _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Worker.StartAsync");
        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(1000, cancellationToken);
                _logger.LogInformation("Worker.Running");
            }
        }
        catch (OperationCanceledException ex)
        {
            if (ex.CancellationToken == cancellationToken)
            {
                _logger.LogWarning("Worker cannceled");
            }
        }
        //return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Worker.StopAsync");
        return Task.CompletedTask;
    }

    //protected override Task ExecuteAsync(CancellationToken stoppingToken)
    //{
    //    _logger.LogInformation("11111111111from ExecuteAsync");
    //    //try
    //    //{
    //    //    while (!stoppingToken.IsCancellationRequested)
    //    //    {
    //    //        Thread.SpinWait(10500000);
    //    //        _logger.LogInformation("11111111111for execute");
    //    //    }
    //    //}
    //    //catch (OperationCanceledException ex)
    //    //{
    //    //    if (ex.CancellationToken == stoppingToken)
    //    //    {
    //    //        _logger.LogWarning("cancel from ctrl c");
    //    //    }
    //    //}
    //    //catch (AggregateException ae)
    //    //{
    //    //    _logger.LogWarning("AggregateException caught: " + ae.InnerException);
    //    //    foreach (var inner in ae.InnerExceptions)
    //    //    {
    //    //        _logger.LogWarning(inner.Message + inner.Source);
    //    //    }
    //    //}
    //    return Task.CompletedTask;
    //}
}