using System;
using System.Linq;
using Monty.Model.DAL;
using Monty.Repository;
using Shouldly;
using NUnit.Framework;

namespace Monty.Tests
{
    [TestFixture]
    public class DebitRepositoryTests
    {
        private DebitRepository _repo;

        [SetUp]
        public void SetupRepo()
        {
            _repo = new DebitRepository();
            _repo.ClearAllDebits();
        }

        [Test]
        public void Should_clear_all_data()
        {
            _repo.GetAllDebits().Count().ShouldBe(0);
        }

        [Test]
        public void Should_Get_All_Debits()
        {
            _repo.AddNew(new Debit("Test", "02/02/2012"));
            _repo.GetAllDebits().Count().ShouldBe(1);
        }
        [Test]
        public void Should_get_account_debit_by_name()
        {
            _repo.AddNew(new Debit("Test", "02/02/2012"));
            _repo.GetDebitByName("Test").Name.ShouldBe("Test");
        }

        [Test]
        public void Should_update_existing_account_debit()
        {
            _repo.AddNew(new Debit("Test", "03/01/2012"));
            var original = _repo.GetDebitByName("Test");
            original.Name = "TestChange";
            original.Date = new DateTimeOffset(new DateTime(2012, 1, 1));
            _repo.Update(original);
            var retrieved = _repo.GetDebitByName("TestChange");
            retrieved.Date.ShouldBe(new DateTimeOffset(new DateTime(2012,1,1)));
            _repo.GetDebitByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_delete_account_debit()
        {
            _repo.AddNew(new Debit("Test", "02/02/2012"));
            _repo.Delete("Test");
            _repo.GetDebitByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_delete_account_debit_by_id()
        {
            _repo.AddNew(new Debit("Test", "02/02/2012"));
            var id = _repo.GetDebitByName("Test").Id;
            _repo.DeleteById(id);
            _repo.GetDebitByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_get_account_debit_by_id()
        {
            _repo.AddNew(new Debit("Test", "02/02/2012"));
            var id = _repo.GetDebitByName("Test").Id;
            var returned = _repo.GetDebitById(id);
            returned.Name.ShouldBe("Test");
        }
    }
}
