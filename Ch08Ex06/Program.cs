using System;
using System.Collections;

namespace Ch08Ex06
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList AL = new ArrayList();
            AL.Add("Hello");
            AL.Add(" World");
            Console.WriteLine("给数组添加元素: ");
            foreach(object obj in AL)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine($"{AL.Count} - {AL.Capacity}");
            AL.Insert(1, " c#");
            Console.WriteLine("在索引值为1的地方插入 ");
            foreach(object obj in AL)
            { Console.WriteLine(obj); }
            Console.WriteLine($"{AL.Count} - {AL.Capacity}");
            AL.Insert(1, 123);
            Console.WriteLine($"{AL.Count} - {AL.Capacity}");
            AL.Insert(2, 456);
            Console.WriteLine($"{AL.Count} - {AL.Capacity}");
            Console.WriteLine("Hello World!");
        }
    }
}
