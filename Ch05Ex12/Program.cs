using System;

namespace Ch05Ex12
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            int j = 2;
            Console.WriteLine($"{i}-{j}");
            Swap(ref i, ref j);
            Console.WriteLine($"{i}-{j}");
            Console.WriteLine("Hello World!");
        }
        static void Swap(ref int x, ref int y)
        {
            int temp;
            temp = x;
            x = y;
            y = temp;
        }
    }
}
