using System;

namespace Ch05Ex07
{
    class Program
    {
        static void Main(string[] args)
        {
            Person personA = new Person("Baby");
            Person personB = new Person("Jack");
            Console.Write($"{personA.number}");
            Console.Write($"{Person.count}");
            //Console.Write($"{personA.count}");
            Console.WriteLine("Hello World!");
        }
    }
    class Person
    {
        public static int count = 0;
        public string name;
        public int number;
        public Person(string name)
        {
            this.name = name;
            count++;
            number = count;
        }
    }
}
