namespace AutoTestsSelenium.PageObjects
{
    public class CreateHomeworkTeacherAuthorizedPage : AbstractTeacherAuthorizedPage
    {
        public string _groupName;

        public const string PageUrl = $"{Urls.Host}/new-homework";

        public IWebElement radioButtonNumberGroup => _driver.FindElement(By.XPath($"//*[text()='{_groupName}']/ancestor::*[@class='radio-button']"));
        public IWebElement textBoxStartDate => _driver.FindElement(By.XPath($"//*[text()='Дата выдачи задания']//input"));
        public IWebElement textBoxEndDate => _driver.FindElement(By.XPath($"//*[text()='Срок сдачи задания']//input"));
        public IWebElement textBoxNameHomework => _driver.FindElement(By.XPath($"//*[@placeholder='Введите название']"));
        public IWebElement textBoxDescriptionHomework => _driver.FindElement(By.XPath($"//*[text()='Описание задания']//textarea"));
        public IWebElement textBoxLink => _driver.FindElement(By.XPath($"//*[text()='Полезные ссылки']//textarea"));
        public IWebElement buttonAddLink => _driver.FindElement(By.XPath($"//*[text()='Полезные ссылки']//button"));
        public IWebElement buttonPublish => _driver.FindElement(By.XPath($"//[text() = 'Опубликовать']"));
        public IWebElement buttonSaveDraft => _driver.FindElement(By.XPath($"//button[@class='sc-bczRLJ jsAGPN btn btn-white-with-border flex-container']"));
        public IWebElement buttonCancel => _driver.FindElement(By.XPath($"//button[@class='sc-bczRLJ kEeNDb btn btn-text flex-container']"));


        public CreateHomeworkTeacherAuthorizedPage(IWebDriver driver) : base(driver)
        {
        }
        public override void OpenThisPage()
        {
           _driver.Navigate().GoToUrl(PageUrl);      
        }
        public void InputStarDate(string startDate)
        {
            textBoxStartDate.SendKeys(startDate);
        }
        public void InputEndDate(string endDate)
        {
            textBoxStartDate.SendKeys(endDate);
        }
        public void InputNameHomework(string nameHomework)
        {
            textBoxNameHomework.SendKeys(nameHomework);
        }
        public void InputDescriptionHomework(string descriptionHomework)
        {
            textBoxDescriptionHomework.SendKeys(descriptionHomework);
        }
        public void InputUsefulLinks(string usefulLinks)
        {
            textBoxLink.SendKeys(usefulLinks);
        }
        public void ClickAddLink()
        {
            buttonAddLink.Click();
        }
        public void ClickSaveDraft()
        {
            buttonSaveDraft.Click();
        }
        public void ClickCancel()
        {
            buttonCancel.Click();
        }
    }
}
