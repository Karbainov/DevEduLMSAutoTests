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
        public IWebElement ExcaptionLastNameMessage => _driver.FindElement(By.XPath("//label[@for='lastName']/following-sibling::*[@class='attention']"));
        public IWebElement ExcaptionFirstNameMessage => _driver.FindElement(By.XPath("//label[@for='firstName']/following-sibling::*[@class='attention']"));
        public IWebElement ExcaptionEmailMessage => _driver.FindElement(By.XPath("//label[@for='email']/following-sibling::*[@class='attention']"));
        public IWebElement ExcaptionPasswordMessage => _driver.FindElement(By.XPath($"//label[@for='password']/following-sibling::*[@class='attention']"));
        public IWebElement ExcaptionRepeatPasswordMessage => _driver.FindElement(By.XPath($"//label[@for='repeat-password']/following-sibling::*[@class='attention']"));
        public IWebElement ExcaptionPrivatePolicyMessage => _driver.FindElement(By.XPath("//label[@for='policy']/following-sibling::*[@class='attention']"));
        public IWebElement ExcaptionBirthDateMessage => _driver.FindElement(By.XPath($"//label[@for='datepicker']/following-sibling::*[@class='attention']"));
        public IWebElement ModalWindow => GetModalWindow();

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
            if (birthDate != null && birthDate != "")
            {
                setDate.DoubleClick(TextBoxBirthDate).
                    SendKeys(birthDate).
                    Build().
                    Perform();
            }
            else
            {
                setDate.DoubleClick(TextBoxBirthDate).
                    SendKeys(" ").
                    Build().
                    Perform();
            }
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

        private IWebElement GetModalWindow()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//div[starts-with(@class,'notification-window')]")));
        }

        public bool IsModalWindowWelcomeDisapear(int disapierTime)
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(disapierTime));
            return webDriverWait.Until<bool>(ExpectedConditions.InvisibilityOfElementLocated(By.XPath($"//*[text()='Добро пожаловать!!']")));
        }
    }
}