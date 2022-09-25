namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class AuthenticationStepDefinitions
    {
        [Given(@"Enter email ""([^""]*)""")]
        [When(@"Enter email ""([^""]*)""")]
        public void WhenEnterEmail(string email)
        {
            AuthorizationUnauthorizedPage page = new AuthorizationUnauthorizedPage();
            page.EnterEmail(email);
        }

        [Given(@"Enter password ""([^""]*)""")]
        [When(@"Enter password ""([^""]*)""")]
        public void WhenEnterPassword(string password)
        {
            AuthorizationUnauthorizedPage page = new AuthorizationUnauthorizedPage();
            page.EnterPassword(password);
        }

        [When(@"Click button Enter")]
        public void WhenClickButtonEnter()
        {
            AuthorizationUnauthorizedPage page = new AuthorizationUnauthorizedPage();
            page.ClickEnterButton();
        }

        [When(@"Click on button Enter")]
        public void WhenClickOnButtonEnter()
        {
            AuthorizationUnauthorizedPage page = new AuthorizationUnauthorizedPage();
            page.ButtonEnter.Click();
        }

        [Then(@"The notification page should open")]
        public void ThenTheNotificationPageShouldOpen()
        {
            string expectedUrl = $"{Urls.Host}/";
            string actialUrl = SingleWebDriver.GetInstance().Url;
            Assert.Equal(expectedUrl, actialUrl);
        }

        [Then(@"Text with name on sidebar should be ""([^""]*)""")]
        public void ThenTextWithNameOnSidebarShouldBe(string fullName)
        {
            NotificationsPage page = new NotificationsPage();
            string expectedName = fullName;
            string actualName = page.GetUserFullName();
            Assert.Equal(expectedName, actualName);
        }

        [Then(@"Text with role on sidebar should be ""([^""]*)""")]
        public void ThenTextWithRoleOnSidebarShouldBe(string role)
        {
            NotificationsPage page = new NotificationsPage();
            string expectedRole = role;
            string actualRole = page.ComboBoxRoles.Text;
            Assert.Equal(expectedRole, actualRole);
        }

        [When(@"Click button Cancel")]
        public void WhenClickButtonCancel()
        {
            AuthorizationUnauthorizedPage page = new AuthorizationUnauthorizedPage();
            page.ClickCancelButton();
        }

        [Then(@"Text in email textbox should be empty")]
        public void ThenTextInEmailTextboxShouldBeEmpty()
        {
            AuthorizationUnauthorizedPage page = new AuthorizationUnauthorizedPage();
            string expectedEmail = "";
            string actualEmail = page.TextBoxEmail.Text;
            Assert.Equal(expectedEmail, actualEmail);
        }

        [Then(@"Label in email textbox should be ""([^""]*)""")]
        public void ThenLabelInEmailTextboxShouldBe(string label)
        {
            AuthorizationUnauthorizedPage page = new AuthorizationUnauthorizedPage();
            string expectedLabel = label;
            string actualLabel = page.TextBoxEmail.GetAttribute("placeholder");
            Assert.Equal(expectedLabel, actualLabel);
        }

        [Then(@"Text in password textbox should be empty")]
        public void ThenTextInPasswordTextboxShouldBeEmpty()
        {
            AuthorizationUnauthorizedPage page = new AuthorizationUnauthorizedPage();
            string expectedPassword = "";
            string actualPassword = page.TextBoxPassword.Text;
            Assert.Equal(expectedPassword, actualPassword);
        }

        [Then(@"Excaption message wrong password or email ""([^""]*)"" should appear")]
        public void ThenExcaptionMessageWrongPasswordOrEmailShouldAppear(string exceptionMessage)
        {
            AuthorizationUnauthorizedPage page = new AuthorizationUnauthorizedPage();
            string expectedMessage = exceptionMessage;
            string actualMessage = page.LabelWrongPasswordOrEmail.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}