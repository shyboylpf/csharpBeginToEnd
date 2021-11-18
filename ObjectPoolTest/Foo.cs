using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPoolTest
{
    internal class Foo
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}