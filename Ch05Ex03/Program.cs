using System;

namespace Ch05Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassPerson classPersonA = new ClassPerson();
            ClassPerson classPersonB = new ClassPerson("Jack", 20);
            Console.WriteLine($"{classPersonA.Name} : {classPersonA.Age} + {classPersonB.Name} : {classPersonB.Age}");
            Console.WriteLine("Hello World!");
        }
    }
    class ClassPerson
    {
        private string name;
        private int age;
        public ClassPerson() { }  // 默认无参构造函数 
        public ClassPerson(string name, int age)  // 实例构造函数 , 在构造实例的同事给字段赋值
        {
            this.name = name;  // 由于参数 name 与字段name名字相同 , 所以要加个this 指明这个name是类的
            this.age = age;
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
    }
}
