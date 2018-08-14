using System;

namespace Ch07Ex03
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
    interface IDrawingObject
    {
        event EventHandler OnDraw;
    }
    public interface IShape
    {
        event EventHandler OnDraw;
    }
    public class Shape : IDrawingObject, IShape
    {
        event EventHandler PreDrawEvent;
        event EventHandler PostDrawEvent;

        event EventHandler IDrawingObject.OnDraw
        {
            add { PreDrawEvent += value; }
            remove { PreDrawEvent -= value; }
        }
        event EventHandler IShape.OnDraw
        {
            add { PostDrawEvent += value; }
            remove { PostDrawEvent -= value; }
        }

        public void Draw()
        {
            EventHandler handler = PreDrawEvent;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
            Console.WriteLine("Drawing a shape.");

            PostDrawEvent?.Invoke(this, new EventArgs());
        }
    }
    public class Subscriber1
    {
        public Subscriber1(Shape shape)
        {
            IDrawingObject d = (IDrawingObject)shape;
            d.OnDraw += new EventHandler(d_OnDraw);
        }
        void d_OnDraw(object sender, EventArgs e)
        {
            Console.WriteLine("Sub1 receives the IdrawingObject event.");
        }
    }

    public class Subscriber2
    {
        public Subscriber2(Shape shape)
        {
            IShape d = (IShape)shape;
            d.OnDraw += new EventHandler(d_OnDraw);
        }
        void d_OnDraw(object sender, EventArgs e)
        {
            Console.WriteLine("Sub2 receives the IShape event.");
        }
    }

    interface ICloneable
    {
        object Clone();
    }

    class Shape1 : ICloneable
    {
        object ICloneable.Clone() { return null; }
        //public object Clone()
        //{
        //    return null;
        //}
    }
    class Ellipse : Shape1
    {
        //public object Clone() { return null; }
        //object ICloneable.Clone() { return null; }
    }

    interface IControl
    {
        void Paint();
    }
    interface ITextBox : IControl
    {
        void SetText(string text);
    }
    class TextBox : ITextBox
    {
        void IControl.Paint()
        {
            throw new NotImplementedException();
        }

        public void SetText(string text)
        {
            throw new NotImplementedException();
        }
    }
    class TextBox2 : TextBox
    {

    }

    interface IBase
    {
        void F();
    }
    interface IDeriverd : IBase
    {
        void G();
    }
    class C : IDeriverd
    {
        void IBase.F() { }
        void IDeriverd.G() { }
    }
    class D: C, IDeriverd
    {
        public void F() { }
        public void G() { }
    }
}
