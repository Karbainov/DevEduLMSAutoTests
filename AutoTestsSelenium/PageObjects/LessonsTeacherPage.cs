namespace AutoTestsSelenium.PageObjects
{
    public class LessonsTeacherPage : AbstractTeacherAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/lessons";
        public List<IWebElement> TeacherGroups => _driver.FindElements(By.XPath($"//*[@class='tab-container']")).ToList();

        public LessonsTeacherPage()
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