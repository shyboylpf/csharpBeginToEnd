using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DITest
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var services = new ServiceCollection();

            // 1. 最常用的注入方式，以接口形式暴露服务
            // 两种注入方式是一个意思，这种方式适合实现类为无参构造函数或者有参构造函数中参数已经被注入过了。
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped<IUserService, UserService>();

            // 2. 自己注入自己，以实现形式暴露服务
            //这种注入方式适合只有实现类，没有接口类的注册。
            services.AddScoped<UserService>();
            services.AddScoped(typeof(UserService));

            // 3. 需要传参的构造函数的类的注入
            services.AddScoped<IConfigReader, ConfigReader>(x => { return new ConfigReader("c:/a.txt"); });
            services.AddScoped<IConfigReader>(x => { return new ConfigReader("c:/a.txt"); });

            services.AddScoped(typeof(IConfigReader), x => { return new ConfigReader("c:/a.txt"); });

            // 前两个匿名方法参数是IServiceProvider，返回值为一个实例，第三个返回值是Object。上面举的例子没有用到IServiceProvider ，下面再举一个例子。修改上面的UserService类，将构造方法需要一个IConfigReader参数。
            // 注册的时候，如下：
            services.AddScoped<IConfigReader, ConfigReader>(x => { return new ConfigReader("c:/a.txt"); });
            // 通过serviceProvider活去已经注册的IConfigReader
            services.AddScoped<IUserService, UserService>(x => { return new UserService(x.GetService<IConfigReader>()); });
            //或者
            services.AddScoped<IUserService, UserService>(x => { return new UserService(new ConfigReader("c:/a.txt")); });

            // 单例类型的生命周期多了两种注入方式：
            services.AddSingleton<IConfigReader>(new ConfigReader("c:/a.txt"));
            services.AddSingleton(typeof(IConfigReader), new ConfigReader("c:/a.txt"));

            // 自带的依赖注入工具也可以批量注入
            var assembly = Assembly.GetExecutingAssembly()
                .DefinedTypes
                .Where(a => a.Name.EndsWith("Service") && !a.Name.StartsWith("I"));
            foreach (var item in assembly)
            {
                services.AddTransient(item.GetInterfaces().FirstOrDefault(), item);
            }

            // 注意：当一个服务有多个实现时，调用的时候通过 IEnumerablePayServices 获取所有的实现服务。
            // 前面反射批量注入已经注入过了, 所以后面会出现四个, 别太担心
            services.AddScoped<IPayService, AliPayService>();
            services.AddScoped<IPayService, WechatPayService>();

            // 构建Provider
            var serviceProvider = services.BuildServiceProvider();

            // 注意：当一个服务有多个实现时，调用的时候通过 IEnumerablePayServices 获取所有的实现服务。
            // 下面是调用
            IPayServiceInvoke payServiceInvoke = new PayServiceInvoke(serviceProvider.GetServices<IPayService>());
            payServiceInvoke.PayAll();
        }
    }
}