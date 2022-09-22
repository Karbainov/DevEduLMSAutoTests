﻿namespace AutoTestsSelenium.PageObjects
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

        public RegistrationPage()
        {
           
        }

        public bool IsModalWindowWelcomeDisapear()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            return webDriverWait.Until<bool>(ExpectedConditions.InvisibilityOfElementLocated(By.XPath($"//*[text()='Добро пожаловать!!']")));
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
    }
}
