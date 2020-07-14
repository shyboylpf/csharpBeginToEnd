using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace 线程通信Test
{
    /// <summary>
    /// 此模型如果消费速度低于生产速度的话, 会产生队列消息堆积
    /// 可以通过增加消费者来解决
    /// </summary>
    internal class Program
    {
        private static readonly object _locker = new object();
        private static ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

        private static void Main(string[] args)
        {
            new Thread(() =>
            {
                foreach (var item in Enumerable.Range(1, 500))
                {
                    lock (_locker)
                    {
                        queue.Enqueue(item);
                        Monitor.Pulse(_locker);
                        Thread.Sleep(1000);
                    }
                }
            }).Start();

            new Thread(() =>
            {
                while (true)
                {
                    int model;
                    lock (_locker)
                    {
                        while (!queue.TryDequeue(out model))
                        {
                            Monitor.Wait(_locker);
                            Console.WriteLine("线程ID: " + Thread.CurrentThread.ManagedThreadId + " waiting");
                        }
                    }
                    Console.WriteLine($"value: {model}, queueCount: {queue.Count}");
                    Thread.Sleep(2000);
                }
            }).Start();

            new Thread(() =>
            {
                while (true)
                {
                    int model;
                    lock (_locker)
                    {
                        while (!queue.TryDequeue(out model))
                        {
                            Monitor.Wait(_locker);
                            Console.WriteLine("线程ID: " + Thread.CurrentThread.ManagedThreadId + " waiting");
                        }
                    }
                    Console.WriteLine($"value: {model}, queueCount: {queue.Count}");
                    Thread.Sleep(2000);
                }
            }).Start();

            new Thread(() =>
            {
                while (true)
                {
                    int model;
                    lock (_locker)
                    {
                        while (!queue.TryDequeue(out model))
                        {
                            Monitor.Wait(_locker);
                            Console.WriteLine("线程ID: " + Thread.CurrentThread.ManagedThreadId + " waiting");
                        }
                    }
                    Console.WriteLine($"value: {model}, queueCount: {queue.Count}");
                    Thread.Sleep(2000);
                }
            }).Start();

            //Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}