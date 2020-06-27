using System;
using System.Collections.Generic;

namespace Hello
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var generator = new FibonacciGenerator();
            foreach (var digit in generator.Generate(20))
            {
                Console.WriteLine(digit);
            }
        }
    }
}