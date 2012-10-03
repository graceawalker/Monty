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
    public class When_Delete_Account_Is_Called
    {
        private static AccountController _controller;
        private static Mock<RepositoryType<Account>> _repo;
        private static string _toDelete;

        private Establish context = () =>
                                        {
                                            _repo = new Mock<RepositoryType<Account>>();
                                            _controller = new AccountController(_repo.Object);
                                            _toDelete = "Id1234";
                                        };

        private It should_return_a_viewResult_with_one_credit = () =>
                                                                    {
                                                                        var result =
                                                                            _controller.Delete(_toDelete) as RedirectToRouteResult;
                                                                        result.RouteValues["Action"].ShouldBeTheSameAs("Index");
                                                                    };

        private It should_call_delete_in_repo = () =>
                                                    {
                                                        _repo.Verify(r => r.DeleteById("Id1234"));
                                                    };
    }

    [Subject(typeof(DebitController))]
    public class When_Delete_Debit_Is_Called
    {
        private static DebitController _controller;
        private static Mock<RepositoryType<Debit>> _repo;
        private static string _toDelete;

        private Establish context = () =>
        {
            _repo = new Mock<RepositoryType<Debit>>();
            _toDelete = "Id1234";
            _controller = new DebitController(_repo.Object);
        };

        private It should_return_a_viewResult_with_one_credit = () =>
        {
            var result =
                _controller.Delete(_toDelete) as RedirectToRouteResult;
            result.RouteValues["Action"].ShouldBeTheSameAs("Index");
        };

        private It should_call_delete_in_repo = () =>
        {
            _repo.Verify(r => r.DeleteById("Id1234"));
        };
    }

    [Subject(typeof(CreditController))]
    public class When_Delete_Credit_Is_Called
    {
        private static CreditController _controller;
        private static Mock<RepositoryType<Credit>> _repo;
        private static string _toDelete;

        private Establish context = () =>
        {
            _repo = new Mock<RepositoryType<Credit>>();
            _toDelete = "Id1234";
            _controller = new CreditController(_repo.Object);
        };

        private It should_return_a_viewResult_with_one_credit = () =>
        {
            var result =
                _controller.Delete(_toDelete) as RedirectToRouteResult;
            result.RouteValues["Action"].ShouldBeTheSameAs("Index");
        };

        private It should_call_delete_in_repo = () =>
        {
            _repo.Verify(r => r.DeleteById("Id1234"));
        };
    }
}
