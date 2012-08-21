using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Monty.Model.DAL;
using Monty.UI.Controllers;
using NUnit.Framework;
using Shouldly;
using Moq;
using Monty.Repository;

namespace Monty.Tests.Controller
{
    [TestFixture]
    public class AccountCreditControllerTest: TestSetup
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

    public class AccountDebitControllerTest : TestSetup
    {
        private AccountDebitController _accountDebitController;
        private ViewResult _viewResult;
        private Mock<AccountDebitRepository> _repo;

        protected override void Given()
        {
            _repo = new Mock<AccountDebitRepository>();
            _repo.Setup(r => r.GetAllAccountDebits()).Returns(new List<AccountDebit> { new AccountDebit("Test", "12/12/2012") });
            _accountDebitController = new AccountDebitController(_repo.Object);
        }

        protected override void When()
        {
            _viewResult = _accountDebitController.Index() as ViewResult;
        }

        [Test]
        public void Should_navigate_to_debit_page()
        {
            (_viewResult.Model as IEnumerable<AccountDebit>).Count().ShouldBe(1);
        }
    }
}
