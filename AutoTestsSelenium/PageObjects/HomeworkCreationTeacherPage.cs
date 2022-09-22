namespace AutoTestsSelenium.PageObjects
{
    public class HomeworkCreationTeacherPage : AbstractPage
    {
        private const string PageUrl = $"{Urls.Host}/new-homework";
        public IWebElement TextBoxStartDate => _driver.FindElement(By.XPath($"//*[text()='Дата выдачи задания']//input"));
        public IWebElement TextBoxEndDate => _driver.FindElement(By.XPath($"//*[text()='Срок сдачи задания']//input"));
        public IWebElement TextBoxNameHomework => _driver.FindElement(By.XPath($"//*[@placeholder='Введите название']"));
        public IWebElement TextBoxDescriptionHomework => _driver.FindElement(By.XPath($"//*[text()='Описание задания']//textarea"));
        public IWebElement TextBoxLink => _driver.FindElement(By.XPath($"//*[text()='Полезные ссылки']//textarea"));
        public IWebElement ButtonAddLink => _driver.FindElement(By.XPath($"//*[text()='Полезные ссылки']//button"));
        public IWebElement ButtonPublish => _driver.FindElement(By.XPath($"//*[text() = 'Опубликовать']"));
        public IWebElement ButtonSaveDraft => _driver.FindElement(By.XPath($"//button[@class='sc-bczRLJ jsAGPN btn btn-white-with-border flex-container']"));
        public IWebElement ButtonCancel => _driver.FindElement(By.XPath($"//button[@class='sc-bczRLJ kEeNDb btn btn-text flex-container']"));

        public HomeworkCreationTeacherPage()
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

        public void ClickRadioButtonGroupName(string groupName)
        {
            GetRadioButtonByGroupName(groupName).Click();
        }

        public void InputStarDate(string startDate)
        {
            Actions setDate = new Actions(_driver);
            setDate.DoubleClick(TextBoxStartDate).
                SendKeys(startDate).
                Build().
                Perform();
        }

        public void InputEndDate(string endDate)
        {
            Actions setDate = new Actions(_driver);
            setDate.DoubleClick(TextBoxEndDate).
                SendKeys(endDate).
                Build().
                Perform();
        }

        public void InputNameHomework(string nameHomework)
        {
            TextBoxNameHomework.SendKeys(nameHomework);
        }

        public void InputDescriptionHomework(string descriptionHomework)
        {
            TextBoxDescriptionHomework.SendKeys(descriptionHomework);
        }

        public void InputLink(string usefulLinks)
        {
            TextBoxLink.SendKeys(usefulLinks);
        }

        public void ClickAddLinkButton()
        {
            ButtonAddLink.Click();
        }

        public void ClickPublishButton()
        {
            ButtonPublish.Click();
        }

        public void ClickSaveDraftButton()
        {
            ButtonSaveDraft.Click();
        }

        public void ClickCancelButton()
        {
            ButtonCancel.Click();
        }
    }
}
