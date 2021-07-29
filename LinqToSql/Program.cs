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

            int[] scores2 = new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 };
            var result = scores2.Where(x => x >= 2).GroupBy(x => x);
            foreach (var item in result)
            {
                Console.WriteLine(item.Key + "  " + item.Sum(x => x));
            }

            // 把每个内嵌的List取出，因为每一个List都是IEnumerable，合并成一个大的IEnumerable
            List<List<int>> numbers = new List<List<int>>()
            {
              new List<int>{1,2,3},
              new List<int>{4,5,6},
              new List<int>{7,8,9}
            };
            var result2 = numbers.SelectMany(x => x);
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
        }
    }
}