namespace AutoTestsSelenium.PageObjects
{
    public class LessonsStudentPage : AbstractStudentAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/lessons";

        public List<IWebElement> StudentGroups => _driver.FindElements(By.XPath($"//*[@class='tab-container']/div")).ToList();

        public LessonsStudentPage()
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