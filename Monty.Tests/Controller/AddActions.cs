using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Machine.Specifications;
using Monty.Model.DAL;
using Monty.Repository;
using Monty.UI.Controllers;
using Moq;
using It = Machine.Specifications.It;

namespace Monty.Tests.Controller
{
    [Subject(typeof(AccountController))]
    public class When_Add_Account_Is_Called_with_get
    {
        private static AccountController _controller;
        private static Mock<RepositoryType<Account>> _repo;

        private Establish context = () =>
        {
            _repo = new Mock<RepositoryType<Account>>();
            _repo.Setup(r => r.AddNew(Moq.It.IsAny<Account>())).Returns(new Account(""));
            _controller = new AccountController(_repo.Object);
        };

        private It should_return_a_viewResult_with_one_credit = () =>
        {
            var result = _controller.AddNew() as PartialViewResult;
            (result.Model as Account).Name.ShouldBeEmpty();
        };
    }

    [Subject(typeof(CreditController))]
    public class When_Add_Credit_Action_Is_Called_with_get
    {
        private static CreditController controller;
        private static Mock<RepositoryType<Credit>> _repo;

        private Establish context = () =>
        {
            _repo = new Mock<RepositoryType<Credit>>();
            _repo.Setup(r => r.AddNew(Moq.It.IsAny<Credit>())).Returns(new Credit("", "", 0));
            controller = new CreditController(_repo.Object);
        };

        private It should_return_a_partialviewResult_with_a_credit = () =>
        {
            var result = controller.AddNew() as PartialViewResult;
            (result.Model as Credit).Amount.ShouldEqual(0);
        };
    }

    [Subject(typeof(DebitController))]
    public class When_Add_Debit_Action_Is_Called_with_get
    {
        private static DebitController controller;
        private static Mock<RepositoryType<Debit>> _repo;

        private Establish context = () =>
        {
            _repo = new Mock<RepositoryType<Debit>>();
            _repo.Setup(r => r.AddNew(Moq.It.IsAny<Debit>())).Returns(new Debit("", "", 0));
            controller = new DebitController(_repo.Object);
        };

        private It should_return_a_partialviewResult_with_a_credit = () =>
        {
            var result = controller.AddNew() as PartialViewResult;
            (result.Model as Debit).Amount.ShouldEqual(0);
        };
    }
}
