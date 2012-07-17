using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
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

        protected override void Given()
        {
            _payPeriodToSave = new PayPeriod("Test", "1/1/2012", "1/1/2012");
            _payPeriodRepo = new Mock<IPayPeriodRepository>();
            _controllerUnderTest = new PayPeriodController(_payPeriodRepo.Object);
        }

        protected override void When()
        {
            _controllerUnderTest.Save(new PayPeriodViewModel { PayPeriod = _payPeriodToSave });
        }

        [Test]
        public void Then()
        {
            _payPeriodRepo.Verify(p => p.AddNew(It.IsAny<PayPeriod>()));
        }


    }

    [TestFixture]
    public class When_Getting_Existing_PayPeriods : TestSetup
    {
        Mock<IPayPeriodRepository> _payPeriodRepo;
        PayPeriodController _controllerUnderTest;

        protected override void Given()
        {
            _payPeriodRepo = new Mock<IPayPeriodRepository>();
            _controllerUnderTest = new PayPeriodController(_payPeriodRepo.Object);
        }

        protected override void When()
        {     
            _controllerUnderTest.Existing();
        }

        [Test]
        public void Then()
        {
            _payPeriodRepo.Verify(p => p.GetAllPayPeriods());
        }


    }

    [TestFixture]
    public class When_existing_payperiod_is_edited : TestSetup
    {
        Mock<IPayPeriodRepository> _payPeriodRepo;
        PayPeriodController _controllerUnderTest;

        protected override void Given()
        {
            new PayPeriodRepository().ClearAllPayPeriods();
            _payPeriodRepo = new Mock<IPayPeriodRepository>();
            _controllerUnderTest = new PayPeriodController(_payPeriodRepo.Object);
        }

        protected override void When()
        {
            _controllerUnderTest.Existing("","","");
        }

        [Test]
        public void Then()
        {
            _payPeriodRepo.Verify(p => p.Update(It.IsAny<PayPeriod>()));
        }
    }

    [TestFixture]
    public class When_existing_payperiod_is_deleted : TestSetup
    {
        Mock<IPayPeriodRepository> _payPeriodRepo;
        PayPeriodController _controllerUnderTest;

        protected override void Given()
        {
            new PayPeriodRepository().ClearAllPayPeriods();
            _payPeriodRepo = new Mock<IPayPeriodRepository>();
            _controllerUnderTest = new PayPeriodController(_payPeriodRepo.Object);
        }

        protected override void When()
        {
            _controllerUnderTest.Delete(It.IsAny<string>());
        }

        [Test]
        public void Then()
        {
            _payPeriodRepo.Verify(p => p.DeleteById(It.IsAny<string>()));
        }
    }
}
