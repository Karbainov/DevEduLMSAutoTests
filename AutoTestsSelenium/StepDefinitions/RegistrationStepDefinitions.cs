namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions
    {
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

        [When(@"Click on user's profile")]
        [Then(@"Click on user's profile")]
        public void WhenClickOnUsersProfile()
        {
            ProfilePage profilePage = new ProfilePage();
            Thread.Sleep(200);
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
                Email = profilePage.TextBoxEmail.GetAttribute(attributeName),
                PhoneNumber = profilePage.TextBoxEnterPhone.GetAttribute(attributeName)
            };
            Assert.Equivalent(expectedUser, actualUser);
        }

        [Then(@"Excaption message empty Last Name ""([^""]*)"" should appear")]
        public void ThenExcaptionMessageEmptyLastNameShouldAppear(string excaptionMessage)
        {
            RegistrationPage page = new RegistrationPage();
            string expectedMessage = excaptionMessage;
            string actualMessage = page.ExcaptionLastNameMessage.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"Excaption message empty First Name ""([^""]*)"" should appear")]
        public void ThenExcaptionMessageEmptyFirstNameShouldAppear(string excaptionMessage)
        {
            RegistrationPage page = new RegistrationPage();
            string expectedMessage = excaptionMessage;
            string actualMessage = page.ExcaptionFirstNameMessage.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"Excaption message Email ""([^""]*)"" should appear")]
        public void ThenExcaptionMessageEmptyEmailShouldAppear(string excaptionMessage)
        {
            RegistrationPage page = new RegistrationPage();
            string expectedMessage = excaptionMessage;
            string actualMessage = page.ExcaptionEmailMessage.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"Excaption message Password ""([^""]*)"" should appear")]
        public void ThenExcaptionMessageEmptyPasswordShouldAppear(string excaptionMessage)
        {
            RegistrationPage page = new RegistrationPage();
            string expectedMessage = excaptionMessage;
            string actualMessage = page.ExcaptionPasswordMessage.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"Excaption message Repeat Password ""([^""]*)"" should appear")]
        public void ThenExcaptionMessageEmptyRepeatPasswordShouldAppear(string excaptionMessage)
        {
            RegistrationPage page = new RegistrationPage();
            string expectedMessage = excaptionMessage;
            string actualMessage = page.ExcaptionRepeatPasswordMessage.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"Excaption message Private policy ""([^""]*)"" should appear")]
        public void ThenExcaptionMessagePrivatePolicyShouldAppear(string excaptionMessage)
        {
            RegistrationPage page = new RegistrationPage();
            string expectedMessage = excaptionMessage;
            string actualMessage = page.ExcaptionPrivatePolicyMessage.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"Excaption message wrong Date Birth ""([^""]*)"" should appear")]
        public void ThenExcaptionMessageWrongDateBirthShouldAppear(string excaptionMessage)
        {
            RegistrationPage page = new RegistrationPage();
            string expectedMessage = excaptionMessage;
            string actualMessage = page.ExcaptionBirthDateMessage.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"User should see the exception modal window\twith text ""([^""]*)""")]
        public void ThenUserShouldSeeTheExceptionModalWindowWithText(string excaptionMessage)
        {
            RegistrationPage page = new RegistrationPage();
            string expectedMessage = excaptionMessage;
            string actualMessage = page.ModalWindowExcaption.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}