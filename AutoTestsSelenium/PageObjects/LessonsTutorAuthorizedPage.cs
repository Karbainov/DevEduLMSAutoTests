namespace AutoTestsSelenium.PageObjects
{
    public class LessonsTutorAuthorizedPage : AbstractTutorAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/lessons";
        public List<IWebElement> ListTutorGroups => _driver.FindElements(By.XPath($"//*[@class='tab-container']")).ToList();

        public LessonsTutorAuthorizedPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public IWebElement GetDesiredGroupByName(string groupName)
        {
            string xpath = $"//*[text()='{groupName}']/..";
            return _driver.FindElement(By.XPath(xpath));
        }
    }
}