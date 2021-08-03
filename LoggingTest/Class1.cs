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
        private readonly ILogger logger;

        private readonly TransientFaultHandlingOptions _options;

        public Class1(ILogger<Class1> logger, IOptions<TransientFaultHandlingOptions> options)
        {
            this.logger = logger;
            _options = options.Value;
        }

        public void Run()
        {
            logger.LogInformation("Class1.Run");
            logger.LogInformation($"TransientFaultHandlingOptions.Enabled={_options.Enabled}");
            logger.LogInformation($"TransientFaultHandlingOptions.AutoRetryDelay={_options.AutoRetryDelay}");
        }
    }
}