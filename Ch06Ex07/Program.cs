using System;

namespace Ch06Ex07
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            Person person = student;
            person.Name = "Jack";
            person.Age = 20;
            person.ShowInfo();
            Teacher t1 = new Teacher();
            Console.WriteLine("Hello World!");
        }
    }
    public abstract class Person
    {
        private string name;
        private int age;
        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public abstract void ShowInfo();
    }
    public class Student : Person
    {
        public override void ShowInfo()
        {
            Console.WriteLine($"{Name} - {Age}");
        }
    }

    public static class Teacher
    {
        public static void ShowInfo()
        {
            Console.WriteLine("Teacher.");
        }
    }
}
