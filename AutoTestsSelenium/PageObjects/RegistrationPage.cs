namespace AutoTestsSelenium.PageObjects
{
    public class RegistrationPage : AbstractUnauthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/register";
        public IWebElement TextBoxLastName => _driver.FindElement(By.XPath($"//*[@name='lastName']"));
        public IWebElement TextBoxName => _driver.FindElement(By.XPath($"//*[@name='firstName']"));
        public IWebElement TextBoxPatronymic => _driver.FindElement(By.XPath($"//*[@name='patronymic']"));
        public IWebElement TextBoxBirthDate => _driver.FindElement(By.XPath($"//*[@class='form-control']"));
        public IWebElement TextBoxPassword => _driver.FindElement(By.XPath($"//*[@name='password']"));
        public IWebElement TextBoxRepeatPassword => _driver.FindElement(By.XPath($"//*[@name='confirmPassword']"));
        public IWebElement TextBoxEmail => _driver.FindElement(By.XPath($"//*[@name='email']"));
        public IWebElement TextBoxPhone => _driver.FindElement(By.XPath($"//*[@name='phoneNumber']"));
        public IWebElement CheckBoxConfirmRules => _driver.FindElement(By.XPath($"//*[@class='custom-checkbox']"));
        public IWebElement ButtonRegistrate => _driver.FindElement(By.XPath($"//*[@type='submit']"));
        public IWebElement ButtonCancelRegistration => _driver.FindElement(By.XPath($"//*[@type='reset']"));
        public IWebElement ModalWindowWelcome => _driver.FindElements(By.XPath($"//*[text()='Добро пожаловать!!']")).FirstOrDefault()!;
        public IWebElement ExcaptionLastNameMessage => _driver.FindElement(By.XPath(""));//element doesn't exist now
        public IWebElement ExcaptionFirstNameMessage => _driver.FindElement(By.XPath(""));//element doesn't exist now
        public IWebElement ExcaptionEmailMessage => _driver.FindElement(By.XPath(""));//element doesn't exist now
        public IWebElement ExcaptionPasswordMessage => _driver.FindElement(By.XPath($"//label[@for='password']/following-sibling::*[@class='attention']"));
        public IWebElement ExcaptionRepeatPasswordMessage => _driver.FindElement(By.XPath($"//label[@for='repeat-password']/following-sibling::*[@class='attention']"));
        public IWebElement ExcaptionPrivatePolicyMessage => _driver.FindElement(By.XPath(""));//element doesn't exist now
        public IWebElement ExcaptionBirthDateMessage => _driver.FindElement(By.XPath($"//div[@class='rdt']/following-sibling::p"));
        public IWebElement ModalWindowExcaption => GetModalWindowRegistrationException();

        public RegistrationPage()
        {
           
        }

        public void EnterLastName(string lastName)
        {
            TextBoxLastName.SendKeys(lastName);
        }

        public void EnterFirstName(string name)
        {
            TextBoxName.SendKeys(name);
        }

        public void EnterPatronymic(string patronymic)
        {
            TextBoxPatronymic.SendKeys(patronymic);
        }

        public void EnterBirthDate(string birthDate)
        {
            Actions setDate = new Actions(_driver);
            setDate.DoubleClick(TextBoxBirthDate).
                SendKeys(birthDate).
                Build().
                Perform();
        }

        public void EnterPassword(string password)
        {
            TextBoxPassword.SendKeys(password);
        }

        public void EnterRepeatPassword(string repeatPassword)
        {
            TextBoxRepeatPassword.SendKeys(repeatPassword);
        }

        public void EnterEmail(string email)
        {
            TextBoxEmail.SendKeys(email);
        }

        public void EnterPhone(string phone)
        {
            TextBoxPhone.SendKeys(phone);
        }

        public void ClickOnConfirmRulesCheckBox()
        {
            CheckBoxConfirmRules.Click();
        }

        public void ClickOnButtonRegistrate()
        {
            ButtonRegistrate.Click();
        }

        public void ClickOnButtonCancelRegistration()
        {
            ButtonCancelRegistration.Click();
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        private IWebElement GetModalWindowRegistrationException()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//div[starts-with(@class,'notification-window')]")));
        }
    }
}
