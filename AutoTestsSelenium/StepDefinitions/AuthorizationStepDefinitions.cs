using AutoTestsSelenium.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class AuthorizationStepDefinitions
    {
        IWebDriver driver;
        AuthorizationUnauthorizedPage loginPage;

        [Given(@"Open login page")]
        public void GivenOpenLoginPage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl($"https://piter-education.ru:7074/login");
            loginPage=new AuthorizationUnauthorizedPage(driver);
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
