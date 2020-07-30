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

            Log.Information("Processed {@Position} in {@Elapsed} ms.", new { a = 1, b = 2 }, 3);

            Log.Information("{@a}", new { b = 3 });

            try
            {
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "错误提示");
            }
        }
    }
}