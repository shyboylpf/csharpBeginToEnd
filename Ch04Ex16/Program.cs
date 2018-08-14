using System;

namespace Ch04Ex16
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 123;
            string s = "Some string";
            object o = s;
            //try
            //{
            //    i = (int)o;
            //}
            //finally
            //{
            //    Console.Write($"i = {i}");
            //}
            SC2 c1 = new SC2();
            
            Console.WriteLine(c1.C2(3));

            VC1 vc1 = new VC1();
            VC1.VC2 aa = new VC1.VC2();
            Console.WriteLine(vc1.Vc2());
            Console.WriteLine(aa);
            VC1 vc2 = new VC1(new SC2());


        }
        public abstract class C1 {
            public virtual void C2() { return; }
            public virtual int C2(int i) { return 1; }
            public abstract void C3(); // 派生类必须实现此方法
            public void C4() { }
            
        }

        public class SC2 : C1
        {
            public event EventHandler<string> Event1;
            public override void C3()
            {
                throw new NotImplementedException();
            }
            public override void C2()
            {
                base.C2();
            }
            public override int C2(int i)
            {
                
                return base.C2(i);
            }
            // 子类重新定义父类的函数 , 因为父类的此方法既不是virtual 也是不 abstract , 所以需要new来显示指明我就是要重新实现它
            public new void C4() { }
            // 子类自己定义新方法
            public void C5() { }
        }
        public class VC1
        {
            public VC1()
            {
                VC2 a = new VC2();

            }
            public VC1(SC2 sss)
            {
                // 添加 , 侦听时间发生
                sss.Event1 += Faxmsg;
            }
            // 这儿是一个函数 , 可以他添加到另外一个事件里
            private void Faxmsg(object sender, string s)
            {
                Console.WriteLine("event is called. " + s);
            }
            public virtual string Vc2() { return "virtual can be called."; }
            internal class VC2
            {
                public VC2()
                {
                    Console.WriteLine("internal called.");
                }
            }
        }

    }
}
