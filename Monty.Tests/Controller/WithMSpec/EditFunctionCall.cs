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

namespace Monty.Tests.Controller.WithMSpec
{
    [Subject(typeof(HomeController))]
    public class When_Edit_Action_Is_Called_with_credit
    {
        private static HomeController controller;
        private static Mock<IRepository<Credit>> _repo;

        private Establish context = () =>
        {
            _repo = new Mock<IRepository<Credit>>();
            _repo.Setup(r => r.GetById(Moq.It.IsAny<string>())).Returns(new Credit("Test", "12/12/2012", 20.00) );
            controller = new HomeController(_repo.Object, new Mock<IRepository<Debit>>().Object, new Mock<IRepository<Account>>().Object);
        };

        private It should_return_a_partialviewResult_with_a_credit = () =>
        {
            var result = controller.Edit("credit", "abc1234") as PartialViewResult;
            (result.Model as Credit).Amount.ShouldEqual(20.00);
        };

        private It should_call_repo = () =>
                                          {
                                              _repo.Verify(r=>r.GetById("abc1234"));
                                          };
    }

    [Subject(typeof(HomeController))]
    public class When_Edit_Action_Is_Called_with_debit
    {
        private static HomeController controller;
        private static Mock<IRepository<Debit>> _repo;

        private Establish context = () =>
        {
            _repo = new Mock<IRepository<Debit>>();
            _repo.Setup(r => r.GetById(Moq.It.IsAny<string>())).Returns(new Debit("Test", "12/12/2012", 20.00));
            controller = new HomeController(new Mock<IRepository<Credit>>().Object, _repo.Object, new Mock<IRepository<Account>>().Object);
        };

        private It should_return_a_partialviewResult_with_a_debit = () =>
        {
            var result = controller.Edit("debit", "abc1234") as PartialViewResult;
            (result.Model as Debit).Amount.ShouldEqual(20.00);
        };

        private It should_call_repo = () =>
        {
            _repo.Verify(r => r.GetById("abc1234"));
        };
    }

    [Subject(typeof(HomeController))]
    public class When_Edit_Action_Is_Called_with_account
    {
        private static HomeController controller;
        private static Mock<IRepository<Account>> _repo;

        private Establish context = () =>
        {
            _repo = new Mock<IRepository<Account>>();
            _repo.Setup(r => r.GetById(Moq.It.IsAny<string>())).Returns(new Account("hello"));
            controller = new HomeController(new Mock<IRepository<Credit>>().Object, new Mock<IRepository<Debit>>().Object, _repo.Object);
        };

        private It should_return_a_partialviewResult_with_a_debit = () =>
        {
            var result = controller.Edit("account", "abc1234") as PartialViewResult;
            (result.Model as Account).Name.ShouldEqual("hello");
        };

        private It should_call_repo = () =>
        {
            _repo.Verify(r => r.GetById("abc1234"));
        };
    }
}
