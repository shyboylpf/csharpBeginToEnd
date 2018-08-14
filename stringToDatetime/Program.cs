using System;
using System.Globalization;

namespace stringToDatetime
{
    class Program
    {
        static void Main(string[] args)
        {
            string dt = "07月24日13:08";
            DateTime dt2 = DateTime.ParseExact(dt, "MM月dd日HH:mm", new CultureInfo("en-US"));
            Console.WriteLine(dt2);
            Console.WriteLine("Hello World!");
        }
    }
}
