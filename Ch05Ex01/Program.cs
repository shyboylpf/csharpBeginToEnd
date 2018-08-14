using System;
using QuadLibrary;


namespace Ch05Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            Quad quad = new Quad(2.0, 3.0);
            Console.WriteLine(quad.GetQuadArea());
        }
    }
}
