namespace AutoTestsSelenium.PageObjects
{
    public class LessonsTeacherPage : AbstractTeacherAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/lessons";
        public List <IWebElement> ListTeacherGroups => _driver.FindElements(By.XPath($"//*[@class='tab-container']")).ToList();

        public LessonsTeacherPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }
    }
}
