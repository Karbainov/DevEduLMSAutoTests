namespace AutoTestsSelenium.PageObjects
{
    public class HomeworksStudentAuthorizedPage : AbstractStudentAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/homeworks";

        public HomeworksStudentAuthorizedPage(IWebDriver driver) : base(driver)
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
