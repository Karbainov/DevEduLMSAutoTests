namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class AuthorizationStepDefinitions
    {
        [Given(@"Open login page")]
        public void GivenOpenLoginPage()
        {
            AuthorizationUnauthorizedPage loginPage = new AuthorizationUnauthorizedPage();
            loginPage.OpenThisPage();
        }

        [When(@"Enter ""([^""]*)"" and ""([^""]*)""")]
        public void WhenEnterAnd(string email, string password)
        {
            AuthorizationUnauthorizedPage loginPage = new AuthorizationUnauthorizedPage();
            loginPage.EnterEmail(email);
            loginPage.EnterPassword(password);
            loginPage.ClickEnterButton();
        }
    }
}
