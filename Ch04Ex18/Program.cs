#define DEBUG
#define BUG
#undef BUG

using System;

namespace Ch04Ex18
{
    class Program
    {
        static void Main(string[] args)
        {
#if (DEBUG && !BUG)
            Console.WriteLine("Hello World!");
#elif (DEBUG && BUG)
            Console.WriteLine("123");
#endif

#if DEBUG
#warning DEBUG is defined(warning)
            Console.WriteLine("warning");
            //#error DEBUG is defined(error)
#endif

            Console.WriteLine("#1");
#line hidden
            Console.WriteLine("#2");
#line default
            Console.WriteLine("#3");
        }
    }
}
