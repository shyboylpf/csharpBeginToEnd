using System;

namespace Ch09Ex04
{
    class Program
    {
        public event EventHandler Click;
        static void Main(string[] args)
        {
            Del a, b, c, d;
            a = Hello;
            b = Goodbye;
            c = a + b;
            d = c - a;
            a("A");
            b("B");
            c("C");
            d("D");

            Console.WriteLine("Hello World!");
        }
        static void Hello(string s)
        {
            System.Console.WriteLine("  hello, {0}", s);
        }
        static void Goodbye(string s)
        {
            Console.WriteLine("  goodbye, {0}", s);
        }
    }
    delegate void Del(string s);
}
