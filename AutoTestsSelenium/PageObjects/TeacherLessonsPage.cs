namespace AutoTestsSelenium.PageObjects
{
    public class TeacherLessonsPage : AbstractTeacherAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/lessons";
        public ReadOnlyCollection<IWebElement> ListTeacherGroups => _driver.FindElements(By.XPath($"//*[@class='tab-container']"));
        public TeacherLessonsPage(IWebDriver driver) : base(driver)
        {
        }

        public ReadOnlyCollection<IWebElement> FindTeacherGroups()
        {
            return ListTeacherGroups;
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }
    }
}
