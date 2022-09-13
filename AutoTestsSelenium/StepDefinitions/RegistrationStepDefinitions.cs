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
        }


        [Given(@"Fill all requared fields")]
        public void GivenFillAllRequaredFields(Table table)
        {
            registrationPage = new RegistrationPage(driver);
            RegistrationRequest user = table.CreateInstance<RegistrationRequest>();
            registrationPage.EnterFirstName(user.FirstName);
            registrationPage.EnterLastName(user.LastName);
            registrationPage.EnterPatronymic(user.Patronymic);
            registrationPage.EnterBirthDate(user.BirthDate);
            registrationPage.EnterPassword(user.Password);
            registrationPage.EnterRepeatPassword(user.RepeatPassword);
            registrationPage.EnterEmail(user.Email);
            registrationPage.EnterPhone(user.PhoneNumber);

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
