using System;
using System.Linq;
using Monty.Model.DAL;
using Monty.Repository;
using Shouldly;
using NUnit.Framework;

namespace Monty.Tests
{
    [TestFixture]
    public class CreditRepositoryTests
    {
        private IRepository<Credit> _repo;

        [TestFixtureSetUp]
        public void SetupRepo()
        {
            _repo = new CreditRepository();
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
        public void Should_Get_All_Credits()
        {
            _repo.AddNew(new Credit("Test", "02/02/2012", 20.00));
            _repo.GetAll().Count().ShouldBe(1);
        }
        [Test]
        public void Should_get_account_credit_by_name()
        {
            _repo.AddNew(new Credit("Test", "02/02/2012", 20.00));
            _repo.GetByName("Test").Name.ShouldBe("Test");
        }

        [Test]
        public void Should_update_existing_account_credit()
        {
            _repo.AddNew(new Credit("Test", "03/01/2012", 20.00));
            var original = _repo.GetByName("Test");
            original.Name = "TestChange";
            original.Date = new DateTimeOffset(new DateTime(2012, 1, 1));
            original.Amount = 21.00;
            _repo.Update(original);
            var retrieved = _repo.GetByName("TestChange");
            retrieved.Date.ShouldBe(new DateTimeOffset(new DateTime(2012,1,1)));
            retrieved.Amount.ShouldBe(21.00);
            _repo.GetByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_delete_account_credit()
        {
            _repo.AddNew(new Credit("Test", "02/02/2012", 20.00));
            _repo.DeleteBy("Test");
            _repo.GetByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_delete_account_credit_by_id()
        {
            _repo.AddNew(new Credit("Test", "02/02/2012", 20.00));
            var id = _repo.GetByName("Test").Id;
            _repo.DeleteById(id);
            _repo.GetByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_get_account_credit_by_id()
        {
            _repo.AddNew(new Credit("Test", "02/02/2012", 20.00));
            var id = _repo.GetByName("Test").Id;
            var returned = _repo.GetById(id);
            returned.Name.ShouldBe("Test");
        }

    }
}
