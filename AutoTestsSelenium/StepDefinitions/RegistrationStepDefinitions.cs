namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions
    {
        private SwaggerSignInRequest _SignInRequest;
        private RegistrationModel _user;

        public RegistrationStepDefinitions()
        {
        }

        [Given(@"Open registration page")]
        public void GivenOpenRegistrationPage()
        {
            RegistrationPage registrationPage = new RegistrationPage();
            registrationPage.OpenThisPage();
            registrationPage.ClickRegisterButton();
        }

        [Given(@"Fill all requared fields")]
        public void GivenFillAllRequaredFields(Table table)
        {
            RegistrationPage registrationPage = new RegistrationPage();
            _user = table.CreateInstance<RegistrationRequest>();
            registrationPage.EnterFirstName(_user.FirstName);
            registrationPage.EnterLastName(_user.LastName);
            registrationPage.EnterPatronymic(_user.Patronymic);
            registrationPage.EnterBirthDate(_user.BirthDate);
            registrationPage.EnterPassword(_user.Password);
            registrationPage.EnterRepeatPassword(_user.RepeatPassword);
            registrationPage.EnterEmail(_user.Email);
            registrationPage.EnterPhone(_user.PhoneNumber);
            _SignInRequest = new SwaggerSignInRequest()
            {
                Email = _user.Email,
                Password = _user.Password
            };
        }

        [Given(@"Click on private policy checkbox")]
        public void GivenClickOnPrivatePolicyCheckbox()
        {
            RegistrationPage registrationPage = new RegistrationPage();
            registrationPage.ClickOnConfirmRulesCheckBox();
        }

        [When(@"Click on register button")]
        public void WhenClickOnRegisterButton()
        {
            RegistrationPage registrationPage = new RegistrationPage();
            registrationPage.ClickOnButtonRegistrate();
        }

        [Then(@"User should see the welcome modal window")]
        public void ThenUserShouldSeeTheWelcomeModalWindow()
        {
            RegistrationPage registrationPage = new RegistrationPage();
            Thread.Sleep(500);
            Assert.NotNull(registrationPage.ModalWindowWelcome);
        }

        [When(@"Click on athorization sidebar button")]
        [Then(@"Click on athorization sidebar button")]
        public void WhenClickOnAthorizationSidebarButton()
        {
            AuthorizationUnauthorizedPage authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage();
            authorizationUnauthorizedPage.ClickEnterSideBarButton();
        }

        [Then(@"Authorize user in service")]
        [When(@"Authorize user in service")]
        public void WhenAuthorizeUserInService()
        {
            AuthorizationUnauthorizedPage authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage();
            Thread.Sleep(200);
            authorizationUnauthorizedPage.EnterEmail(_SignInRequest.Email);
            authorizationUnauthorizedPage.EnterPassword(_SignInRequest.Password);
            authorizationUnauthorizedPage.ClickEnterButton();
        }

        [When(@"Click on user's profile")]
        [Then(@"Click on user's profile")]
        public void WhenClickOnUsersProfile()
        {
            ProfilePage profilePage = new ProfilePage();
            Thread.Sleep(200);
            profilePage.ClickNameButton();
        }

        [Then(@"User should see his actual information")]
        public void ThenUserShouldSeeHisActualInformation()
        {
            ProfilePage profilePage = new ProfilePage();
            string attributeName = "value";
            RegistrationModel actualUser = new RegistrationModel()
            {
                LastName = profilePage.TextBoxEnterLastName.GetAttribute(attributeName),
                FirstName = profilePage.TextBoxEnterFirstName.GetAttribute(attributeName),
                Patronymic = profilePage.TextBoxEnterPatronymic.GetAttribute(attributeName), 
                BirthDate = profilePage.TextBoxEnterBirthDate.GetAttribute(attributeName),
                Password = _user.Password,
                RepeatPassword = _user.RepeatPassword,
                Email = profilePage.TextBoxEmail.GetAttribute(attributeName), 
                PhoneNumber = profilePage.TextBoxEnterPhone.GetAttribute(attributeName)
            };
            Assert.Equivalent(_user, actualUser);
        }
    }
}
