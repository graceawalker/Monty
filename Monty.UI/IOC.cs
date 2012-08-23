using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using Monty.Model.DAL;
using Monty.Repository;

namespace Monty.UI
{
    public static class IOC
    {
        public static IWindsorContainer RegisterComponents()
        {
            var container = new WindsorContainer().Install(FromAssembly.This());
            container.Register(Component.For<IRepository<Credit>>().ImplementedBy<CreditRepository>());
            container.Register(Component.For<IRepository<Debit>>().ImplementedBy<DebitRepository>());
            container.Register(Component.For<IRepository<Account>>().ImplementedBy<AccountRepository>());
            return container;

        }

    }
}
