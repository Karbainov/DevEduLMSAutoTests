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
        public IWebElement IconPhoto => _driver.FindElement(By.XPath($"//span[@class='avatar-text']/*"));
        public IWebElement InputFile => _driver.FindElement(By.XPath($"//input[@type='file']"));
        public IWebElement ButtonSavePhoto => GetButtonSavePhoto();
        public List<IWebElement> Photos => _driver.FindElements(By.XPath(@"//img")).ToList();
        public IWebElement ButtonCancelAddPhoto => GetButtonCancelAddPhoto();
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

        public void ClickButtonSavePhoto()
        {
            ButtonSavePhoto.Click();
        }

        public void ClickButtonCancelAddPhoto()
        {
            ButtonCancelAddPhoto.Click();
        }

        public bool IsModalWindowPhotoDisapier()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            return webDriverWait.Until<bool>(ExpectedConditions.InvisibilityOfElementLocated(By.XPath($"//div[contains(@class,'modal-window')]")));
        }

        private IWebElement GetButtonSavePhoto()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            return wait.Until(ExpectedConditions.ElementExists(By.XPath($"//label[text()='Сохранить']")));
        }

        private IWebElement GetButtonCancelAddPhoto()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            return wait.Until(ExpectedConditions.ElementExists(By.XPath($"//button[@class='btn btn-text' and text()='Отмена']")));
        }
    }
}