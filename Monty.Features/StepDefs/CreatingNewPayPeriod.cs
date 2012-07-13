using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coypu;
using Coypu.Drivers;
using Coypu.Drivers.Selenium;
using Monty.Repository;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Shouldly;

namespace Monty.Features.StepDefs
{
    [Binding]
    public class CreatingNewPayPeriod
    {
        private PayPeriodRepository _payPeriodRepo;
        BrowserSession _browser;
        [BeforeFeature]
        public static void SetupIOC()
        {
            IOC.RegisterComponents();
        }

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
            _browser.ClickLink(button);
        }

        [When(@"I create pay periods")]
        public void WhenICreatePayPeriods(Table table)
        {
            foreach (var row in table.Rows)
            {
                _browser.FillIn("PayPeriod.PayPeriodName").With(row["Name"]);
                _browser.FillIn("PayPeriod.StartDate").With(row["StartDate"]);
                _browser.FillIn("PayPeriod.EndDate").With(row["EndDate"]);
                _browser.ClickButton("Create");
            }
        }

        [Then(@"I should see (.*) in the existing pay periods")]
        public void ThenIShouldSeeJuneTestInTheExistingPayPeriods(string payPeriod)
        {
            Navigate("PayPeriod/Existing");
            _browser.HasContent(payPeriod).ShouldBe(true);
        }

        [When(@"I view existing pay periods")]
        public void WhenIViewExistingPayPeriods()
        {
            Navigate("PayPeriod/Existing");
        }

        [When(@"I edit (.*) to (.*)")]
        public void WhenIEdit(string payPeriod, string edit)
        {
            var element = _browser.FindAllCss(".payPeriod").FirstOrDefault(e => e.Text == payPeriod);
            _browser.FillIn(element).With(edit, true);
        }

        public void Navigate(string page)
        {
            if (_browser == null)
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
