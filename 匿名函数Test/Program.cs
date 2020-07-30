using System;

namespace 匿名函数Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //定义如上方法后，我们该如何调用呢？你要是会用lambda，那么此种方法调用自然不在话下
            Func<long, int> func = DefaultDelayInSecondsByAttemptFuncOne();
            Console.WriteLine(func(2));

            //第一眼看起来和第一种定义方式相差无几，我也是这么认为，那么调用该方法和第一种调用是一样的吗？默思一秒，答案：不一样
            int result = DefaultDelayInSecondsByAttemptFuncTwo(2);
            Console.WriteLine(result);
        }

        private static string Say()
        {
            return "Hello world";
        }

        private static string Say2() => "Hellow World!";

        //上述我们讲解了=>运算符和内置泛型委托，我们看到更多的是将委托作为方法参数来使用，将委托作为方法参数或返回值也是可行dei，比如如下：
        private static Func<long, int> DefaultDelayInSecondsByAttemptFuncOne()
        {
            return (attempt) =>
            {
                return (int)attempt;
            };
        }

        private static Func<long, int> DefaultDelayInSecondsByAttemptFuncOne2()
        {
            return delegate (long attempt)
            {
                return (int)attempt;
            };
        }

        private static readonly Func<long, int> DefaultDelayInSecondsByAttemptFuncTwo = attempt =>
           {
               return (int)attempt;
           };

        private static readonly Func<long, int> DefaultDelayInSecondsByAttemptFuncTwo2 = delegate (long attempt)
        {
            return (int)attempt;
        };
    }
}