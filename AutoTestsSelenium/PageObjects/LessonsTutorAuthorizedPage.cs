namespace AutoTestsSelenium.PageObjects
{
    public class LessonsTutorAuthorizedPage : AbstractTutorAuthorizedPage
    {
        public const string PageUrl = $"{Urls.Host}/lessons";

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