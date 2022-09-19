namespace AutoTestsSelenium.PageObjects
{
    public class HomeworksDraftTeacherPage : AbstractTeacherAuthorizedPage
    {       
        private const string PageUrl = $"{Urls.Host}/homeworks/draft";
        

        public HomeworksDraftTeacherPage(IWebDriver driver) : base(driver)
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

        public IWebElement GetNameHomework(string nameHomework)
        {
            string ButtonEditHomework = $"//span[contains(text(),'{nameHomework}')]/following-sibling::a";
            return _driver.FindElement(By.XPath(ButtonEditHomework));
        }

        public void ClickEditHomeworkButton(string nameHomework)
        {
            GetNameHomework(nameHomework).Click();
        }

    }
}