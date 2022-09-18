namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions
    {
        private IWebDriver _driver;
        private RegistrationPage _registrationPage;
        private AuthorizationUnauthorizedPage _authorizationUnauthorizedPage;
        private ProfilePage _profilePage;
        private SwaggerSignInRequest _SignInRequest;
        private RegistrationRequest _user;

        public RegistrationStepDefinitions()
        {
            _driver = new ChromeDriver();
            _registrationPage = new RegistrationPage(_driver);
            _authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage(_driver);
            _profilePage = new ProfilePage(_driver);
        }

        [Given(@"Open registration page")]
        public void GivenOpenRegistrationPage()
        {
            _driver.Manage().Window.Maximize();
            _registrationPage.OpenThisPage();
            _registrationPage.ClickRegisterButton();
        }

        [Given(@"Fill all requared fields")]
        public void GivenFillAllRequaredFields(Table table)
        {
            _user = table.CreateInstance<RegistrationRequest>();
            _registrationPage.EnterFirstName(_user.FirstName);
            _registrationPage.EnterLastName(_user.LastName);
            _registrationPage.EnterPatronymic(_user.Patronymic);
            _registrationPage.EnterBirthDate(_user.BirthDate);
            _registrationPage.EnterPassword(_user.Password);
            _registrationPage.EnterRepeatPassword(_user.RepeatPassword);
            _registrationPage.EnterEmail(_user.Email);
            _registrationPage.EnterPhone(_user.PhoneNumber);
            _SignInRequest = new SwaggerSignInRequest()
            {
                Email = _user.Email,
                Password = _user.Password
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
            Thread.Sleep(500);
            Assert.NotNull(_registrationPage.ModalWindowWelcome);
        }

        [When(@"Click on athorization sidebar button")]
        [Then(@"Click on athorization sidebar button")]
        public void WhenClickOnAthorizationSidebarButton()
        {
            _authorizationUnauthorizedPage.ClickEnterSideBarButton();
        }

        [Then(@"Authorize user in service")]
        [When(@"Authorize user in service")]
        public void WhenAuthorizeUserInService()
        {
            Thread.Sleep(200);
            _authorizationUnauthorizedPage.EnterEmail(_SignInRequest.Email);
            _authorizationUnauthorizedPage.EnterPassword(_SignInRequest.Password);
            _authorizationUnauthorizedPage.ClickEnterButton();
        }

        [When(@"Click on user's profile")]
        [Then(@"Click on user's profile")]
        public void WhenClickOnUsersProfile()
        {
            Thread.Sleep(200);
            _profilePage.ClickNameButton();
        }

        [Then(@"User should see his actual information")]
        public void ThenUserShouldSeeHisActualInformation()
        {
            string attributeName = "value";
            RegistrationRequest actualUser = new RegistrationRequest()
            {
                LastName = _profilePage.TextBoxEnterLastName.GetAttribute(attributeName),
                FirstName = _profilePage.TextBoxEnterFirstName.GetAttribute(attributeName),
                Patronymic = _profilePage.TextBoxEnterPatronymic.GetAttribute(attributeName), 
                BirthDate = _profilePage.TextBoxEnterBirthDate.GetAttribute(attributeName),
                Password = _user.Password,
                RepeatPassword = _user.RepeatPassword,
                Email = _profilePage.TextBoxEmail.GetAttribute(attributeName), 
                PhoneNumber = _profilePage.TextBoxEnterPhone.GetAttribute(attributeName)
            };
            Assert.Equivalent(_user, actualUser);
            _driver.Close();
        }
    }
}
