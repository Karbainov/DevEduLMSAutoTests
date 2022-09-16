namespace AutoTestsSelenium.PageObjects
{
    public class HomeworksStudentPage : AbstractStudentAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/homeworks";

        public HomeworksStudentPage(IWebDriver driver) : base(driver)
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
    }
}
