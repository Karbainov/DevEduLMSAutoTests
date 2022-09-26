namespace AutoTestsSelenium.PageObjects
{
    public class LessonsTutorPage : AbstractTutorAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/lessons";
        public List<IWebElement> TutorGroups => _driver.FindElements(By.XPath($"//*[@class='tab-container']")).ToList();

        public LessonsTutorPage()
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