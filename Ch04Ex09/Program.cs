using System;

namespace Ch04Ex09
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i == 6)
                    break;  // 跳出整个循环
                Console.WriteLine(i);
            }
            Console.WriteLine("finish");

            for (int i = 1; i <= 10; i++)
            {
                if (i == 6)
                    continue;  // 跳出本次循环 , 直接进入下一次循环
                Console.WriteLine(i);
            }
            Console.WriteLine("finish");


        }
    }
}
