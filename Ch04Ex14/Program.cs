using System;

namespace Ch04Ex14
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = null;
            if( str == null)
            {
                throw new ArgumentNullException();
            }
            Console.WriteLine("Hello World!");
        }
    }
}
