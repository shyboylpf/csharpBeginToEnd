using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleDITest
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // application starts...
            var container = new WindsorContainer();

            // adds and configures all components using WindsorInstallers from executing assembly
            container.Install(FromAssembly.This());

            // instantiate and configure root component and all its dependencies and their dependencies and...
            var king = container.Resolve<IKing>();
            king.RuleTheCastle();

            // clean up, application exits
            container.Dispose();
        }
    }

    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .Where(Component.IsInSameNamespaceAs<King>())
                .WithService.DefaultInterfaces()
                .LifestyleTransient());
        }
    }

    public interface IKing
    {
        void RuleTheCastle();
    }

    public class King : IKing
    {
        public void RuleTheCastle()
        {
            Console.WriteLine(1111111111);
        }
    }
}