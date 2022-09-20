using AutoTestsSelenium.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class AuthorizationStepDefinitions
    {
        private IWebDriver _driver;
        AuthorizationUnauthorizedPage loginPage;

        [Given(@"Open login page")]
        public void GivenOpenLoginPage()
        {
            _driver = SingleWebDriver.GetInstance();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl($"https://piter-education.ru:7074/login");
            loginPage=new AuthorizationUnauthorizedPage(_driver);
        }

        [When(@"Enter ""([^""]*)"" and ""([^""]*)""")]
        public void WhenEnterAnd(string email, string password)
        {
            
            loginPage.EnterEmail(email);
            loginPage.EnterPassword(password);
            loginPage.ClickEnterButton();
        }

        [Then(@"Incerrect email text should apier")]
        public void ThenIncerrectEmailTextShouldApier()
        {

        }

        [Then(@"Incerrect email or password text should apier")]
        public void ThenIncerrectEmailOrPasswordTextShouldApier()
        {
            throw new PendingStepException();
        }
    }
}
