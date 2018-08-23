using System;
using System.Collections.Generic;

namespace intList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> l1 = new List<int> { 0,1, 2, 5, 4 };
            Console.WriteLine(l1.Find(x => x == 6));
        }
    }
}
