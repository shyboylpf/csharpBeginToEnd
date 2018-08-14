using System;

namespace Ch08Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            FillArray(out int[] theArray);
            for(int i=0; i<theArray.Length; i++)
            {
                Console.Write(theArray[i]+" ");
            }
            Console.WriteLine("Hello World!");
        }
        static void FillArray(out int[] arr)
        {
            arr = new int[5] { 1, 2, 3, 4, 5 };
        }
    }
}
