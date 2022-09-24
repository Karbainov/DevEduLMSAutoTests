namespace AutoTestsSelenium.PageObjects
{
    public class HomeworksDraftTeacherPage : AbstractTeacherAuthorizedPage
    {       
        private const string PageUrl = $"{Urls.Host}/homeworks/draft";
        
        public HomeworksDraftTeacherPage()
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

        public void GetNameHomework(string nameHomework)
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//[text()='{nameHomework}']/following-sibling::a"))).Click();
        }
    }
}