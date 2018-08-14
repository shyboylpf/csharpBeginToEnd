using System;

namespace Ch05Ex10
{
    class Program
    {
        static void Main(string[] args)
        {
            Person.Number = 1000;
            Person personA = new Person
            {
                Name = "Jack",
                Age = 20
            };
            Console.WriteLine($"{Person.Counter}-{personA.Name}-{personA.Age}");
            Console.WriteLine("Hello World!");
        }
    }

    class Person
    {
        public static int Number;
        private static int counter = 0;
        private string name;
        private int age;
        public Person()
        {
            counter = ++counter + Number;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public static int Counter
        {
            get { return counter; }
        }
    }
}
