using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace ProcessAndThread03
{
    class Program
    {
        public static void ThreadProc()
        {
            for(int i=0; i<10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread: start a second thread.");
            // 声明并实例化这个线程
            Thread t = new Thread(new ThreadStart(ThreadProc));
            // 启动这个额线程实例
            t.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread : Do some Work");
                Thread.Sleep(0);
            }
            Console.WriteLine("Main Thread : Call Join() , to wait until ThreadProc ends.");
            // 等待线程结束
            t.Join();
            Console.WriteLine("Main thread: ThreadProc.Join has returned. Press");
            Console.WriteLine("Hello World!");
        }
    }
}
