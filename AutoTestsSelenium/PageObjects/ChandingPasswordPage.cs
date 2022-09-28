namespace AutoTestsSelenium.PageObjects
{
    public class ChandingPasswordPage : AbstractAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/change-password";
        public IWebElement TextBoxOldPassword => _driver.FindElement(By.XPath($"//*[@name='oldPassword']"));
        public IWebElement TextBoxNewPassword => _driver.FindElement(By.XPath($"//*[@name='newPassword']"));
        public IWebElement TextBoxRepeatNewPassword => _driver.FindElement(By.XPath($"//*[@name='newPasswordRepeat']"));
        public IWebElement ButtonSave => _driver.FindElement(By.XPath($"//*[text()='Сохранить']/."));
        public IWebElement ButtonCancel => _driver.FindElement(By.XPath($"//*[text()='Отмена']/."));
        public IWebElement ButtonBack => _driver.FindElement(By.XPath($"//*[text()='Назад']/."));

        public ChandingPasswordPage()
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public void EnterOldPassword(string oldPassword)
        {
            TextBoxOldPassword.SendKeys(oldPassword);
        }

        public void EnterNewPassword(string newPassword)
        {
            TextBoxNewPassword.SendKeys(newPassword);
        }

        public void EnterRepeatNewPassword(string repeatNewPassword)
        {
            TextBoxRepeatNewPassword.SendKeys(repeatNewPassword);
        }

        public void ClickSaveButton()
        {
            ButtonSave.Click();
        }

        public void ClickCancelButton()
        {
            ButtonCancel.Click();
        }

        public void ClickBackButton()
        {
            ButtonBack.Click();
        }
    }
}
