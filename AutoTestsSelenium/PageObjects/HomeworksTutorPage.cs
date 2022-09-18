namespace AutoTestsSelenium.PageObjects
{
    public class HomeworksTutorPage:AbstractTutorAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/homeworks";

        public HomeworksTutorPage(IWebDriver driver) : base(driver)
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