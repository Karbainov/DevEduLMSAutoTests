namespace AutoTestsSelenium.PageObjects
{
    public class HomeworksStudentPage : AbstractStudentAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/homeworks";

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
    }
}
