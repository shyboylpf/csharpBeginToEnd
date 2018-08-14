using System;

namespace Ch06Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = 3.0, h = 5.0;
            Dimensions c = new Circle(r);
            Dimensions s = new Sphere(r);
            Dimensions l = new Cylinder(r, h);
            Console.WriteLine($"{c.Area()} - {s.Area()} - {l.Area()}");
            Console.WriteLine("Hello World!");
        }
    }
    public class Dimensions
    {
        public const double PI = Math.PI;
        protected double x, y;
        public Dimensions()
        {

        }
        public Dimensions(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public virtual double Area()
        {
            return x * y;
        }
    }
    public class Circle : Dimensions
    {
        public Circle(double r) : base(r, 0)
        {

        }
        public override double Area()
        {
            return PI * x * x;
        }
    }
    class Sphere : Dimensions
    {
        public Sphere(double r) : base(r, 0)
        {

        }
        public override double Area()
        {
            return 4 * PI * x * x;
        }
    }
    class Cylinder : Dimensions
    {
        public Cylinder(double r, double h) : base(r, h)
        {

        }
        public override double Area()
        {
            return 2 * PI * x * x + 2 * PI * x * y;
        }
    }
}
