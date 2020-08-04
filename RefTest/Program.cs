using System;

namespace RefTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int a = 0;
            test1(ref a);
            Console.WriteLine(a);

            cls model = new cls();
            model.a = 0;
            test2(ref model);
            Console.WriteLine(model.a);

            cls model2 = new cls();
            model2.a = 0;
            test3(model2);
            Console.WriteLine(model2.a);
            Console.WriteLine("Hello World!");
        }

        private static void test1(ref int i)
        {
            i = 1;
        }

        private static void test2(ref cls model)
        {
            model.a = 1;
        }

        private static void test3(cls model)
        {
            model.a = 1;
        }
    }

    internal class cls
    {
        public int a = 0;
    }
}