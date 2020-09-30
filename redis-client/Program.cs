using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace redis_client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("192.168.1.217");

            IDatabase db = redis.GetDatabase();
            //string value = "abcdefg";
            //db.StringSet("mykey", value);
            if (db.KeyExists("mykey"))
            {
                var value = db.StringGet("mykey");
                Console.WriteLine(value);
            }

            byte[] key = Encoding.ASCII.GetBytes("mybytekey");
            byte[] value2 = Encoding.ASCII.GetBytes("mybytevalue");
            db.StringSet(key, value2);
            byte[] value3 = db.StringGet(key);

            ISubscriber sub = redis.GetSubscriber();
            sub.Publish("messages", "hello");
            sub.Subscribe("messages", (channel, message) =>
            {
                Console.WriteLine((string)message);
            });
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(incrVideoCounter(db, 101));
            }
            //rateLimit(db,"");
        }

        private static long incrVideoCounter(IDatabase db, long id)
        {
            string key = "video:playCount:" + id;
            return db.StringIncrement(key);
        }

        private static bool rateLimit(IDatabase db, string phoneNum)
        {
            phoneNum = "18354271111";
            string key = "shortMsg:limit:" + phoneNum;
            db.StringSet(key, 1, new TimeSpan(50));
            return true;
        }
    }
}