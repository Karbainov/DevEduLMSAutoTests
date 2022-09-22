namespace AutoTestsSelenium.PageObjects
{
    public class ProfilePage : AbstractAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/settings";
        public IWebElement TextBoxEmail => _driver.FindElement(By.XPath($"//*[text()='Email']/input[@class='form-input']"));
        public IWebElement TextBoxPassword => _driver.FindElement(By.XPath($"//input[@class='form-input custom-password']"));
        public IWebElement ButtonEnter => _driver.FindElement(By.XPath($"//button[@class='sc-bczRLJ iJvUkY btn btn-fill flex-container']"));
        public IWebElement TextBoxEnterLastName => _driver.FindElement(By.XPath($"//*[text()='Фамилия']/input[@class='form-input']"));
        public IWebElement TextBoxEnterFirstName => _driver.FindElement(By.XPath($"//input[@name='firstName']"));
        public IWebElement TextBoxEnterPatronymic => _driver.FindElement(By.XPath($"//input[@name='patronymic']"));
        public IWebElement TextBoxEnterGitHub => _driver.FindElement(By.XPath($"//input[@name='gitHubAccount']"));
        public IWebElement TextBoxEnterPhone => _driver.FindElement(By.XPath($"//input[@name='phoneNumber']"));
        public IWebElement TextBoxEnterBirthDate => _driver.FindElement(By.XPath($"//*[@class='form-control']"));
        public IWebElement ButtonSave => _driver.FindElement(By.XPath($"//button[@class='sc-bczRLJ iJvUkY btn btn-fill flex-container']"));
        public IWebElement IconPhoto => _driver.FindElement(By.XPath($"//.[@class='avatar - photo']"));

        public ProfilePage()
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public void ClickOnProfilePhoto()
        {
            IconPhoto.Click();
        }
    }
}
