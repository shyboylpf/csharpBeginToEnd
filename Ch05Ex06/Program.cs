using System;

namespace Ch05Ex06
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassPerson classPersonA = new ClassPerson("Jack" , 20);
            ClassPerson classPersonB = classPersonA;
            classPersonB.Name = "Smith";
            classPersonB.Age = 15;

            StructPerson structPersonA = new StructPerson("Jack", 20);
            StructPerson structPersonB = structPersonA;
            // 修改
            structPersonB.Name = "Smith";
            structPersonB.Age = 15;

            Console.WriteLine($"{classPersonA.Name}-{structPersonA.Name}");
            Console.WriteLine("Hello World!");
        }
    }

    class ClassPerson
    {
        private string name;
        private int age;
        public ClassPerson()
        {
            name = "unknown";
            age = 0;
        }
        public ClassPerson(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }

    }
    struct StructPerson
    {
        private string name;
        private int age;
        public StructPerson(string name, int age)  // 在结构体中不能定义默认无参构造函数
        {                                          // 只能定义struct的带参数的constructor
            this.name = name;
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
