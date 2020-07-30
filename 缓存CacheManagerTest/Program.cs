using System;
using System.Linq;
using System.Threading;
using CacheManager.Core;

namespace 缓存CacheManagerTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cache = CacheFactory.Build("getStartedCache", settings =>
            {
                settings.WithSystemRuntimeCacheHandle("handleName");
            });

            cache.Put("test", 23);

            new Thread(() =>
            {
                foreach (var item in Enumerable.Range(1, int.MaxValue))
                {
                    cache.Update("test", v => item);
                }
            }).Start();

            new Thread(() =>
            {
                foreach (var item in Enumerable.Range(1, int.MaxValue))
                {
                    cache.Update("test", v => int.MaxValue - item);
                }
            }).Start();

            new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine(cache.Get("test"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }).Start();

            //cache.Add("keyA", "valueA");
            //cache.Put("keyB", 23);
            //cache.Update("keyB", v => 42);
            //cache.Update("keyB", v => new { a = 1 });

            //Console.WriteLine("KeyA is " + cache.Get("keyA"));      // should be valueA
            //Console.WriteLine("KeyB is " + cache.Get("keyB"));      // should be 42
            //cache.Remove("keyA");

            //Console.WriteLine("KeyA removed? " + (cache.Get("keyA") == null).ToString());

            Console.WriteLine("We are done...");
            Console.ReadKey();
        }
    }
}