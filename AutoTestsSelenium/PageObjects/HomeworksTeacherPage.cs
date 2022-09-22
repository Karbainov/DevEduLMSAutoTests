namespace AutoTestsSelenium.PageObjects
{
    public class HomeworksTeacherPage : AbstractTeacherAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/homeworks";
        
        public HomeworksTeacherPage()
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public IWebElement GetDesiredGroupByCourseName(string courseName)
        {
            return _driver.FindElement(By.XPath($"//*[text()='{courseName}']/.."));
        }
    }
}