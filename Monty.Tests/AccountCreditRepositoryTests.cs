using System;
using System.Linq;
using Monty.Model.DAL;
using Monty.Repository;
using Shouldly;
using NUnit.Framework;

namespace Monty.Tests
{
    [TestFixture]
    public class AccountCreditRepositoryTests
    {
        private AccountCreditRepository _repo;

        [SetUp]
        public void Setup_repo()
        {
            _repo = new AccountCreditRepository();
            _repo.ClearAllAccountCredits();
        }

        [Test]
        public void Should_clear_all_data()
        {
            _repo.GetAllAccountCredits().Count().ShouldBe(0);
        }

        [Test]
        public void Should_Get_All_AccountCredits()
        {
            _repo.AddNew(new AccountCredit("Test", "02/02/2012"));
            _repo.GetAllAccountCredits().Count().ShouldBe(1);
        }
        [Test]
        public void Should_get_account_credit_by_name()
        {
            _repo.AddNew(new AccountCredit("Test", "02/02/2012"));
            _repo.GetAccountCreditByName("Test").Name.ShouldBe("Test");
        }

        [Test]
        public void Should_update_existing_account_credit()
        {
            _repo.AddNew(new AccountCredit("Test", "03/01/2012"));
            var original = _repo.GetAccountCreditByName("Test");
            original.Name = "TestChange";
            original.Date = new DateTimeOffset(new DateTime(2012, 1, 1));
            _repo.Update(original);
            var retrieved = _repo.GetAccountCreditByName("TestChange");
            retrieved.Date.ShouldBe(new DateTimeOffset(new DateTime(2012,1,1)));
            _repo.GetAccountCreditByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_delete_account_credit()
        {
            _repo.AddNew(new AccountCredit("Test", "02/02/2012"));
            _repo.Delete("Test");
            _repo.GetAccountCreditByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_delete_account_credit_by_id()
        {
            _repo.AddNew(new AccountCredit("Test", "02/02/2012"));
            var id = _repo.GetAccountCreditByName("Test").Id;
            _repo.DeleteById(id);
            _repo.GetAccountCreditByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_get_account_credit_by_id()
        {
            _repo.AddNew(new AccountCredit("Test", "02/02/2012"));
            var id = _repo.GetAccountCreditByName("Test").Id;
            var returned = _repo.GetAccountCreditById(id);
            returned.Name.ShouldBe("Test");
        }
    }
}
