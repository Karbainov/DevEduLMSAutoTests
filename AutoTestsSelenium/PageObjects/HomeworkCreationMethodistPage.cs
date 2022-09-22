namespace AutoTestsSelenium.PageObjects
{
    public class HomeworkCreationMethodistPage : AbstractMethodistAuthorizedPage
    {
        public const string PageUrl = $"{Urls.Host}/new-homework";
        public IWebElement NameHomework => _driver.FindElement(By.XPath("//input[@class='form-input']"));
        public IWebElement DescriptionHomework => _driver.FindElement(By.XPath("//textarea[@class='form-input']"));
        public IWebElement LinkHomework => _driver.FindElement(By.XPath("//textarea[@class='form-input_link form-input']"));
        public IWebElement ButtonSaveDraft => _driver.FindElement(By.XPath("//button[text()='Сохранить как черновик']"));
        public IWebElement ButtonAttachLink => _driver.FindElement(By.XPath("//button[@class='sc-bczRLJ kEeNDb btn btn-fill ellipse flex-container']"));

        public HomeworkCreationMethodistPage()
        {
        }
        
        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public void ClickChoiceGroupNumber(string groupName)
        {
            GetChoiceGroupNumberButton(groupName).Click();
        }

        public void InputNameGroup(string nameHomework)
        {
            NameHomework.SendKeys(nameHomework);
        }

        public void InputDescriptionHomework(string description)
        {
            DescriptionHomework.SendKeys(description);
        }

        public void InputLinkHomework(string link)
        {
            LinkHomework.SendKeys(link);
        }

        public void ClickButtonAttachLink()
        {
            ButtonAttachLink.Click();
        }

        public void ClickButtonSaveDraft()
        {
            ButtonSaveDraft.Click();
        }

        private IWebElement GetChoiceGroupNumberButton(string groupName)
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='{groupName}']/ancestor::*[@class='radio-button']")));
        }
    }
}
