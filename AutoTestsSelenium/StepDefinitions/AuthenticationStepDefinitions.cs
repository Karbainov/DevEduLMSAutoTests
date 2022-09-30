namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class AuthenticationStepDefinitions
    {
        [Given(@"Open authorization page")]
        [When(@"Open authorization page")]
        public void GivenOpenAuthorizationPage()
        {
            AuthorizationUnauthorizedPage page = new AuthorizationUnauthorizedPage();
            page.OpenThisPage();
        }

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

        [When(@"Click button Cancel")]
        public void WhenClickButtonCancel()
        {
            AuthorizationUnauthorizedPage page = new AuthorizationUnauthorizedPage();
            page.ClickCancelButton();
        }

        [Then(@"The notification page should open")]
        public void ThenTheNotificationPageShouldOpen()
        {
            string expectedUrl = $"{Urls.Host}/";
            string actialUrl = SingleWebDriver.GetInstance().Url;
            Assert.Equal(expectedUrl, actialUrl);
            //TODO authorization page remains (Task 2.12)
        }

        [Then(@"Text with name on sidebar should be ""([^""]*)""")]
        public void ThenTextWithNameOnSidebarShouldBe(string expectedName)
        {
            NotificationsPage page = new NotificationsPage();
            string actualName = page.GetUserFullName();
            Assert.Equal(expectedName, actualName);
        }

        [Then(@"Text with role on sidebar should be ""([^""]*)""")]
        public void ThenTextWithRoleOnSidebarShouldBe(string expectedRole)
        {
            NotificationsPage page = new NotificationsPage();
            string actualRole = page.ComboBoxRoles.Text;
            Assert.Equal(expectedRole, actualRole);
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

        [Then(@"Exception message under password textbox should appear with text ""([^""]*)""")]
        public void ThenExcaptionMessageWrongPasswordOrEmailShouldAppear(string exceptionMessage)
        {
            AuthorizationUnauthorizedPage page = new AuthorizationUnauthorizedPage();
            string expectedMessage = exceptionMessage;
            string actualMessage = page.LabelUnderPasswordTextBox.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Then(@"Exception message under email textbox should appear with text ""([^""]*)""")]
        public void ThenExceptionMessageEmptyEmailShouldAppear(string exceptionMessage)
        {
            AuthorizationUnauthorizedPage page = new AuthorizationUnauthorizedPage();
            string expectedMessage = exceptionMessage;
            string actualMessage = page.LabelUnderEmailTextBox.Text;
            Assert.Equal(expectedMessage, actualMessage);
        }
    }
}