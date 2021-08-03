using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingTest
{
    internal class Class2 : IClass2
    {
        private IClass1 class1;
        private ILogger logger;
        private readonly Service1 _service1;
        private readonly Service2 _service2;
        private readonly IService3 _service3;

        public Class2(
            IClass1 class1, ILogger<Class2> logger,
            Service1 service1, Service2 service2, IService3 service3)
        {
            this.class1 = class1;
            this.logger = logger;
            _service1 = service1;
            _service2 = service2;
            _service3 = service3;
        }

        public void Run()
        {
            class1.Run();
            _service1.Write("IndexModel.OnGet");
            _service2.Write("IndexModel.OnGet");
            _service3.Write("IndexModel.OnGet");
            logger.LogInformation("Class2.Run");
        }
    }
}