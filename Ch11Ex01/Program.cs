using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ch11Ex01
{
    class Program
    {
        public static void PrintMembers(MemberInfo[] ms)
        {
            foreach(MemberInfo m in ms)
            {
                Console.WriteLine("{0}{1}","    ",m);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Type t = typeof(System.String);
            Console.WriteLine($"Listing all the public constructors of the {t} type.");
            ConstructorInfo[] ci = t.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            Console.WriteLine("//Constructors");
            PrintMembers(ci);
            Console.WriteLine("Hello World!");
        }
    }
}
