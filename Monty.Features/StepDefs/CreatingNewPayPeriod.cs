using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coypu;
using Coypu.Drivers;
using Monty.Repository;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Shouldly;

namespace Monty.Features.StepDefs
{
    [Binding]
    public class CreatingNewPayPeriod
    {
        private PayPeriodRepository _payPeriodRepo;
        BrowserSession _browser;

        [Given(@"I have a new system with no pay periods")]
        public void GivenIHaveANewSystemWithNoPayPeriods()
        {
            _payPeriodRepo = new PayPeriodRepository();
            _payPeriodRepo.ClearAllPayPeriods();
        }

        [Given(@"I launch Monty")]
        public void GivenILaunchMonty()
        {
            Navigate("Home");
        }

        [When(@"I click (.*)")]
        [Given(@"I click (.*)")]
        public void GivenIClickNew(string button)
        {
            _browser.ClickButton(button);
        }

        [When(@"I create pay period")]
        public void WhenICreatePayPeriod(Table table)
        {
            foreach (var row in table.Rows)
            {
                _browser.FillIn("Name").With(row["Name"]);
                _browser.FillIn("StartDate").With(row["StartDate"]);
                _browser.FillIn("EndDate").With(row["EndDate"]);
                _browser.ClickButton("Save");
            }
        }

        [Then(@"I should see (.*) in the existing pay periods")]
        public void ThenIShouldSeeJuneTestInTheExistingPayPeriods(string payPeriod)
        {
            _payPeriodRepo.GetPayPeriodByName(payPeriod).ShouldNotBe(null);
        }

        public void Navigate(string page)
        {
            _browser = new BrowserSession(new SessionConfiguration { AppHost = "localhost", Port = 99 });
            _browser.Visit(page);
            if (_browser.HasContent("HTTP 404")) Assert.Fail("Page {0} does not exist", page);
        }

        [AfterScenario]
        public void End()
        {
            if (_browser != null)
                _browser.Dispose();
        }
    }
}
