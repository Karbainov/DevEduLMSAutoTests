namespace AutoTestsSelenium.PageObjects
{
    public class TutorLessonsPage : AbstractTutorAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/lessons";
        public ReadOnlyCollection<IWebElement> ListTutorGroups => _driver.FindElements(By.XPath($"//*[@class='tab-container']"));
        public TutorLessonsPage(IWebDriver driver) : base(driver)
        {
        }

        public ReadOnlyCollection<IWebElement> FindTutorGroups()
        {
            return ListTutorGroups;
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }
    }
}
