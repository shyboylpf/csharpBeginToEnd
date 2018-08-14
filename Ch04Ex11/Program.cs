using System;

namespace Ch04Ex11
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 55;
            Console.WriteLine($"x = {x}");
            if (x == 55)
            {
                x = 135;
                goto A;// error
            }

            x = x + 1;
            A: for (int i=1; i<=5; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(x);
        }
    }
}
