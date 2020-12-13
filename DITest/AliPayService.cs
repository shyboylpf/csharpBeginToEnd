using System;
using System.Collections.Generic;
using System.Text;

namespace DITest
{
    public class AliPayService : IPayService
    {
        public void Pay()
        {
            Console.WriteLine("Ali pay success");
        }
    }
}