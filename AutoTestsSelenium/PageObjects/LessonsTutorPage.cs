namespace AutoTestsSelenium.PageObjects
{
    public class LessonsTutorPage : AbstractTutorAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/lessons";
        public List<IWebElement> ListTutorGroups => _driver.FindElements(By.XPath($"//*[@class='tab-container']")).ToList();

        public LessonsTutorPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }
    }
}
