namespace AutoTestsSelenium.PageObjects
{
    public class HomeworksTeacherAuthorizedPage : AbstractTeacherAuthorizedPage
    {
        public const string PageUrl = $"{Urls.Host}/homeworks";
        
        public HomeworksTeacherAuthorizedPage(IWebDriver driver) : base(driver)
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