namespace AutoTestsSelenium.PageObjects
{
    public class HomeworksTeacherPage : AbstractTeacherAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/homeworks";
        public IWebElement ButtonSavedHomework => _driver.FindElement(By.XPath("//button[@class='sc-bczRLJ jsAGPN btn btn-white-with-border flex-container']"));

        public HomeworksTeacherPage(IWebDriver driver) : base(driver)
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

        public void ClickButtonSavedHomework()
        {
            ButtonSavedHomework.Click();
        }
    }
}