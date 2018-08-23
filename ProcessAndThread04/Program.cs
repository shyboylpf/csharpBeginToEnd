using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace ProcessAndThread04
{
    class Program
    {
        //public int iCounter = 0;
        //public static int ICounter
        //{
        //    get { return ICounter; }
        //    set { ICounter = value; }
        //}
        //public static void ThreadProc()
        //{
        //    for(int i = 0; i < 100; i++)
        //    {
        //        ICounter = ICounter++;
        //    }
        //}
        private int counter = 0;
        static void Main(string[] args)
        {
            //// 声明并实例化这个线程
            //Thread t = new Thread(new ThreadStart(ThreadProc));
            //// 启动这个额线程实例
            //t.Start();
            Program program = new Program();
            program.DoTest();
            Console.WriteLine("hello World.");
        }

        private void DoTest()
        {
            Thread t1 = new Thread(new ThreadStart(Incrementer))
            {
                IsBackground = true,
                Name = "ThreadOne"
            };
        }

        private void Incrementer()
        {
            try
            {
                while(counter < 10)
                {
                    // 使用互锁
                    Interlocked.Increment(ref counter);
                    // 线程挂起
                    Thread.Sleep(1);
                    // 显示结果
                    Console.WriteLine("Thread {0}. Incrementer : {1}", Thread.CurrentThread.Name, counter);
                }
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Thread {0} interrupted! Cleaning up ...", Thread.CurrentThread.Name);
            }
            finally
            {
                Console.WriteLine("Thread {0} Exiting. ", Thread.CurrentThread.Name);
            }
        }
    }
}
