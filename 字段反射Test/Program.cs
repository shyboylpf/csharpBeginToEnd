using System;

namespace 字段反射Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            aaa a = new aaa()
            {
                a = 1,
            };
            foreach (System.Reflection.PropertyInfo p in a.GetType().GetProperties())
            {
                Console.WriteLine("Name:{0} Value:{1}", p.Name, p.GetValue(a));
            }
            Console.WriteLine("Hello World!");
        }
    }

    internal class aaa
    {
        public int a { get; set; }
        public int b { get; set; }
    }
}