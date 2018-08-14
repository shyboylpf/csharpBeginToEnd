using System;

namespace Ch09Ex02
{
    class Program
    {
        public delegate Mammals HandlerMethod();   // 委托
        public static Mammals FirstHandler() { return new Mammals(); }
        public static Dogs SecondHandler() { return new Dogs(); }
        static void Main(string[] args)
        {
            HandlerMethod handler = FirstHandler;
            Console.WriteLine(handler().GetType());

            HandlerMethod handler2 = SecondHandler;
            Console.WriteLine(handler2().GetType());
            Console.WriteLine("Hello World!");
        }
    }
    class Mammals { }
    class Dogs : Mammals { }
}
