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
        private CreditRepository _repo;

        [SetUp]
        public void Setup_repo()
        {
            _repo = new CreditRepository();
            _repo.ClearAllCredits();
        }

        [Test]
        public void Should_clear_all_data()
        {
            _repo.GetAllCredits().Count().ShouldBe(0);
        }

        [Test]
        public void Should_Get_All_Credits()
        {
            _repo.AddNew(new Credit("Test", "02/02/2012"));
            _repo.GetAllCredits().Count().ShouldBe(1);
        }
        [Test]
        public void Should_get_account_credit_by_name()
        {
            _repo.AddNew(new Credit("Test", "02/02/2012"));
            _repo.GetCreditByName("Test").Name.ShouldBe("Test");
        }

        [Test]
        public void Should_update_existing_account_credit()
        {
            _repo.AddNew(new Credit("Test", "03/01/2012"));
            var original = _repo.GetCreditByName("Test");
            original.Name = "TestChange";
            original.Date = new DateTimeOffset(new DateTime(2012, 1, 1));
            _repo.Update(original);
            var retrieved = _repo.GetCreditByName("TestChange");
            retrieved.Date.ShouldBe(new DateTimeOffset(new DateTime(2012,1,1)));
            _repo.GetCreditByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_delete_account_credit()
        {
            _repo.AddNew(new Credit("Test", "02/02/2012"));
            _repo.Delete("Test");
            _repo.GetCreditByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_delete_account_credit_by_id()
        {
            _repo.AddNew(new Credit("Test", "02/02/2012"));
            var id = _repo.GetCreditByName("Test").Id;
            _repo.DeleteById(id);
            _repo.GetCreditByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_get_account_credit_by_id()
        {
            _repo.AddNew(new Credit("Test", "02/02/2012"));
            var id = _repo.GetCreditByName("Test").Id;
            var returned = _repo.GetCreditById(id);
            returned.Name.ShouldBe("Test");
        }
    }
}
