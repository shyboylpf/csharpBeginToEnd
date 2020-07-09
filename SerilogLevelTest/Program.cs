using System;
using Serilog;

namespace SerilogLevelTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            // 从上到下, 日志等级递增
            Log.Verbose("Verbose");
            Log.Debug("debug");
            Log.Information("Information");
            Log.Error("Error");
            Log.Fatal("Fatal");

            Console.WriteLine("Hello World!");
        }
    }
}