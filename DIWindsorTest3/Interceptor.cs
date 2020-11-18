using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIWindsorTest3
{
    public class Interceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Before  target call");
            if (invocation.Arguments.Length > 0 && invocation.Arguments[0].ToString().Equals("123"))
            {
                invocation.Arguments[0] = "456";
            }
            try
            {
                invocation.Proceed();
            }
            catch (Exception)
            {
                Console.WriteLine("Target threw an exception!");
            }
            finally
            {
                var result = invocation.ReturnValue;
                if (result is string)
                    invocation.ReturnValue = "789";
                Console.WriteLine("After target call");
            }
        }
    }
}
