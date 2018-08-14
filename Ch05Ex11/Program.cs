using System;

namespace Ch05Ex11
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            int j = 2;
            Console.WriteLine($"{i}-{j}");
            Swap(i, j);
            Console.WriteLine($"{i}-{j}");

            Console.WriteLine("Hello World!");
        }

        static void Swap(int x, int y)
        {
            int temp;
            temp = x;
            x = y;
            y = temp;
        }
    }
}
