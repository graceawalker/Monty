using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using Monty.Repository;

namespace Monty
{
    public static class IOC
    {
        public static IWindsorContainer RegisterComponents()
        {
            var container = new WindsorContainer()
    .Install(FromAssembly.This());
            container.Register(
                Component.For<ICreditRepository>()
                    .ImplementedBy<CreditRepository>());

            return container;
        }

    }
}
