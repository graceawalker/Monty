using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Monty.DAL;
using Monty.UI.Controllers;
using NUnit.Framework;
using Shouldly;
using Monty.UI.Models;
using Moq;
using Monty.Repository;

namespace Monty.Tests.Controller
{
    [TestFixture]
    public class ControllerTests: TestSetup
    {
        private AccountCreditController _accountCreditController;
        private ViewResult _viewResult;
        private Mock<AccountCreditRepository> _repo;

        protected override void Given()
        {
            _repo = new Mock<AccountCreditRepository>();
            _repo.Setup(r=>r.GetAllAccountCredits()).Returns(new List<AccountCredit>{new AccountCredit("Test","12/12/2012")});
            _accountCreditController = new AccountCreditController(_repo.Object);
        }

        protected override void When()
        {
           _viewResult = _accountCreditController.Index() as ViewResult;
        }

        [Test]
        public void Should_Navigate_To_Credit_Page()
        {
            (_viewResult.Model as IEnumerable<AccountCredit>).Count().ShouldBe(1);
        }

        [Test]
        public void Should_call_repo()
        {
            _repo.Verify(r=>r.GetAllAccountCredits());
        }
    }
}
