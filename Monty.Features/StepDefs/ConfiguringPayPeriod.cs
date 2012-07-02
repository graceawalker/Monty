using System;
using System.Collections.Generic;
using System.Linq;
using Monty.DAL;
using TechTalk.SpecFlow;
using Monty.Repository;
using Shouldly;

namespace Monty.Features.StepDefs
{
    [Binding]
    public class ConfiguringPayPeriod
    {
        PayPeriodRepository _payPeriodRepo;
        IEnumerable<PayPeriod> _currentPayPeriods;

        [Given(@"I have a new system with pay periods")]
        public void GivenIHaveANewSystemWithPayPeriods(Table table)
        {
            _payPeriodRepo = new PayPeriodRepository();
            _payPeriodRepo.ClearAllPayPeriods();

            foreach (var row in table.Rows)
            {
                var newPeriod = new PayPeriod(row["Name"], row["StartDate"], row["EndDate"]);
                _payPeriodRepo.AddNew(newPeriod);
            }
        }

        [When(@"I retrieve (.*) from the database")]
        public void WhenIRetrievePayPeriodFromTheDatabase(string payPeriodName)
        {
            _currentPayPeriods = new List<PayPeriod> { _payPeriodRepo.GetPayPeriodByName(payPeriodName) };
        }

        [Then(@"It should have details")]
        public void ThenItShouldHaveDetails(Table table)
        {
            var row = table.Rows[0];
            _currentPayPeriods.FirstOrDefault().Name.ShouldBe(row["Name"]);
            _currentPayPeriods.FirstOrDefault().StartDate.ShouldBe(Convert.ToDateTime(row["StartDate"]));
            _currentPayPeriods.FirstOrDefault().EndDate.ShouldBe(Convert.ToDateTime(row["EndDate"]));
        }

        [When(@"I retrieve all pay periods")]
        public void WhenIRetrieveAllPayPeriods()
        {
            _currentPayPeriods = _payPeriodRepo.GetAllPayPeriods();
        }


        [Then(@"They should have details")]
        public void ThenTheyShouldHaveDetails(Table table)
        {
            foreach (var row in table.Rows)
            {
                var newPeriod = new PayPeriod(row["Name"], row["StartDate"], row["EndDate"]);
                _currentPayPeriods.ShouldContain(i=>i.Name == newPeriod.Name);
                _currentPayPeriods.ShouldContain(i => i.StartDate== newPeriod.StartDate);
                _currentPayPeriods.ShouldContain(i => i.EndDate == newPeriod.EndDate);
            }
        }

        [When(@"I edit and save (.*) with details")]
        public void WhenIEditAndSavePayPeriodWithDetails(string name, Table table)
        {
            var payPeriod = _payPeriodRepo.GetPayPeriodByName(name);
            var row = table.Rows[0];
            payPeriod.Name = row["Name"];
            payPeriod.StartDate = Convert.ToDateTime(row["StartDate"]);
            payPeriod.EndDate = Convert.ToDateTime(row["EndDate"]);
            _payPeriodRepo.Update(payPeriod);
        }

        [When(@"I delete (.*)")]
        public void WhenIDelete(string name)
        {
            _payPeriodRepo.Delete(name);
        }

        [Then(@"The pay period database should be empty")]
        public void ThenThePayPeriodDatabaseShouldBeEmpty()
        {
            _payPeriodRepo.GetAllPayPeriods().Count().ShouldBe(0);
        }

    }
}
