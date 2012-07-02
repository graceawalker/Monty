using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Monty.Tests.Controller
{
    public abstract class TestSetup
    {
        public abstract void When();
        public abstract void Then();

        [SetUp]
        public void Setup()
        {
            IOC.RegisterComponents();
            When();
            Then();
        }
    }
}
