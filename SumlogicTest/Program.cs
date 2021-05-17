using Serilog;
using Serilog.Sinks.SumoLogic;
using System;

Console.WriteLine("1");

var log = new LoggerConfiguration()
    .WriteTo
    .SumoLogic("YOUR_SUMOLOGIC_TOKEN", "SOURCE_NAME")
    .CreateLogger();

log.Debug("test debug log from console");
log.Information("test info log from console");
log.Error("test error log from console");
log.Warning("test warning log from console");
log.Fatal("test fatal log from console");
Log.CloseAndFlush();