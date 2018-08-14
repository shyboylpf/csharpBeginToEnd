using System;

namespace Ch05Ex02
{
    class Program
    {
        public class Person
        {
            public int ID;
            protected int age;
            private string name;
            public static int count;
            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
                count++;
            }
            public void ShowPersonInfo()
            {
                Console.WriteLine($"{name}:{age}");
            }
        }
        static void Main(string[] args)
        {
            Person person1 = new Person("Jack", 20);
            Person person2 = new Person("Jack2", 20);
            person1.ID = 001;
            person1.ShowPersonInfo();
            Console.WriteLine(Person.count);
        }
    }
}
