using System;

namespace Ch07Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"Enter number of employeess:");
            Employee.numberOfEmployees = int.Parse(Console.ReadLine());
            Employee e1 = new Employee();
            Console.WriteLine("Enter the name of new employee");
            e1.Name = Console.ReadLine();
            Console.WriteLine($"{e1.Counter} - {e1.Name}");
            Console.WriteLine("Hello World!");
        }
    }
    interface IEmployee
    {
        string Name { get; set; }
        int Counter { get; }
    }

    public class Employee : IEmployee
    {
        public static int numberOfEmployees;
        private string name;
        public string Name { get { return name; } set { name = value; } }

        private int counter;
        public int Counter
        {
            get { return counter; }
        }
        public Employee()
        {
            counter = ++counter + numberOfEmployees;
        }
    }
}
