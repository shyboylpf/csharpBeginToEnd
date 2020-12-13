using System;

namespace DIWindsorTest3
{
    public class TargetClass : ITargetClass
    {
        public string func1(string s1)
        {
            Console.WriteLine($"hello from {s1}");
            return s1;
        }
    }
}
