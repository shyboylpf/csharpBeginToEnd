using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace DIWindsorTest2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // create a windsor container object and register the interfaces, and their concrete inplementations.
            var container = new WindsorContainer();
            container.Register(Castle.MicroKernel.Registration.Component.For<ClassLibrary1.Main>());
            container.Register(Castle.MicroKernel.Registration.Component.For<ClassLibrary1.IDependency1>().ImplementedBy<ClassLibrary1.Dependency1>());
            container.Register(Castle.MicroKernel.Registration.Component.For<ClassLibrary1.IDependency2>().ImplementedBy<ClassLibrary1.Dependency2>());

            // create the main object and invoke its method(s) as desired.
            var mainThing = container.Resolve<ClassLibrary1.Main>();
            mainThing.DoSomething();
        }
    }
}
