namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions
    {
        [Given(@"Open registration page")]
        public void GivenOpenRegistrationPage()
        {
            var registrationPage = new RegistrationPage();
            registrationPage.OpenThisPage();
            registrationPage.ClickRegisterButton();
        }

        [Given(@"Fill all requared fields")]
        public void GivenFillAllRequaredFields(Table table)
        {
            var registrationPage = new RegistrationPage();
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
            var registrationPage = new RegistrationPage();
            registrationPage.ClickOnConfirmRulesCheckBox();
        }

        [When(@"Click on register button")]
        public void WhenClickOnRegisterButton()
        {
            var registrationPage = new RegistrationPage();
            registrationPage.ClickOnButtonRegistrate();
        }

        [Then(@"User should see the modal window with text ""([^""]*)""")]
        public void ThenUserShouldSeeTheModalWindowWithText(string modalWindowText)
        {
            var registrationPage = new RegistrationPage();
            string expectedText = modalWindowText;
            string actualText = registrationPage.ModalWindow.Text;
            Assert.Equal(expectedText, actualText);
        }

        [Then(@"Modal window shoul disapear after (.*) seconds")]
        public void ThenModalWindowShoulDisapearAfterSeconds(int disapierTime)
        {
            var registrationPage = new RegistrationPage();
            Assert.True(registrationPage.IsModalWindowWelcomeDisapear(disapierTime));
        }

        [When(@"Click on athorization sidebar button")]
        public void WhenClickOnAthorizationSidebarButton()
        {
            var authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage();
            authorizationUnauthorizedPage.ClickEnterSideBarButton();
        }

        [When(@"Click on user's profile")]
        public void WhenClickOnUsersProfile()
        {
            var profilePage = new ProfilePage();
            profilePage.ClickNameButton();
        }

        [Then(@"User should see his actual information")]
        public void ThenUserShouldSeeHisActualInformation(Table table)
        {
            var expectedUser = table.CreateInstance<RegistrationModel>();
            var profilePage = new ProfilePage();
            string attributeName = "value";
            var actualUser = new RegistrationModel()
            {
                LastName = profilePage.TextBoxLastName.GetAttribute(attributeName),
                FirstName = profilePage.TextBoxFirstName.GetAttribute(attributeName),
                Patronymic = profilePage.TextBoxPatronymic.GetAttribute(attributeName), 
                BirthDate = profilePage.TextBoxBirthDate.GetAttribute(attributeName),
                Email = profilePage.TextBoxEmail.GetAttribute(attributeName), 
                PhoneNumber = profilePage.TextBoxPhone.GetAttribute(attributeName)
            };
            Assert.Equivalent(expectedUser, actualUser);
        }

        [Then(@"Excaption message empty Last Name ""([^""]*)"" should appear")]
        public void ThenExcaptionMessageEmptyLastNameShouldAppear(string excaptionMessage)
        {
            var page = new RegistrationPage();
            string expectedMessage = excaptionMessage;
            string actualMessage = page.ExcaptionLastNameMessage.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"Excaption message empty First Name ""([^""]*)"" should appear")]
        public void ThenExcaptionMessageEmptyFirstNameShouldAppear(string excaptionMessage)
        {
            var page = new RegistrationPage();
            string expectedMessage = excaptionMessage;
            string actualMessage = page.ExcaptionFirstNameMessage.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"Excaption message Email ""([^""]*)"" should appear")]
        public void ThenExcaptionMessageEmptyEmailShouldAppear(string excaptionMessage)
        {
            var page = new RegistrationPage();
            string expectedMessage = excaptionMessage;
            string actualMessage = page.ExcaptionEmailMessage.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"Excaption message Password ""([^""]*)"" should appear")]
        public void ThenExcaptionMessageEmptyPasswordShouldAppear(string excaptionMessage)
        {
            var page = new RegistrationPage();
            string expectedMessage = excaptionMessage;
            string actualMessage = page.ExcaptionPasswordMessage.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"Excaption message Repeat Password ""([^""]*)"" should appear")]
        public void ThenExcaptionMessageEmptyRepeatPasswordShouldAppear(string excaptionMessage)
        {
            var page = new RegistrationPage();
            string expectedMessage = excaptionMessage;
            string actualMessage = page.ExcaptionRepeatPasswordMessage.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"Excaption message Private policy ""([^""]*)"" should appear")]
        public void ThenExcaptionMessagePrivatePolicyShouldAppear(string excaptionMessage)
        {
            var page = new RegistrationPage();
            string expectedMessage = excaptionMessage;
            string actualMessage = page.ExcaptionPrivatePolicyMessage.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"Excaption message wrong Date Birth ""([^""]*)"" should appear")]
        public void ThenExcaptionMessageWrongDateBirthShouldAppear(string excaptionMessage)
        {
            var page = new RegistrationPage();
            string expectedMessage = excaptionMessage;
            string actualMessage = page.ExcaptionBirthDateMessage.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}