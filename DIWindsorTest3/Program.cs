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

            var interceptors = new List<IInterceptor>
            {
                    new Interceptor2(),
                    new Interceptor(),
            };

            var targetClas = new TargetClass();

            var target = generator.CreateInterfaceProxyWithTargetInterface<ITargetClass>(targetClas, interceptors.ToArray());

            var result = target.func1("123");
            System.Console.WriteLine("returned value: " + result);
        }
    }
}
