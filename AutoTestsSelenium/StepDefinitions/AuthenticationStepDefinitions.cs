namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class AuthenticationStepDefinitions
    {
        [When(@"Enter email ""([^""]*)""")]
        public void WhenEnterEmail(string email)
        {
            AuthorizationUnauthorizedPage page = new AuthorizationUnauthorizedPage();
            page.EnterEmail(email);
        }

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
    }
}
