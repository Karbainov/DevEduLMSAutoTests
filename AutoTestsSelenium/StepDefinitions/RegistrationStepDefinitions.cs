using AutoTestsSelenium.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions
    {
        IWebDriver driver;
        LoginPage loginPage;

        [Given(@"Open registration page")]
        public void GivenOpenRegistrationPage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl();
            loginPage = new LoginPage(driver);
        }

        [Given(@"Fill all requared fields")]
        public void GivenFillAllRequaredFields(Table table)
        {
            throw new PendingStepException();
        }

        [Given(@"Click on private policy checkbox")]
        public void GivenClickOnPrivatePolicyCheckbox()
        {
            throw new PendingStepException();
        }

        [When(@"Click on register button")]
        public void WhenClickOnRegisterButton()
        {
            throw new PendingStepException();
        }
    }
}
