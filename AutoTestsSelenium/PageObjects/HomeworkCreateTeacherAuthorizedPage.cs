namespace AutoTestsSelenium.PageObjects
{
    public class HomeworkCreateTeacherAuthorizedPage : AbstractTeacherAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/new-homework";

        public HomeworkCreateTeacherAuthorizedPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public IWebElement GetRadioButtonByGroupName(string groupName)
        {
            string xpath = $"//*[text()='{groupName}']/ancestor::*[@class='radio-button']";
            return _driver.FindElement(By.XPath(xpath));
        }
    }
}