using System;
using System.Collections.Generic;
using System.Text;

namespace DITest
{
    public class PayServiceInvoke : IPayServiceInvoke
    {
        private IEnumerable<IPayService> _payServices;

        public PayServiceInvoke(IEnumerable<IPayService> payServices)
        {
            _payServices = payServices;
        }

        public void PayAll()
        {
            foreach (var payService in _payServices)
            {
                payService.Pay();
            }
        }
    }
}