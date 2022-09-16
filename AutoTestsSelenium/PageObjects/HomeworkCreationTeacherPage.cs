namespace AutoTestsSelenium.PageObjects
{
    public class HomeworkCreationTeacherPage : AbstractTeacherAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/new-homework";

        public HomeworkCreationTeacherPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public IWebElement GetRadioButtonByGroupName(string groupName)
        {
            return _driver.FindElement(By.XPath($"//*[text()='{groupName}']/ancestor::*[@class='radio-button']"));
        }
    }
}