namespace AutoTestsSelenium.PageObjects
{
    public class LessonsStudentPage : AbstractStudentAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/lessons";
        public List<IWebElement> StudentCourses => _driver.FindElements(By.XPath($"//*[@class='tab-container']")).ToList();

        public LessonsStudentPage(IWebDriver driver) : base(driver)
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