namespace AutoTestsSelenium.PageObjects
{
    public class HomeworkButton: AbstractPage
    {
        private const string PageUrl = $"{Urls.Host}/homeworks";
        public IWebElement ButtonCreateHomework => _driver.FindElement(By.XPath("//button[text()='Добавить задание'] "));
        public IWebElement ButtonSavedHomework => _driver.FindElement(By.XPath("//button[@class='sc-bczRLJ jsAGPN btn btn-white-with-border flex-container']"));

        public HomeworkButton(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public void ClickCreateHomework()
        {
            ButtonCreateHomework.Click();
        }

        public void ClickButtonSavedHomework()
        {
            ButtonSavedHomework.Click();
        }
    }
}
