namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions
    {
        private SwaggerSignInRequest _SignInRequest;

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
            var user = table.CreateInstance<RegistrationModel>();
            registrationPage.EnterFirstName(user.FirstName);
            registrationPage.EnterLastName(user.LastName);
            registrationPage.EnterPatronymic(user.Patronymic);
            registrationPage.EnterBirthDate(user.BirthDate);
            registrationPage.EnterPassword(user.Password);
            registrationPage.EnterRepeatPassword(user.RepeatPassword);
            registrationPage.EnterEmail(user.Email);
            registrationPage.EnterPhone(user.PhoneNumber);
            _SignInRequest = new SwaggerSignInRequest()
            {
                Email = user.Email,
                Password = user.Password
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
            Assert.True(registrationPage.IsModalWindowWelcomeDisapear());
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
            authorizationUnauthorizedPage.EnterEmail(_SignInRequest.Email);
            authorizationUnauthorizedPage.EnterPassword(_SignInRequest.Password);
            authorizationUnauthorizedPage.ClickEnterButton();
        }

        [When(@"Click on user's profile")]
        [Then(@"Click on user's profile")]
        public void WhenClickOnUsersProfile()
        {
            ProfilePage profilePage = new ProfilePage();
            profilePage.ClickNameButton();
        }

        [Then(@"User should see his actual information")]
        public void ThenUserShouldSeeHisActualInformation(Table table)
        {
            var expectedUser = table.CreateInstance<RegistrationModel>();
            ProfilePage profilePage = new ProfilePage();
            string attributeName = "value";
            RegistrationModel actualUser = new RegistrationModel()
            {
                LastName = profilePage.TextBoxEnterLastName.GetAttribute(attributeName),
                FirstName = profilePage.TextBoxEnterFirstName.GetAttribute(attributeName),
                Patronymic = profilePage.TextBoxEnterPatronymic.GetAttribute(attributeName), 
                BirthDate = profilePage.TextBoxEnterBirthDate.GetAttribute(attributeName),
                Password = expectedUser.Password,
                RepeatPassword = expectedUser.RepeatPassword,
                Email = profilePage.TextBoxEmail.GetAttribute(attributeName), 
                PhoneNumber = profilePage.TextBoxEnterPhone.GetAttribute(attributeName)
            };
            Assert.Equivalent(expectedUser, actualUser);
        }
    }
}
