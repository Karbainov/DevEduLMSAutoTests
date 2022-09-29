namespace AutoTestsSelenium.PageObjects
{
    public class ProfilePage : AbstractAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/settings";
        public IWebElement TextBoxEmail => _driver.FindElement(By.XPath($"//*[text()='Email']/input"));
        public IWebElement ButtonChangePassword => _driver.FindElement(By.XPath($"//*[@href='/change-password']"));
        public IWebElement TextBoxLastName => _driver.FindElement(By.XPath($"//*[text()='Фамилия']/input"));
        public IWebElement TextBoxFirstName => _driver.FindElement(By.XPath($"//*[text()='Имя']/input"));
        public IWebElement TextBoxPatronymic => _driver.FindElement(By.XPath($"//*[text()='Отчество']/input"));
        public IWebElement TextBoxGitHub => _driver.FindElement(By.XPath($"//*[text()='Ссылка на GitHub']/input"));
        public IWebElement TextBoxPhone => _driver.FindElement(By.XPath($"//*[text()='Телефон']/input"));
        public IWebElement TextBoxBirthDate => _driver.FindElement(By.XPath($"//*[@class='form-control']"));
        public IWebElement ButtonSave => _driver.FindElement(By.XPath($"//*[text()='Сохранить']/."));
        public IWebElement ButtonCancel => _driver.FindElement(By.XPath($"//*[text()='Отмена']/."));

        public ProfilePage()
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public void ClickChangePasswordButton()
        {
            ButtonChangePassword.Click();
        }

        public void EnterLastName(string lastName)
        {
            TextBoxLastName.Clear();
            TextBoxLastName.SendKeys(lastName);
        }

        public void EnterFirstName(string firstName)
        {
            TextBoxFirstName.Clear();
            TextBoxFirstName.SendKeys(firstName);
        }

        public void EnterPatronymic(string patronymic)
        {
            TextBoxPatronymic.Clear();
            TextBoxPatronymic.SendKeys(patronymic);
        }

        public void EnterGitHub(string gitHub)
        {
            TextBoxGitHub.Clear();
            TextBoxGitHub.SendKeys(gitHub);
        }

        public void EnterPhone(string phone)
        {
            TextBoxPhone.Clear();
            TextBoxPhone.SendKeys(phone);
        }

        public void EnterBirthDate(string birthDate)
        {
            Actions setDate = new Actions(_driver);
            setDate.DoubleClick(TextBoxBirthDate).
                SendKeys(birthDate).
                Build().
                Perform();
        }

        public void ClickSaveButton()
        {
            ButtonSave.Click();
        }

        public void ClickCancelButton()
        {
            ButtonCancel.Click();
        }
    }
}
