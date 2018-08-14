using System;

namespace Ch06Ex05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{BaseA.x}:{DerivedA.x}");
            Console.WriteLine("Hello World!");
        }
    }
    public class BaseA
    {
        public static int x = 11;
        public static int y = 22;
    }
    public class DerivedA : BaseA
    {
        new public static int x = 100;
    }
}
