using System;

namespace Ch05Ex05
{
    class Program
    {
        static void Main(string[] args)
        {
            Third t = new Third();
            //Console.WriteLine("Hello World!");
        }
    }
    class First
    {
        ~First()
        {
            Console.WriteLine("First destructor is called.");
        }
    }
    class Second : First
    {
        ~Second()
        {
            Console.WriteLine("Second destructor is called.");
        }
    }
    class Third : Second
    {
        ~Third()
        {
            Console.WriteLine("Third destructor is called.");
        }
    }
}
