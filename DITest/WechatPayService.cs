using System;
using System.Collections.Generic;
using System.Text;

namespace DITest
{
    public class WechatPayService : IPayService
    {
        public void Pay()
        {
            Console.WriteLine("Wechat pay success");
        }
    }
}