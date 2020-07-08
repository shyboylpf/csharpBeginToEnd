using System;
using System.Linq;

namespace DateTimeTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            string type = null;
            Console.WriteLine( "0".Equals(type));
            int CollectionFrequency = 2;
            // 算归集时间
            int totalMinuteToday = (int)Math.Floor(((DateTime.Now - DateTime.Today).TotalMinutes));
            var t = Enumerable.Range(0, 1440).Where(x => x % CollectionFrequency == 0 && x <= totalMinuteToday);
            foreach (var item in t)
            {
                Console.Write(item + " ");
            }
            int NexCollectionMinutes = Enumerable.Range(0, 1440).Where(x => x % CollectionFrequency == 0 && x <= totalMinuteToday).Max();
            DateTime dateTime = DateTime.Today.AddMinutes(NexCollectionMinutes);
            Console.WriteLine(dateTime);
        }
    }
}