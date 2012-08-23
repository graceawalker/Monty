using System;
using System.Linq;
using Monty.Model.DAL;
using Monty.Repository;
using Shouldly;
using NUnit.Framework;

namespace Monty.Tests
{
    [TestFixture]
    public class AccountRepositoryTests
    {
        private IRepository<Account> _repo;

        [TestFixtureSetUp]
        public void SetupRepo()
        {
            _repo = new AccountRepository();
        }

        [SetUp]
        public void ClearDb()
        {
            _repo.ClearAll();
        }

        [Test]
        public void Should_clear_all_data()
        {
            _repo.GetAll().Count().ShouldBe(0);
        }

        [Test]
        public void Should_Get_All_Accounts()
        {
            _repo.AddNew(new Account("Test"));
            _repo.GetAll().Count().ShouldBe(1);
        }

        [Test]
        public void Should_get_account_by_name()
        {
            _repo.AddNew(new Account("Test"));
            _repo.GetByName("Test").Name.ShouldBe("Test");
        }

        [Test]
        public void Should_update_existing_account()
        {
            _repo.AddNew(new Account("Test"));
            var original = _repo.GetByName("Test");
            original.Name = "TestChange";
            _repo.Update(original);
            _repo.GetByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_delete_account()
        {
            _repo.AddNew(new Account("Test"));
            _repo.DeleteBy("Test");
            _repo.GetByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_delete_account_by_id()
        {
            _repo.AddNew(new Account("Test"));
            var id = _repo.GetByName("Test").Id;
            _repo.DeleteById(id);
            _repo.GetByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_get_account_by_id()
        {
            _repo.AddNew(new Account("Test"));
            var id = _repo.GetByName("Test").Id;
            var returned = _repo.GetById(id);
            returned.Name.ShouldBe("Test");
        }
    }
}
