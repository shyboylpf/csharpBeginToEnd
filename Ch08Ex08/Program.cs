using System;

namespace Ch08Ex08
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 9, 27, 6, 18, 12, 21, 15 };
            int min;
            for(int i=0; i<arr.Length; i++)
            {
                min = i;
                for (int j=i+1; j<arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                        min = j;
                }
                int t = arr[min];
                arr[min] = arr[i];
                arr[i] = t;
            }
            Array.Sort(arr);
            Array.Reverse(arr);
            foreach (int n in arr)
            {
                Console.WriteLine($"{n} ");
            }
            Console.WriteLine("Hello World!");
        }
    }
}
