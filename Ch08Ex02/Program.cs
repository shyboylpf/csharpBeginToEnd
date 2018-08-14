using System;

namespace Ch08Ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekDays = new string[] { "sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            PrintArray(weekDays);
            Console.WriteLine("Hello World!");
        }
        static void PrintArray(string[] arr)
        {
            for(int i=0; i<arr.Length; i++)
            {
                Console.Write(arr[i] + "{0}", i<arr.Length-1?" ":"");
            }
            Console.WriteLine();
        }
    }
}
