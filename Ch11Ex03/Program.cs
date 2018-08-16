using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ch11Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reflection.MethodInfo");
            Type MyType = Type.GetType("System.Reflection.FieldInfo");
            MethodInfo Mymethodinfo = MyType.GetMethod("GetValue");
            Console.WriteLine(MyType.FullName + "." + Mymethodinfo.Name);
            MemberTypes Mymembertypes = Mymethodinfo.MemberType;
            switch (Mymembertypes)
            {
                case MemberTypes.Constructor:
                    Console.WriteLine("1");
                    break;
                case MemberTypes.Custom:
                    break;
                case MemberTypes.Event:
                    break;
                case MemberTypes.Field:
                    break;
                case MemberTypes.Method:
                    Console.WriteLine("this is a method.");
                    break;
                case MemberTypes.Property:
                    break;
                case MemberTypes.TypeInfo:
                    break;
            }
             
            Console.WriteLine("Hello World!");
        }
    }
}
