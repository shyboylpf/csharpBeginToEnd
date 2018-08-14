using System;

namespace Ch05Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            Person.ShowPersonInfo();
            Console.WriteLine("Hello World!");
            double PI = Trig.PI;
        }
    }
    class Person
    {
        static private string name;
        static private int age;
        static Person()
        {
            Console.WriteLine("The static constructor invoked. 静态构造函数被调用了");
        }
        public static void ShowPersonInfo()
        {
            Console.WriteLine("The ShowPersonInfo method invoked. ShowPersonInfo静态方法被调用");
            Console.WriteLine($"{name}{Person.age}");
        }
    }

    public class Trig
    {
        private Trig() { }
        public const double PI = 3.1415926;
    }

    //public class Trig2 : Trig
    //{

    //}
}
