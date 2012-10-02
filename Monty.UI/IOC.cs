using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
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
            container.Register(Component.For<RepositoryType<Credit>>().ImplementedBy<CreditRepositoryType>().DependsOn(new Hashtable{ {"isTesting" , false}}));
            container.Register(Component.For<RepositoryType<Debit>>().ImplementedBy<DebitRepositoryType>().DependsOn(new Hashtable { { "isTesting", false } }));
            container.Register(Component.For<RepositoryType<Account>>().ImplementedBy<AccountRepositoryType>().DependsOn(new Hashtable { { "isTesting", false } }));
            return container;

        }

    }
}
