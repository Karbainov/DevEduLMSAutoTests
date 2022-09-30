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