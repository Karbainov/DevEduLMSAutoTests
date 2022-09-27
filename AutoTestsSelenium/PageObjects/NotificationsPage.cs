namespace AutoTestsSelenium.PageObjects
{
    public class NotificationsPage : AbstractStudentAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/";

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }
    }
}