namespace AutoTestsSelenium.PageObjects
{
    public class GeneralStudentsProgressTutorPage : AbstractTutorAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/general-progress";

        public GeneralStudentsProgressTutorPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public IWebElement GetDesiredGroupByName(string groupName)
        {
            return _driver.FindElement(By.XPath($"//*[text()='{groupName}']/.."));
        }
    }
}