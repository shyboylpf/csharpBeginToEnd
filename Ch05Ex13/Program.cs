using System;

namespace Ch05Ex13
{
    class Program
    {
        static void Main(string[] args)
        {
            double area = 0.0;
            Rectangle rectangle = new Rectangle(2.0, 3.0);
            area = rectangle.GetArea(out double circumference);
            Console.WriteLine($"return{area} circumference{circumference}");
        }
    }
    class Rectangle
    {
        private double width;
        private double height;
        public Rectangle(double width , double height)
        {
            this.width = width;
            this.height = height;
        }
        public double GetArea(out double circumference)  // 为输出参数cirumference赋值
        {
            circumference = (width + height) * 2;
            return width * height;
        }
    }
}
