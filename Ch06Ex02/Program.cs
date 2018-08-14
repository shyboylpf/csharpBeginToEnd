using System;

namespace Ch06Ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("123", "jack", 23);
            student.ShowInfo();
            Console.WriteLine("Hello World!");
        }
    }
    public class Person
    {
        protected string name;
        protected int age;
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
            Console.WriteLine("parent Constructor");
        }
        public void ShowInfo()
        {
            Console.WriteLine($"name:{name} - age:{age}");
        }
    }
    public class Student: Person
    {
        private string StudentID;
        public Student(string studentID, string name, int age) : base(name, age)
        {
            this.StudentID = studentID;
            Console.WriteLine("Child Constructor");
        }
        new public void ShowInfo()  // 用new关键字隐藏基类中的同名方法
        {
            Console.WriteLine("Student");
            base.ShowInfo();  // 调用基类方法
            Console.WriteLine($"studentID:{StudentID}");
        }
    }
}
