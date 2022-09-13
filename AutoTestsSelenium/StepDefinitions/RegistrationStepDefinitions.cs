using AutoTestsSelenium.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions
    {
        IWebDriver driver;
        RegistrationPage registrationPage;
        AuthorizationPage authorizationPage;

        [Given(@"Open registration page")]
        public void GivenOpenRegistrationPage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Urls.Host);
            authorizationPage = new AuthorizationPage(driver);
        }

        [Given(@"Click on registration on sidebar")]
        public void GivenClickOnRegistrationOnSidebar()
        {
            authorizationPage.ClickRegisterButton();
            registrationPage = new RegistrationPage(driver);
        }


        [Given(@"Fill all requared fields")]
        public void GivenFillAllRequaredFields(Table table)
        {
            RegisterRequest users = table.CreateInstance<RegisterRequest>();

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
