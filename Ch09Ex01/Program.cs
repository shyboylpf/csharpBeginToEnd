using System;

namespace Ch09Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            D cd1 = new D(C.M1);
            cd1(-1);
            D cd2 = new D(C.M2);
            cd2(-2);
            D cd3 = cd1 + cd2;
            cd3(10);
            cd3 += cd1;
            cd3(20);
            C c = new C();
            D cd4 = new D(c.M3);
            cd3 += cd4;
            cd3(30);
            cd3 -= cd1;
            Console.WriteLine("Hello World!");
        }
    }
    delegate void D(int x);
    class C
    {
        public static void M1(int i)
        {
            Console.WriteLine("C.M1: " + i);
        }
        public static void M2(int i)
        {
            Console.WriteLine("C.M2: " + i);
        }
        public void M3(int i)
        {
            Console.WriteLine("C.M3: " + i);
        }
    }
}
