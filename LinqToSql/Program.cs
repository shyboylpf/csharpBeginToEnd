using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToSql
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60 };

            // define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            foreach (int i in scoreQuery)
            {
                Console.WriteLine(i + " ");
            }
        }
    }
}