using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProcessAndThread05
{
    class Program
    {
        private int counter = 0;
        static void Main(string[] args)
        {
            Program t = new Program();
            t.DoTest();

        }

        private void DoTest()
        {
            Thread t1 = new Thread(new ThreadStart(Incrementer));
            t1.IsBackground = true;
            t1.Name = "ThreadOne";
            t1.Start();
            Console.WriteLine("Start thread {0}.", t1.Name);
            Thread t2 = new Thread(new ThreadStart(Incrementer));
            t2.IsBackground = true;
            t2.Name = "ThreadTwo";
            t2.Start();
            Console.WriteLine("Started thread {0}", t2.Name);
            Thread t3 = new Thread(new ThreadStart(Incrementer))
            {
                IsBackground = true,
                Name = "ThreadThree"
            };
            t3.Start();
            Console.WriteLine("Started thread {0}", t3.Name);
            t1.Join();
            t2.Join();
            t3.Join();
            //等待所有线程都结束
            Console.WriteLine("All my threads are done.");
        }

        private void Incrementer()
        {
            try
            {
                while (counter < 100)
                {
                    //// 使用互锁
                    //Interlocked.Increment(ref counter);
                    //// 线程挂起
                    //Thread.Sleep(1);
                    lock (this)
                    {
                        int temp = counter;
                        temp++;
                        Thread.Sleep(2);
                        counter = temp;
                    }
                    //显示结果
                    Console.WriteLine("Thread {0}. Incrementer: {1}", Thread.CurrentThread.Name, counter);
                }
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.Name} interrupted! Cleaning up...");
            }
            finally
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.Name} Exiting.");
            }
        }
    }
}
