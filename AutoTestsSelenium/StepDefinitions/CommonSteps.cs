namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        [Given(@"Open DevEdu web site https://piter-education.ru:7074/")]
        [When(@"Open DevEdu web site https://piter-education.ru:7074/")]
        public void WhenOpenDevEduWebSite()
        {
            var driver = SingleWebDriver.GetInstance();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Urls.Host);
        }

        [Given(@"Authorize user in service")]
        [Given(@"Authorize user in service as teacher")]
        [When(@"Authorize user in service")]
        [Given(@"Authorize user in service as manager")]
        [When(@"Authorize user in service as manager")]
        [When(@"Authorize user in service as methodist")]
        [When(@"Authorize user in service as student")]
        [When(@"Authorize user in service as teacher")]
        [When(@"Authorize user in service as tutor")]
        public void WhenSignInUserInServiceAsManager(Table table)
        {
            AuthorizationUnauthorizedPage authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage();
            SignInRequest user = table.CreateInstance<SignInRequest>();
            authorizationUnauthorizedPage.OpenThisPage();
            authorizationUnauthorizedPage.EnterEmail(user.Email);
            authorizationUnauthorizedPage.EnterPassword(user.Password);
            authorizationUnauthorizedPage.ClickEnterButton();
        }

        [When(@"Exit account as manager")]
        [When(@"Exit account as methodist")]
        [When(@"Exit account as teacher")]
        [When(@"Exit account as tutor")]
        [When(@"Exit account as student")]
        public void WhenExitAccountAsManager()
        {
            GroupCreationManagerPage groupCreationManagerPage = new GroupCreationManagerPage();
            groupCreationManagerPage.ClickExitButton();
        }
    }
}
