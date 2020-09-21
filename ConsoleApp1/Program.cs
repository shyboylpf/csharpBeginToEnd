using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var a = Enumerable.Range(1, 30).ToList();
            int[] intlist = new int[30];
            a.Shuffle();
            for (int i = 0; i < intlist.Length; i++)
            {
                intlist[i] = a[i];
            }
        }

        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}