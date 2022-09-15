namespace AutoTestsSelenium.PageObjects
{
    public class StudentLessonsPage : AbstractStudentAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/lessons";
        public ReadOnlyCollection<IWebElement> ListStudentGroups => _driver.FindElements(By.XPath($"//*[@class='tab-container']"));
        public StudentLessonsPage(IWebDriver driver) : base(driver)
        {
        }

        public ReadOnlyCollection<IWebElement> FindStudentGroups()
        {
            return ListStudentGroups;
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }
    }
}
