using System;

namespace Ch08Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            // 声明
            int[][] arr = new int[2][];
            // 初始化
            arr[0] = new int[5] { 1, 3, 5, 7, 9 };
            arr[1] = new int[4] { 2, 4, 6, 8 };
            // display
            for(int i=0; i< arr.Length; i++)
            {
                Console.Write($"Element{i}: ");
                for(int j=0; j<arr[i].Length; j++)
                {
                    Console.Write($"{arr[i][j]}{" "}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Hello World!");
        }
    }
    
}
