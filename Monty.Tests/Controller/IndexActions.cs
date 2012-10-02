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
    public class When_Credit_Index_Action_Is_Called
    {
        private static CreditController controller;
        private static Mock<RepositoryType<Credit>> _repo;

        private Establish context = () =>
                                        {
                                            _repo = new Mock<RepositoryType<Credit>>();
                                            _repo.Setup(r => r.GetAll()).Returns(new List<Credit> { new Credit("Test", "12/12/2012", 20.00) });
                                            controller = new CreditController(_repo.Object);
                                        };

        private It should_return_a_viewResult_with_one_credit = () =>
                                                                    {
                                                                        var result = controller.Index() as ViewResult;
                                                                        (result.Model as IEnumerable<Credit>).Count().
                                                                            ShouldEqual(1);
                                                                    };

        private It should_call_repository_method = () =>
                                                       {
                                                           _repo.Verify(r => r.GetAll());
                                                       };
    }

    [Subject(typeof(DebitController))]
    public class When_Debit_Index_Action_Is_Called
    {
        private static DebitController controller;
        private static Mock<RepositoryType<Debit>> _repo;

        private Establish context = () =>
        {
            _repo = new Mock<RepositoryType<Debit>>();
            _repo.Setup(r => r.GetAll()).Returns(new List<Debit> { new Debit("Test", "12/12/2012", 20.00) });
            controller = new DebitController(_repo.Object);
        };

        private It should_return_a_viewResult_with_one_debit = () =>
        {
            var result = controller.Index() as ViewResult;
            (result.Model as IEnumerable<Debit>).Count().
                ShouldEqual(1);
        };

        private It should_call_repository_method = () =>
        {
            _repo.Verify(r => r.GetAll());
        };
    }

    

    [Subject(typeof(AccountController))]
    public class When_Account_Index_Action_Is_Called
    {
        private static AccountController controller;
        private static Mock<RepositoryType<Account>> _repo;

        private Establish context = () =>
        {
            _repo = new Mock<RepositoryType<Account>>();
            _repo.Setup(r => r.GetAll()).Returns(new List<Account> { new Account("Test") });
            controller = new AccountController(_repo.Object);
        };

        private It should_return_a_viewResult_with_one_account = () =>
        {
            var result = controller.Index() as ViewResult;
            (result.Model as IEnumerable<Account>).Count().
                ShouldEqual(1);
        };

        private It should_call_repository_method = () =>
        {
            _repo.Verify(r => r.GetAll());
        };
    }

  
}
