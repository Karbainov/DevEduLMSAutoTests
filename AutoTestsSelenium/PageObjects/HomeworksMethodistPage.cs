namespace AutoTestsSelenium.PageObjects
{
    public class HomeworksMethodistPage : AbstractMethodistAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/homeworks";
        public IWebElement ButtonAddHomework => _driver.FindElement(By.XPath($"//button[@class='sc-bczRLJ iJvUkY btn btn-fill flex-container']"));

        public HomeworksMethodistPage()
        {

        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public void ClickAddHomework()
        {
            ButtonAddHomework.Click();
        }
    }
}
