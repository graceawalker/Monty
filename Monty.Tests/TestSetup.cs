using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Monty.Tests
{
    public abstract class TestSetup
    {
        protected abstract void Given();
        protected abstract void When();

        [SetUp]
        public void BeforeEachTest()
        {
            IOC.RegisterComponents();
            Given();
            When();
        }
    }
}
