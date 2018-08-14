using System;
using System.Collections.Generic;

namespace Ch09Ex05
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle(54);
            Rectangle r1 = new Rectangle(12, 9);
            ShapeContainer sc = new ShapeContainer();
            sc.AddShape(c1);
            sc.AddShape(r1);
            c1.Update(57);
            r1.Update(7, 7);
            Console.WriteLine("Hello World!");
        }
    }
    public class ShapeEventArgs : EventArgs
    {
        private double newArea;
        public ShapeEventArgs(double d)
        {
            newArea = d;
        }
        public double NewArea
        {
            get { return newArea; }
        }
    }
    public abstract class Shape
    {
        protected double area;
        public double Area
        {
            get { return area; }
            set { area = value; }
        }
        public event EventHandler<ShapeEventArgs> ShapeChanged;
        public abstract void Draw();
        protected virtual void OnShapeChanged(ShapeEventArgs e)
        {
            ShapeChanged?.Invoke(this, e);  // 当shape改变的时候 , 就调用事件 , 通知别人.
        }
    }
    public class Circle : Shape
    {
        private double radius;
        public Circle(double d)
        {
            radius = d;
            area = 3.14 * radius;
        }
        public void Update(double d)
        {
            radius = d;
            area = 3.14 * radius;
            OnShapeChanged(new ShapeEventArgs(area));
        }
        protected override void OnShapeChanged(ShapeEventArgs e)
        {
            base.OnShapeChanged(e);
        }
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle.");
        }
    }
    public class Rectangle : Shape
    {
        private double length;
        private double width;
        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
            area = length * width;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle.");
        }

        public void Update(double length, double width)
        {
            this.length = length;
            this.width = width;
            area = length * width;
            OnShapeChanged(new ShapeEventArgs(area)); // 由于类中自己实现了 , 然后就会调用自己的.
        }
        protected override void OnShapeChanged(ShapeEventArgs e)
        {
            base.OnShapeChanged(e);
        }
    }
    public class ShapeContainer
    {
        List<Shape> _list;
        public ShapeContainer()
        {
            _list = new List<Shape>();
        }
        public void AddShape(Shape s)
        {
            _list.Add(s);
            // 订阅基类事件
            s.ShapeChanged += HandleShapeChanged;
        }

        private void HandleShapeChanged(object sender, ShapeEventArgs e)
        {
            Shape s = (Shape)sender;
            Console.WriteLine("Received event . Shape area is noew {0}", e.NewArea);
            // 重新Draw
            s.Draw();
        }
    }
}
