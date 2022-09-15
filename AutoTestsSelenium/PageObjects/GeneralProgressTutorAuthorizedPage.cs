namespace AutoTestsSelenium.PageObjects
{
    public class GeneralProgressTutorAuthorizedPage : AbstractTutorAuthorizedPage
    {
        public const string PageUrl = $"{Urls.Host}/general-progress";

        public GeneralProgressTutorAuthorizedPage(IWebDriver driver) : base(driver)
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