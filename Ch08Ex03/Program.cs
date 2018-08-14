using System;

namespace Ch08Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintArray(new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } });
            Console.WriteLine("Hello World!");
        }
        static void PrintArray(int[,] arr)
        {
            for (int i=0; i<4; i++)
            {
                for (int j=0; j<2; j++)
                {
                    Console.WriteLine("Element({0},{1})={2}",i,j,arr[i,j]);
                }
            }
        }
    }
}
