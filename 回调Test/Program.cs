using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace 回调Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            func("lll", (x) => { Console.WriteLine(x); });
            Console.WriteLine("ThreadID" + Thread.CurrentThread.ManagedThreadId);

            cls cls = new cls();
            cls.event1 += func1;
            cls.Run();

            Console.WriteLine("Hello World!");
        }

        private static void func1(object sender, EventArgs e)
        {
            var sender1 = sender as cls;
            Console.WriteLine(sender1.GetType());
            Console.WriteLine("from event");
        }

        private static void func(string name, Action<string> action)
        {
            Thread.Sleep(1000);
            if (action != null)
            {
                action($"from action {name}");
            }
        }
    }

    internal class cls
    {
        public event EventHandler event1;

        public void Run()
        {
            event1(this, new EventArgs());
        }
    }
}