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
    public class CreditControllerTest: TestSetup
    {
        private CreditController _creditController;
        private ViewResult _viewResult;
        private Mock<IRepository<Credit>> _repo;

        protected override void Given()
        {
            _repo = new Mock<IRepository<Credit>>();
            _repo.Setup(r=>r.GetAll()).Returns(new List<Credit>{new Credit("Test","12/12/2012")});
            _creditController = new CreditController(_repo.Object);
        }

        protected override void When()
        {
           _viewResult = _creditController.Index() as ViewResult;
        }

        [Test]
        public void Should_Navigate_To_Credit_Page()
        {
            (_viewResult.Model as IEnumerable<Credit>).Count().ShouldBe(1);
        }

        [Test]
        public void Should_call_repo()
        {
            _repo.Verify(r=>r.GetAll());
        }
    }

    public class DebitControllerTest : TestSetup
    {
        private DebitController _debitController;
        private ViewResult _viewResult;
        private Mock<IRepository<Debit>> _repo;

        protected override void Given()
        {
            _repo = new Mock<IRepository<Debit>>();
            _repo.Setup(r => r.GetAll()).Returns(new List<Debit> { new Debit("Test", "12/12/2012") });
            _debitController = new DebitController(_repo.Object);
        }

        protected override void When()
        {
            _viewResult = _debitController.Index() as ViewResult;
        }

        [Test]
        public void Should_navigate_to_debit_page()
        {
            (_viewResult.Model as IEnumerable<Debit>).Count().ShouldBe(1);
        }

        [Test]
        public void Should_call_repo()
        {
            _repo.Verify(r => r.GetAll());
        }
    }
}
