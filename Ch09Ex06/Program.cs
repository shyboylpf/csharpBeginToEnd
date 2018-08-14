using System;

namespace Ch09Ex06
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape shape = new Shape();
            Subscriber1 sub = new Subscriber1(shape);
            Subscriber2 sub2 = new Subscriber2(shape);
            shape.Draw();
            Console.WriteLine("Hello World!");
        }
    }

    public interface IDrawingObject
    {
        event EventHandler OnDraw;
    }
    public interface IShape
    {
        event EventHandler OnDraw;
    }

    public class Shape :IDrawingObject, IShape
    {
        event EventHandler PreDrawEvent;
        event EventHandler PostDrawEvent;
        object objectLock = new object();
        event EventHandler IDrawingObject.OnDraw
        {
            add
            {
                lock (objectLock)
                {
                    PreDrawEvent += value;
                }
            }
            remove
            {
                lock(objectLock)
                {
                    PreDrawEvent -= value;
                }
            }
        }

        event EventHandler IShape.OnDraw
        {
            add
            {
                lock (objectLock)
                {
                    PostDrawEvent += value;
                }
            }

            remove
            {
                lock (objectLock)
                {
                    PostDrawEvent -= value;
                }
            }
        }

        public void Draw()
        {
            PreDrawEvent?.Invoke(this, new EventArgs());
            Console.WriteLine("Drawing a shape.");
            PostDrawEvent?.Invoke(this, new EventArgs());
        }
    }

    public class Subscriber1
    {
        public Subscriber1(Shape shape)
        {
            IDrawingObject d = shape as IDrawingObject;
            d.OnDraw += new EventHandler(d_OnDraw);
        }
        void d_OnDraw(object sender, EventArgs e)
        {
            Console.WriteLine("sub1 receives the idrawingobject event.");
        }
    }
    public class Subscriber2
    {
        public Subscriber2(Shape shape)
        {
            IShape d = shape as IShape;
            d.OnDraw += D_OnDraw;
        }

        private void D_OnDraw(object sender, EventArgs e)
        {
            Console.WriteLine("sub2 receives the ishape event.");
        }
    }
}
