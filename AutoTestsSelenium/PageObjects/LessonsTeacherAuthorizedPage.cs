namespace AutoTestsSelenium.PageObjects
{
    public class LessonsTeacherAuthorizedPage : AbstractTeacherAuthorizedPage
    {
        public const string PageUrl = $"{Urls.Host}/lessons";

        public LessonsTeacherAuthorizedPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public IWebElement DesiredGroup(string groupName)
        {
            string xpath = $"//*[text()='{groupName}']/..";
            return _driver.FindElement(By.XPath(xpath));
        }
    }
}