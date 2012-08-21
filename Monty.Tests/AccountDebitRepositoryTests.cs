using System;
using System.Linq;
using Monty.Model.DAL;
using Monty.Repository;
using Shouldly;
using NUnit.Framework;

namespace Monty.Tests
{
    [TestFixture]
    public class AccountDebitRepositoryTests
    {
        private AccountDebitRepository _repo;

        [SetUp]
        public void SetupRepo()
        {
            _repo = new AccountDebitRepository();
            _repo.ClearAllAccountDebits();
        }

        [Test]
        public void Should_clear_all_data()
        {
            _repo.GetAllAccountDebits().Count().ShouldBe(0);
        }

        [Test]
        public void Should_Get_All_AccountDebits()
        {
            _repo.AddNew(new AccountDebit("Test", "02/02/2012"));
            _repo.GetAllAccountDebits().Count().ShouldBe(1);
        }
        [Test]
        public void Should_get_account_debit_by_name()
        {
            _repo.AddNew(new AccountDebit("Test", "02/02/2012"));
            _repo.GetAccountDebitByName("Test").Name.ShouldBe("Test");
        }

        [Test]
        public void Should_update_existing_account_debit()
        {
            _repo.AddNew(new AccountDebit("Test", "03/01/2012"));
            var original = _repo.GetAccountDebitByName("Test");
            original.Name = "TestChange";
            original.Date = new DateTimeOffset(new DateTime(2012, 1, 1));
            _repo.Update(original);
            var retrieved = _repo.GetAccountDebitByName("TestChange");
            retrieved.Date.ShouldBe(new DateTimeOffset(new DateTime(2012,1,1)));
            _repo.GetAccountDebitByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_delete_account_debit()
        {
            _repo.AddNew(new AccountDebit("Test", "02/02/2012"));
            _repo.Delete("Test");
            _repo.GetAccountDebitByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_delete_account_debit_by_id()
        {
            _repo.AddNew(new AccountDebit("Test", "02/02/2012"));
            var id = _repo.GetAccountDebitByName("Test").Id;
            _repo.DeleteById(id);
            _repo.GetAccountDebitByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_get_account_debit_by_id()
        {
            _repo.AddNew(new AccountDebit("Test", "02/02/2012"));
            var id = _repo.GetAccountDebitByName("Test").Id;
            var returned = _repo.GetAccountDebitById(id);
            returned.Name.ShouldBe("Test");
        }
    }
}
