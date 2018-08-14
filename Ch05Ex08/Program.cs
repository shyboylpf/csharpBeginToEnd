using System;

namespace Ch05Ex08
{
    class Program
    {
        static void Main(string[] args)
        {
            Person personA = new Person();
            //personA.name = "smti";
            Console.WriteLine("Hello World!");
        }
    }
    class Person
    {
        public readonly string name = "unknown";
        public readonly int age = 0;
        public Person()
        {
            this.name = "Jack";
            this.age = 20;
        }
    }
}
