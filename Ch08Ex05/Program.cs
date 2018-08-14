using System;

namespace Ch08Ex05
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] theArray = { 1, 2, 3, 4, 5 };
            FillArray(ref theArray);
            for (int i=0; i<theArray.Length; i++)
            {
                Console.WriteLine(theArray[i] + " ");
            }
            Console.WriteLine("Hello World!");
        }
        static void FillArray(ref int[] arr)
        {
            if(arr == null)
            {
                arr = new int[10];
            }
            arr[0] = 1111;
            arr[4] = 5555;
        }
    }
}
