using System;
using System.IO;
using System.Reflection;

namespace Ch11Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(System.IO.BufferedStream);
            Console.WriteLine("列出{0}类型的所有成员(公开和非公开)",t);
            FieldInfo[] fi = t.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// static fields");
            PrintMembers(fi);
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("static properties");
            PrintMembers(pi);
            EventInfo[] ei = t.GetEvents(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            fi = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            PrintMembers(fi);
            Console.WriteLine("Hello World!");
        }
        public static void PrintMembers(MemberInfo[] ms)
        {
            foreach (MemberInfo m in ms)
            {
                Console.WriteLine("{0}{1}", "    ", m);
            }
            Console.WriteLine();
        }
    }
}
