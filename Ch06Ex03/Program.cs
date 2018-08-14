using System;

namespace Ch06Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            SalesEmployee employee1 = new SalesEmployee("Alice", 1000, 500);
            Employee employee2 = new Employee("Bob", 1200);
            Console.WriteLine($"{employee1.name}{employee1.CalculatePay()}");
            Console.WriteLine($"{employee2.name}{employee2.CalculatePay()}");
            Console.WriteLine("Hello World!");
        }
    }
    public class Employee
    {
        public string name;
        protected decimal basepay;
        public Employee(string name, decimal basepay)
        {
            this.name = name;
            this.basepay = basepay;
        }
        public virtual decimal CalculatePay()
        {
            return basepay;
        }
    }
    public class SalesEmployee : Employee
    {
        private decimal salesbonus;
        public SalesEmployee(string name, decimal basepay, decimal salesbonus)
            :base(name, basepay)
        {
            this.salesbonus = salesbonus;
        }
        public override decimal CalculatePay()
        {
            //return base.CalculatePay();
            return basepay + salesbonus;
        }

    }
}
