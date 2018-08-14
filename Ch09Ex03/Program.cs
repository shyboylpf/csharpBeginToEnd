using System;

namespace Ch09Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle.handler = HandlerMethod;
            Rectangle.handler(new Rectangle());

            Circle.handler = HandlerMethod;
            Circle.handler(new Circle());
            Handler hander1 = new Handler(HandlerMethod);
            hander1(new Rectangle());
            Console.WriteLine("Hello World!");
        }
        public static void HandlerMethod(Shape s)
        {
            Console.WriteLine(s.GetType());
        }
    }
    public delegate void Handler(Rectangle r);
    public delegate void Handler2(Circle c);
    public class Shape { }
    public class Rectangle : Shape
    {
        public static Handler handler;
    }
    public class Circle : Shape
    {
        public static Handler2 handler;
    }
}
