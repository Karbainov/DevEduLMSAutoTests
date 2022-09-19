namespace AutoTestsSelenium.PageObjects
{
    public class HomeworksCheckingTeacherPage : AbstractTeacherAuthorizedPage
    {
        private string PageUrl = $"{Urls.Host}/check-homework";

        public HomeworksCheckingTeacherPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }
    }
}
