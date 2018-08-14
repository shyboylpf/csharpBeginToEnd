using System;

namespace Ch05Ex14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Message("Jack"));
            Console.WriteLine(Message("Jack", "Hi"));
            Console.WriteLine(Message("Jack", "Hi", "How are you."));
            Console.WriteLine("Hello World!");
        }

        static string Message(string name, params string[] args) // args为形参数组
        {
            string msg = name;
            for(int i=0; i<args.Length; i++)
            {
                msg += " " + args[i];
            }
            return msg;
        }
    }
}
