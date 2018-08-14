using System;
using System.Threading;

namespace Ch05Ex09
{
    class Program
    {
        static void Main(string[] args)
        {
            Test.finished = false;
            new Thread(new ThreadStart(Test.Thread2)).Start();
            for(; ; )
            {
                if (Test.finished)
                {
                    Console.WriteLine("result = {0}.",Test.result);
                    return;
                }
                else
                {
                    Console.WriteLine("meijieshu");
                }
            }
            //Console.WriteLine("Hello World!");
        }
    }

    class Test
    {
        public static int result;  // 静态字段
        public static volatile bool finished;  // 静态易失字段
        public static void Thread2()
        {
            result = 12;
            finished = true;
        }
    }
}
