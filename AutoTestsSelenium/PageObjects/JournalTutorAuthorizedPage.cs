namespace AutoTestsSelenium.PageObjects
{
    public class JournalTutorAuthorizedPage:AbstractTutorAuthorizedPage
    {
        public const string PageUrl = $"{Urls.Host}/journal";

        public JournalTutorAuthorizedPage(IWebDriver driver) : base(driver)
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