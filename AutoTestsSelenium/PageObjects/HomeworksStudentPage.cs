namespace AutoTestsSelenium.PageObjects
{
    public class HomeworksStudentPage : AbstractStudentAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/homeworks";
        public IWebElement AnswerButton => _driver.FindElement(By.XPath($"//button[@class='button-fly']"));
        public IWebElement IntupLinkTextbox => GetIntupLinkTextbox();
        public IWebElement ToTaskButton => GetToTask();

        public HomeworksStudentPage()
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public IWebElement GetDesiredGroupByCourseName(string courseName)
        {
            return _driver.FindElement(By.XPath($"//*[text()='{courseName}']/.."));
        }

        public void ClickGoToTaskButton(string taskName)
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='{taskName}']/following-sibling::a"))).Click();
        }

        public void GoToTaskButton()
        {
            GetToTask().Click();
        }

        public void InputLinkAnswer(string linkHome)
        {
            GetIntupLinkTextbox().SendKeys(linkHome);
        }

        public void SendAnswerButton()
        {
            AnswerButton.Click();
        }

        private IWebElement GetIntupLinkTextbox()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//input[@name='answer']")));
        }

        private IWebElement GetToTask()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//a[@class='link-arrow']")));
        }
    }
}
