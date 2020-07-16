using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace 线程通知机制Test2
{
    internal class Program
    {
        private static readonly AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        private static ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
        private static readonly object _locker = new object();

        private static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var a = new Thread(() =>
             {
                 foreach (var item in Enumerable.Range(1, 100000))
                 {
                     lock (_locker)
                     {
                         queue.Enqueue(item);
                         //Thread.Sleep(1000);
                         autoResetEvent.Set();
                     }
                 }

                 lock (_locker)
                 {
                     queue.Enqueue(-1);
                 }
             });

            //Enumerable.Range(1, 5000).AsParallel().Select(x => x * x);

            //new Thread(() =>
            //{
            //    while (true)
            //    {
            //        int model = default;
            //        lock (_locker)
            //        {
            //            if (queue.Count > 0)
            //            {
            //                queue.TryDequeue(out model);
            //            }
            //        }

            //        if (model != default)
            //        {
            //            //Thread.Sleep(2000);
            //            //Console.WriteLine($"value: {model}, queueCount: {queue.Count}");
            //        }
            //        else
            //        {
            //            Console.WriteLine("WaitOne1");
            //            autoResetEvent.WaitOne();
            //        }
            //    }
            //}).Start();
            var b = new Thread(() =>
            {
                while (true)
                {
                    int model = default;
                    lock (_locker)
                    {
                        if (queue.Count > 0)
                        {
                            queue.TryDequeue(out model);
                            if (model == -1)
                            {
                                //sw.Stop();
                                //Console.WriteLine(sw.ElapsedMilliseconds);
                                return;
                            }
                        }
                    }
                    if (model != default)
                    {
                        //Thread.Sleep(2000);
                        //Console.WriteLine($"value: {model}, queueCount: {queue.Count}");
                        Task.Run(() => { func(model); });
                    }
                    else
                    {
                        //Console.WriteLine("WaitOne2");

                        autoResetEvent.WaitOne();
                    }
                }
            });
            a.Start();
            b.Start();
            a.Join();
            b.Join();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        private static void func(int i)
        {
            //Thread.Sleep(2000);
            Console.WriteLine($"value: {i}, queueCount: {queue.Count}, threadID: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}