using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSRedis;

namespace csredis_client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RedisHelper.Initialization(new CSRedis.CSRedisClient("192.168.1.217"));
            //var a = RedisHelper.Exists("11");
            //RedisHelper.Set("11", "11", TimeSpan.FromMinutes(1));
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (var item in Enumerable.Range(0, 2000))
            {
                var _ = RedisHelper.GetAsync("device_realtime_data_0");
                //Console.WriteLine(item);
            }

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(() =>
                {
                    foreach (var item in Enumerable.Range(0, 200))
                    {
                        var _ = RedisHelper.Get("device_realtime_data_0");
                        //Console.WriteLine(item);
                    }
                });
                threads.Add(thread);
            }

            threads.ForEach(x => x.Start());
            threads.ForEach(x => x.Join());

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            //string ping = redis.Ping();
            //string echo = redis.Echo("hello world");
            //DateTime time = redis.Time();
            //redis.Set("111", "123");
            //redis.Get("111");
        }
    }
}