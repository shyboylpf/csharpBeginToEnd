using System;

namespace Ch06Ex08
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.x = 100;
            person.y = 200;
            Console.WriteLine($"{person.x} - {person.y}");
            Console.WriteLine("Hello World!");
        }
    }
    sealed class Person
    {
        public int x;
        public int y;
    }

    //internal class Student : Person
    //{

    //}
}
