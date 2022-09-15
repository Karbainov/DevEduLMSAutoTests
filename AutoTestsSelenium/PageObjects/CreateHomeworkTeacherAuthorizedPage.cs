namespace AutoTestsSelenium.PageObjects
{
    public class CreateHomeworkTeacherAuthorizedPage : AbstractTeacherAuthorizedPage
    {
        public const string PageUrl = $"{Urls.Host}/new-homework";

        public CreateHomeworkTeacherAuthorizedPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public IWebElement RadioButtonGroupName(string groupName)
        {
            string xpath = $"//*[text()='{groupName}']/ancestor::*[@class='radio-button']";
            return _driver.FindElement(By.XPath(xpath));
        }
    }
}