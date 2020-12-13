using Autofac;
using System;
using DITest;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DIAutofacTest
{
    public class Program
    {
        private static IContainer _container;

        private static void Main(string[] args)
        {
            SetupContainer();
            var userService = _container.Resolve<IUserService>();
            string name = userService.GetName();
            Console.WriteLine(name);
            Console.WriteLine("Hello World!");
        }

        private static void SetupContainer()
        {
            var builder = new ContainerBuilder();
            // 2.通过实现类暴露服务
            builder.RegisterType<UserService>();
            // 指定作用范围
            builder.RegisterType<UserService>().SingleInstance();

            // 3.需要传参的构造函数的类的注入
            builder.Register(c => new ConfigReader("c:/a.txt")).As<IConfigReader>();

            // 4.通过程序集注入
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(c => c.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            _container = builder.Build();
        }
    }
}