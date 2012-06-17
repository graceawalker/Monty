using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            repo.AddNew(new PayPeriod("Test", "02/02/2012", "02/02/2012"));
            var original = repo.GetPayPeriodByName("Test");
            original.Name = "TestChange";
            original.StartDate = new DateTime(2012, 1, 1);
            original.EndDate = new DateTime(2012, 1, 1);
            repo.Update(original);
            var retrieved = repo.GetPayPeriodByName("TestChange");
            retrieved.StartDate.ToShortDateString().ShouldBe(new DateTime(2012,1,1).ToShortDateString());
            retrieved.EndDate.ToShortDateString().ShouldBe(new DateTime(2012, 1, 1).ToShortDateString());
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
