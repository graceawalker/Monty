using System;
using System.Linq;
using Monty.DAL;
using Monty.Repository;
using Shouldly;
using NUnit.Framework;

namespace Monty.Tests
{
    [TestFixture]
    public class RepositoryTests
    {

        [Test]
        public void Should_clear_all_data()
        {
            var repo = new AccountCreditRepository();
            repo.ClearAllAccountCredits();
            repo.GetAllAccountCredits().Count().ShouldBe(0);
        }

        [Test]
        public void Should_Get_All_AccountCredits()
        {
            var repo = new AccountCreditRepository();
            repo.ClearAllAccountCredits();
            repo.AddNew(new AccountCredit("Test", "02/02/2012"));
            repo.GetAllAccountCredits().Count().ShouldBe(1);
        }
        [Test]
        public void Should_get_account_credit_by_name()
        {
            var repo = new AccountCreditRepository();
            repo.ClearAllAccountCredits();
            repo.AddNew(new AccountCredit("Test", "02/02/2012"));
            repo.GetAccountCreditByName("Test").Name.ShouldBe("Test");
        }

        [Test]
        public void Should_update_existing_account_credit()
        {
            var repo = new AccountCreditRepository();
            repo.ClearAllAccountCredits();
            repo.AddNew(new AccountCredit("Test", "03/01/2012"));
            var original = repo.GetAccountCreditByName("Test");
            original.Name = "TestChange";
            original.Date = new DateTimeOffset(new DateTime(2012, 1, 1));
            repo.Update(original);
            var retrieved = repo.GetAccountCreditByName("TestChange");
            retrieved.Date.ShouldBe(new DateTimeOffset(new DateTime(2012,1,1)));
            repo.GetAccountCreditByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_delete_account_credit()
        {
            var repo = new AccountCreditRepository();
            repo.ClearAllAccountCredits();
            repo.AddNew(new AccountCredit("Test", "02/02/2012"));
            repo.Delete("Test");
            repo.GetAccountCreditByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_delete_account_credit_by_id()
        {
            var repo = new AccountCreditRepository();
            repo.ClearAllAccountCredits();
            repo.AddNew(new AccountCredit("Test", "02/02/2012"));
            var id = repo.GetAccountCreditByName("Test").Id;
            repo.DeleteById(id);
            repo.GetAccountCreditByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_get_account_credit_by_id()
        {
            var repo = new AccountCreditRepository();
            repo.ClearAllAccountCredits();
            repo.AddNew(new AccountCredit("Test", "02/02/2012"));
            var id = repo.GetAccountCreditByName("Test").Id;
            var returned = repo.GetAccountCreditById(id);
            returned.Name.ShouldBe("Test");
        }
    }
}
