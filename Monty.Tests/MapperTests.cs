using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monty.Tests;
using Monty.DAL;
using Monty.UI.Models.PayPeriodModels;
using Shouldly;
using NUnit.Framework;

namespace Monty.Tests
{
    public class MapperTests: TestSetup
    {
        private PayPeriod _payPeriod;
        private PayPeriodViewModel _payPeriodViewModel;

        protected override void Given()
        {
            _payPeriod = new PayPeriod();
            _payPeriodViewModel = new PayPeriodViewModel();
            _payPeriodViewModel.PayPeriod = _payPeriod;
        }

        protected override void When()
        {
            _payPeriodViewModel.PayPeriod = new PayPeriod("Test", "01/01/2012", "02/02/2012");
        }

        [Test]
        public void ItShouldMapTheNewPayPeriodToTheModel()
        {
            _payPeriodViewModel.PayPeriodModel.PayPeriodName.ShouldBe("Test");
        }
    }
}
