namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class MethodistAndTopicsStepDefinitions
    {
        private IWebDriver _driver;
        private SingInWindow _singInWindow;

        MethodistAndTopicsStepDefinitions()
        {
            _driver = new ChromeDriver();
            _singInWindow = new SingInWindow();
        }

        [Given(@"Open DevEducation web")]
        public void GivenOpenDevEducationWebPage()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
        }

        [When(@"authorize as methodist")]
        public void WhenAuthorizeMethodist(Table table)
        {
            SingInRequest singRequest = table.CreateInstance<SingInRequest>();
            var email = _driver.FindElement(_singInWindow.XPathEmailBox);
            email.SendKeys(singRequest.Email);
            var password = _driver.FindElement(_singInWindow.XPathPasswordBox);
            password.Clear();
            password.SendKeys(singRequest.Password);
        }


    }
}
