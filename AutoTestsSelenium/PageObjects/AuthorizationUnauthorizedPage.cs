namespace AutoTestsSelenium.PageObjects
{
    public class AuthorizationUnauthorizedPage:AbstractUnauthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/login";
        public IWebElement TextBoxEmail => _driver.FindElement(By.XPath($"//*[@name='email']"));
        public IWebElement TextBoxPassword => _driver.FindElement(By.XPath($"//*[@name='password']"));
        public IWebElement ButtonEnter => _driver.FindElement(By.XPath("//button[text()='Войти']"));
        
        public AuthorizationUnauthorizedPage()
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public void EnterEmail(string email)
        {
            TextBoxEmail.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            TextBoxPassword.Clear();
            TextBoxPassword.SendKeys(password);
        }

        public void ClickEnterButton()
        {
            ButtonEnter.Click();
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='Уведомления']/..")));
        }
    }
}