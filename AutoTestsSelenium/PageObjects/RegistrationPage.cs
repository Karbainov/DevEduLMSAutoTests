namespace AutoTestsSelenium.PageObjects
{
    public class RegistrationPage : AbstractUnauthorizedPage
    {
        public IWebElement ButtonRegisterSideBar => _driver.FindElement(By.XPath($"//*[@href='/register']"));
        public IWebElement TextBoxLastName => _driver.FindElement(By.XPath($""));
        public IWebElement TextBoxName => _driver.FindElement(By.XPath($""));
        public IWebElement TextBoxPatronymic => _driver.FindElement(By.XPath($""));
        public IWebElement TextBoxBirthDate => _driver.FindElement(By.XPath($""));
        public IWebElement TextBoxPassword => _driver.FindElement(By.XPath($""));
        public IWebElement TextBoxRepeatPassword => _driver.FindElement(By.XPath($""));
        public IWebElement TextBoxEmail => _driver.FindElement(By.XPath($""));
        public IWebElement TextBoxPhone => _driver.FindElement(By.XPath($""));
        public IWebElement CheckBoxConfirmRules => _driver.FindElement(By.XPath($""));
        public IWebElement ButtonRegistrate => _driver.FindElement(By.XPath($""));
        public IWebElement ButtonCancelRegistration => _driver.FindElement(By.XPath($""));
        public IWebElement ButtonAuth => _driver.FindElement(By.XPath($""));

        public RegistrationPage(IWebDriver driver) : base(driver)
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

        public void ClickOnAuthSideBarButton()
        {
            ButtonAuth.Click();
        }

        public override void OpenThisPage()
        {
            throw new NotImplementedException();
        }
    }
}
