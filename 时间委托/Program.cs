using System;
using System.Threading;
namespace 事件委托
{
    class Program
    {
        static void Main(string[] args)
        {
            shuixiang shuixiang1 = new shuixiang(10);
            jiashuiqi jiashuiqi1 = new jiashuiqi();
            jingbaoqi jingbaoqi1 = new jingbaoqi();
            shuixiang1.shuixiangkong += jiashuiqi1.jiashui;
            shuixiang1.shuixiangkong += jingbaoqi1.baojing;
            //shuixiang1.tiji = 10;
            while (true)
            {
                Thread.Sleep(1000);
                shuixiang1.fangshui();
                if (shuixiang1.tiji <= 0)
                {
                    //shuixiang1.jiashui();
                    shuixiang1.shuixiangkongle();
                    //break;
                }
            }
        }
    }

    public class shuixiang
    {
        public shuixiang(int v)
        {
            tiji = v;
        }
        public void fangshui() { tiji -= 1; Console.WriteLine($"水量-1  当前水量{tiji}"); }
        public void jiashui() { tiji = 10; Console.WriteLine($"老子给你加满水哦.{tiji}"); }
        public double tiji;
        public event EventHandler shuixiangkong;
        public void shuixiangkongle()
        {
            shuixiangkong(this, new EventArgs());
        }
        ~shuixiang()
        {
            Console.WriteLine("水箱呗扔了");
        }
    }

    public class jiashuiqi
    {
        public void jiashui(object sender, EventArgs e)
        {
            shuixiang shuixaing1 = sender as shuixiang;
            shuixaing1.tiji = 10;
            Console.WriteLine(sender.ToString() + e.ToString() + "我要给你加水咯!");
        }
    }

    public class jingbaoqi
    {
        public void baojing(object sender, EventArgs e)
        {
            Console.WriteLine("水箱没水了, 没水了 , 真的没水了!!");
        }
    }
}
