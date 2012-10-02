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
    [Subject(typeof(CreditController))]
    public class When_Edit_Credit_Action_Is_Called_with_get
    {
        private static CreditController controller;
        private static Mock<RepositoryType<Credit>> _repo;

        private Establish context = () =>
        {
            _repo = new Mock<RepositoryType<Credit>>();
            _repo.Setup(r => r.GetById(Moq.It.IsAny<string>())).Returns(new Credit("Test", "12/12/2012", 20.00) );
            controller = new CreditController(_repo.Object);
        };

        private It should_return_a_partialviewResult_with_a_credit = () =>
        {
            var result = controller.Edit("abc1234") as PartialViewResult;
            (result.Model as Credit).Amount.ShouldEqual(20.00);
        };

        private It should_call_repo = () =>
                                          {
                                              _repo.Verify(r=>r.GetById("abc1234"));
                                          };
    }

    [Subject(typeof(CreditController))]
    public class When_Credit_Edit_Action_Is_Called_with_Post
    {
        private static CreditController controller;
        private static Mock<RepositoryType<Credit>> _repo;
        private static Credit _edited;

        private Establish context = () =>
        {
            _repo = new Mock<RepositoryType<Credit>>();
            _repo.Setup(r => r.GetAll()).Returns(new List<Credit> { new Credit("Test", "12/12/2012", 20.00) });
            _edited = new Credit("Test", "12/12/2012", 2.00);
            _edited.Id = "TestID";
            controller = new CreditController(_repo.Object);
        };

        private It should_return_a_viewResult_with_one_credit = () =>
        {
            var result = controller.Edit(_edited) as RedirectToRouteResult;
            result.RouteValues["Action"].ShouldBeTheSameAs("Index");
        };

        private It should_call_repository_method = () =>
        {
            _repo.Verify(r => r.Update(_edited));
        };
    }

    [Subject(typeof(DebitController))]
    public class When_Edit_Debit_Action_Is_Called_with_Get
    {
        private static DebitController controller;
        private static Mock<RepositoryType<Debit>> _repo;

        private Establish context = () =>
        {
            _repo = new Mock<RepositoryType<Debit>>();
            _repo.Setup(r => r.GetById(Moq.It.IsAny<string>())).Returns(new Debit("Test", "12/12/2012", 20.00));
            controller = new DebitController(_repo.Object);
        };

        private It should_return_a_partialviewResult_with_a_debit = () =>
        {
            var result = controller.Edit("abc1234") as PartialViewResult;
            (result.Model as Debit).Amount.ShouldEqual(20.00);
        };

        private It should_call_repo = () =>
        {
            _repo.Verify(r => r.GetById("abc1234"));
        };
    }

    [Subject(typeof(DebitController))]
    public class When_Debit_Edit_Action_Is_Called_with_Post
    {
        private static DebitController controller;
        private static Mock<RepositoryType<Debit>> _repo;
        private static Debit _edited;

        private Establish context = () =>
        {
            _repo = new Mock<RepositoryType<Debit>>();
            _repo.Setup(r => r.GetAll()).Returns(new List<Debit> { new Debit("Test", "12/12/2012", 20.00) });
            _edited = new Debit("Test", "12/12/2012", 2.00);
            _edited.Id = "TestID";
            controller = new DebitController(_repo.Object);
        };

        private It should_return_a_viewResult_with_one_credit = () =>
        {
            var result = controller.Edit(_edited) as RedirectToRouteResult;
            result.RouteValues["Action"].ShouldBeTheSameAs("Index");
        };

        private It should_call_repository_method = () =>
        {
            _repo.Verify(r => r.Update(_edited));
        };
    }

    [Subject(typeof(AccountController))]
    public class When_Edit_Account_Action_Is_Called_with_Get
    {
        private static AccountController controller;
        private static Mock<RepositoryType<Account>> _repo;

        private Establish context = () =>
        {
            _repo = new Mock<RepositoryType<Account>>();
            _repo.Setup(r => r.GetById(Moq.It.IsAny<string>())).Returns(new Account("hello"));
            controller = new AccountController(_repo.Object);
        };

        private It should_return_a_partialviewResult_with_a_debit = () =>
        {
            var result = controller.Edit("abc1234") as PartialViewResult;
            (result.Model as Account).Name.ShouldEqual("hello");
        };

        private It should_call_repo = () =>
        {
            _repo.Verify(r => r.GetById("abc1234"));
        };
    }

    [Subject(typeof(AccountController))]
    public class When_Account_Edit_Action_Is_Called_with_post
    {
        private static AccountController controller;
        private static Mock<RepositoryType<Account>> _repo;
        private static Account _edited;

        private Establish context = () =>
        {
            _repo = new Mock<RepositoryType<Account>>();
            _repo.Setup(r => r.GetAll()).Returns(new List<Account> { new Account("Test") });
            _edited = new Account("Test");
            _edited.Id = "TestID";
            controller = new AccountController(_repo.Object);
        };

        private It should_return_a_viewResult_with_one_credit = () =>
        {
            var result = controller.Edit(_edited) as RedirectToRouteResult;
            result.RouteValues["Action"].ShouldBeTheSameAs("Index");
        };

        private It should_call_repository_method = () =>
        {
            _repo.Verify(r => r.Update(_edited));
        };
    }
}
