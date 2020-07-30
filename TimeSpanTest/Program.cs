using System;

namespace TimeSpanTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(TimeSpan.FromSeconds(2).TotalMilliseconds);
            Console.WriteLine("Hello World!");
        }
    }
}