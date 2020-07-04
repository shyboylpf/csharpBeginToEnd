using System;
using System.Collections.Concurrent;

namespace ConcurrentDictionaryTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConcurrentDictionary<int, int> concurrentDictionary = new ConcurrentDictionary<int, int>();

            concurrentDictionary.GetOrAdd(1, 1);
            Console.WriteLine(concurrentDictionary.GetOrAdd(1, 2));

            int tmp = 4;
            int result = concurrentDictionary.AddOrUpdate(1, tmp, (key, value) => { return tmp; });

            Console.WriteLine(result);
            Console.WriteLine("Hello World!");
        }
    }
}