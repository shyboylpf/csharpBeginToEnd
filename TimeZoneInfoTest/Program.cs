using System;

namespace TimeZoneInfoTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DateTime dateTime = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1), TimeZoneInfo.Utc);
            Console.WriteLine(dateTime.ToString());
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            Console.WriteLine(dtStart.ToString());
            Console.WriteLine(TimeZoneInfo.Local);

            long timestamp = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            Console.WriteLine(timestamp);

            DateTime now = dateTime.AddSeconds(timestamp).ToLocalTime();
            Console.WriteLine(now);
            Console.WriteLine("Hello World!");
        }
    }
}