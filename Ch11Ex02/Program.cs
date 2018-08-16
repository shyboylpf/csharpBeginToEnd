using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ch11Ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nReflection.MemberInfo");
            Type MyType = Type.GetType("System.Reflection.FieldInfo");
            MemberInfo[] Mymemberinfoarray = MyType.GetMembers();
            Console.WriteLine("\nThere are {0} members in {1}.",
                Mymemberinfoarray.Length, MyType.FullName);
            Console.WriteLine("{0}.", MyType.FullName);
            if (MyType.IsPublic)
            {
                Console.WriteLine("{0} is public.", MyType.FullName);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
