using System;
using System.Collections.Generic;
using System.Linq;

namespace AAATestEverything
{
    internal class Program
    {
        private static Dictionary<string, string> instrumentClass = new Dictionary<string, string>()
        {
            { "EQUI" , "Stock" },
            { "BOND", "Bond" },
            { "PREF", "PreferredShares" },
            { "FUTR", "Future" },
            { "MMKT", "MoneyMarket" },
            { "OPTN", "Option" },
            { "CASH", "Cash" },
            { "SWAP", "Swap" },
            { "ETF", "ExchangeTradedFund" },
            { "BILL", "Bond" },
        };

        private static void Main(string[] args)
        {
            DateTime now = DateTime.UtcNow;
            DateTime now2 = now;
            now2 = DateTime.SpecifyKind(now2, DateTimeKind.Local);
            now2 = now2.ToUniversalTime();
            Console.WriteLine(DateTime.Compare(now, now2));
            var b = instrumentClass.GetValueOrDefault("EQUI1", null);
            Console.WriteLine(instrumentClass.GetValueOrDefault("EQUI"));
            Console.WriteLine(instrumentClass.GetValueOrDefault("EQUI1", null));
            List<DateTime> vs = new List<DateTime>() {
                new DateTime(2021,4,28),
                new DateTime() };

            Console.WriteLine(vs.First(x => x <= new DateTime(2021, 4, 27)).ToString());
            Console.WriteLine(vs.Last() == default);

            //Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
            //Enumerable.Range(0, 100).ToList().ForEach(x => keyValuePairs[x] = "1");
            //Console.WriteLine(keyValuePairs.Keys.Count);
            //Console.WriteLine("Hello World!");
        }
    }
}