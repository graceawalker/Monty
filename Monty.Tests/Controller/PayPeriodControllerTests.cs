using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Monty.UI.Controllers;
using Moq;
using Monty.Repository;
using Monty.DAL;
using Monty.UI.Models.PayPeriodModels;

namespace Monty.Tests.Controller
{
    [TestFixture]
    public class When_Creating_New_Pay_Period : TestSetup
    {
        Mock<IPayPeriodRepository> _payPeriodRepo;
        PayPeriodController _controllerUnderTest;
        PayPeriod _payPeriodToSave;

        [Test]
        public override void When()
        {
            _payPeriodToSave = new PayPeriod("Test", "1/1/2012", "1/1/2012");
            _payPeriodRepo = new Mock<IPayPeriodRepository>();
            _controllerUnderTest = new PayPeriodController(_payPeriodRepo.Object);
            _controllerUnderTest.Save(new PayPeriodModel { PayPeriod = _payPeriodToSave });
        }

        [Test]
        public override void Then()
        {
            _payPeriodRepo.Verify(p => p.AddNew(It.IsAny<PayPeriod>()));
        }
    }

    [TestFixture]
    public class When_Getting_Existing_PayPeriods : TestSetup
    {
        Mock<IPayPeriodRepository> _payPeriodRepo;
        PayPeriodController _controllerUnderTest;
        PayPeriod _payPeriodToSave;

        [Test]
        public override void When()
        {
            _payPeriodRepo = new Mock<IPayPeriodRepository>();
            _controllerUnderTest = new PayPeriodController(_payPeriodRepo.Object);
            _controllerUnderTest.Existing();
        }

        [Test]
        public override void Then()
        {
            _payPeriodRepo.Verify(p => p.GetAllPayPeriods());
        }
    }
}
