using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPoolTest
{
    internal class FoolPooledObjectPolicy : IPooledObjectPolicy<Foo>
    {
        public Foo Create()
        {
            return new Foo();
        }

        public bool Return(Foo obj)
        {
            return true;
        }
    }
}