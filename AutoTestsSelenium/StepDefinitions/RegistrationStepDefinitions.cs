namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions
    {
        private IWebDriver _driver;
        private RegistrationPage _registrationPage;
        private SwaggerSignInRequest _SignInRequest;

        [Given(@"Open registration page")]
        public void GivenOpenRegistrationPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _registrationPage = new RegistrationPage(_driver);
            _registrationPage.OpenThisPage();
            _registrationPage.ClickRegisterButton();
        }

        [Given(@"Fill all requared fields")]
        public void GivenFillAllRequaredFields(Table table)
        {
            RegistrationRequest user = table.CreateInstance<RegistrationRequest>();
            _registrationPage.EnterFirstName(user.FirstName);
            _registrationPage.EnterLastName(user.LastName);
            _registrationPage.EnterPatronymic(user.Patronymic);
            _registrationPage.EnterBirthDate(user.BirthDate);
            _registrationPage.EnterPassword(user.Password);
            _registrationPage.EnterRepeatPassword(user.RepeatPassword);
            _registrationPage.EnterEmail(user.Email);
            _registrationPage.EnterPhone(user.PhoneNumber);
            _SignInRequest = new SwaggerSignInRequest()
            {
                Email = user.Email,
                Password = user.Password
            };

        }

        [Given(@"Click on private policy checkbox")]
        public void GivenClickOnPrivatePolicyCheckbox()
        {
            _registrationPage.ClickOnConfirmRulesCheckBox();
        }

        [When(@"Click on register button")]
        public void WhenClickOnRegisterButton()
        {
            _registrationPage.ClickOnButtonRegistrate();
        }

        [Then(@"User should see the welcome modal window")]
        public void ThenUserShouldSeeTheWelcomeModalWindow()
        {
            Assert.NotNull(_registrationPage.ModalWindowWelcome);
        }


        [When(@"Click on athorization sidebar button")]
        public void WhenClickOnAthorizationSidebarButton()
        {
            throw new PendingStepException();
        }

        [When(@"Authorize user in service")]
        public void WhenAuthorizeUserInService()
        {
            throw new PendingStepException();
        }

        [When(@"Click on user's profile")]
        public void WhenClickOnUsersProfile()
        {
            throw new PendingStepException();
        }

        [Then(@"User should see his actual information")]
        public void ThenUserShouldSeeHisActualInformation()
        {
            throw new PendingStepException();
        }

    }
}
