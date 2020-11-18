using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIWindsorTest3
{
    class Interceptor2 : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            Console.WriteLine("second intercept invocation result: " + invocation.ReturnValue.ToString());
        }
    }
}
