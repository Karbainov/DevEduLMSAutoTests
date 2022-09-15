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
        AuthorizationUnauthorizedPage authorizationPage;
        SingInRequest singInModel;

        [Given(@"Open registration page")]
        public void GivenOpenRegistrationPage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Urls.Host);
            authorizationPage = new AuthorizationUnauthorizedPage(driver);
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
            singInModel = new SingInRequest()
            {
                Email = user.Email,
                Password = user.Password
            };

        }

        [Given(@"Click on private policy checkbox")]
        public void GivenClickOnPrivatePolicyCheckbox()
        {
            registrationPage.ClickOnConfirmRulesCheckBox();
        }

        [When(@"Click on register button")]
        public void WhenClickOnRegisterButton()
        {
            registrationPage.ClickOnButtonRegistrate();
        }

        [When(@"Click on athorization sidebar button")]
        public void WhenClickOnAthorizationSidebarButton()
        {
            registrationPage.ClickOnAuthSideBarButton();
        }

        [When(@"Authorize user in service")]
        public void WhenAuthorizeUserInService()
        {
           authorizationPage = new AuthorizationUnauthorizedPage(driver);
            authorizationPage.EnterEmail(singInModel.Email);
            authorizationPage.EnterPassword(singInModel.Password);
            authorizationPage.ClickEnterButton();
        }

        [When(@"click on user's profile")]
        public void WhenClickOnUsersProfile()
        {
            throw new PendingStepException();
        }

        [Then(@"user should see his actual information")]
        public void ThenUserShouldSeeHisActualInformation()
        {
            throw new PendingStepException();
        }

    }
}
