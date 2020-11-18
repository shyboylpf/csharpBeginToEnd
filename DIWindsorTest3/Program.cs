using Castle.DynamicProxy;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIWindsorTest3
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxyGenerator generator = new ProxyGenerator();

            var target = generator.CreateInterfaceProxyWithTarget<ITargetClass>(new TargetClass(), new Interceptor());

            var result = target.func1("123");
            System.Console.WriteLine("returned value: " + result);
        }
    }
}
