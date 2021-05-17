using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = new string[200];
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            foreach(var item in Enumerable.Range(1, 100))
            {
                keyValuePairs[item.ToString()] = item.ToString();
            }


            keyValuePairs.Keys.CopyTo(a, 0);

            List<string> c = new List<string>();
            c.Reverse();

            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }
    }
}
