using System;

namespace Ch03Ex22
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 22;  //00010110
            int j = 105; //01101001
            Console.WriteLine("-{0}: {1}", i, -i);
            Console.WriteLine("{0} & {1} : {2}", i, j, i & j);
            Console.WriteLine("{0} | {1} : {2}", i, j, i | j);
            Console.WriteLine("{0} ^ {1} : {2}", i, j, i ^ j);
            Console.WriteLine("{0} << 3 : {1}", i, i << 3);
            Console.WriteLine("{0} >> 3 : {1}", i, i >> 3);
            Console.WriteLine("Hello World!");

            object obj1 = " someObject";
            object obj2 = 5;
            string str1 = obj1 as string;
            string str2 = obj2 as string;
            Console.WriteLine(str1);
            Console.WriteLine(str2);
            Console.WriteLine(sizeof(byte));

            Type intType = typeof(int);

            byte b = byte.MaxValue;
            checked
            {
                b++;
            }
        }
    }
}
