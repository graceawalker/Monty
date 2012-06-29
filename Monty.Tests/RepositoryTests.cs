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
            var repo = new PayPeriodRepository();
            repo.ClearAllPayPeriods();
            repo.GetAllPayPeriods().Count().ShouldBe(0);
        }

        [Test]
        public void Should_Get_All_Payperiods()
        {
            var repo = new PayPeriodRepository();
            repo.ClearAllPayPeriods();
            repo.AddNew(new PayPeriod("Test", "02/02/2012", "01/01/2012"));
            repo.GetAllPayPeriods().Count().ShouldBe(1);
        }
        [Test]
        public void Should_get_pay_period_by_name()
        {
            var repo = new PayPeriodRepository();
            repo.ClearAllPayPeriods();
            repo.AddNew(new PayPeriod("Test", "02/02/2012", "01/01/2012"));
            repo.GetPayPeriodByName("Test").Name.ShouldBe("Test");
        }

        [Test]
        public void Should_update_existing_pay_period()
        {
            var repo = new PayPeriodRepository();
            repo.ClearAllPayPeriods();
            repo.AddNew(new PayPeriod("Test", "03/01/2012", "01/01/2012"));
            var original = repo.GetPayPeriodByName("Test");
            original.Name = "TestChange";
            original.StartDate = new DateTimeOffset(new DateTime(2012, 1, 1));
            original.EndDate = new DateTimeOffset(new DateTime(2012, 4, 4));
            repo.Update(original);
            var retrieved = repo.GetPayPeriodByName("TestChange");
            retrieved.StartDate.ShouldBe(new DateTimeOffset(new DateTime(2012,1,1)));
            retrieved.EndDate.ShouldBe(new DateTimeOffset(new DateTime(2012, 4, 4)));
            repo.GetPayPeriodByName("Test").ShouldBe(null);
        }

        [Test]
        public void Should_delete_pay_period()
        {
            var repo = new PayPeriodRepository();
            repo.ClearAllPayPeriods();
            repo.AddNew(new PayPeriod("Test", "02/02/2012", "02/02/2012"));
            repo.Delete("Test");
            repo.GetPayPeriodByName("Test").ShouldBe(null);
        }
    }
}
