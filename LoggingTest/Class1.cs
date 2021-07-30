using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingTest
{
    internal class Class1 : IClass1
    {
        public ILogger logger;

        public Class1(ILogger<Class1> logger)
        {
            this.logger = logger;
        }

        public void Run()
        {
            logger.LogInformation("Class1.Run");
        }
    }
}