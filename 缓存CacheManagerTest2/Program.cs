using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheManager.Core;

namespace 缓存CacheManagerTest2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cache = CacheFactory.Build("getStartedCache", settings =>
            {
                settings.WithSystemRuntimeCacheHandle("handleName");
            });

            cache.Add("keyA", "valueA");
            cache.Put("keyB", 23);
            cache.Update("keyB", v => 42);
            cache.Update("keyB", v => new { a = 1 });

            Console.WriteLine("KeyA is " + cache.Get("keyA"));      // should be valueA
            Console.WriteLine("KeyB is " + cache.Get("keyB"));      // should be 42
            cache.Remove("keyA");

            Console.WriteLine("KeyA removed? " + (cache.Get("keyA") == null).ToString());

            Console.WriteLine("We are done...");
            Console.ReadKey();
        }
    }
}