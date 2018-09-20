using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace redis_client
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("192.168.0.20");

            IDatabase db = redis.GetDatabase();
            string value = "abcdefg";
            db.StringSet("mykey", value);

            value = db.StringGet("mykey");
            Console.WriteLine(value);

            byte[] key = Encoding.ASCII.GetBytes("mybytekey");
            byte[] value2 = Encoding.ASCII.GetBytes("mybytevalue");
            db.StringSet(key, value2);
            byte[] value3 = db.StringGet(key);

            ISubscriber sub = redis.GetSubscriber();
            sub.Publish("messages", "hello");
            sub.Subscribe("messages",(channel,message)=> {
                Console.WriteLine((string)message);
            });
            for(int i=0;i<100;i++)
            Console.WriteLine(incrVideoCounter(db,101));
            //rateLimit(db,"");

        }

        static long incrVideoCounter(IDatabase db, long id)
        {
            string key = "video:playCount:" + id;
            return db.StringIncrement(key);
        }

        static bool rateLimit(IDatabase db, string phoneNum)
        {
            phoneNum = "18354276712";
            string key = "shortMsg:limit:" + phoneNum;
            db.StringSet(key, 1, new TimeSpan(50));
            return true;
        }
    }
}
