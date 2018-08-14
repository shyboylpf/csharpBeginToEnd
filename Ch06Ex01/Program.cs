using System;

namespace Ch06Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("123", "jack",12);
            student.ShowPersonInfo(); // 调用基类方法
            student.ShowStudentInfo(); // 调用自身类的方法
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
        }
        public void ShowPersonInfo()
        {
            Console.WriteLine($"name:{name} age:{age}");
        }
    }
    public class Student : Person
    {
        private string StudentID;
        public Student(string studentID, string name, int age) : base(name, age)
        {// 调用直接基类的实例构造函数
            this.StudentID = studentID;
        }
        public void ShowStudentInfo()
        {
            Console.WriteLine($"StudentID:{StudentID}");
        }
    }
}
