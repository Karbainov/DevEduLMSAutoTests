using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestsSelenium.PageObjects
{
    public class RegistrationPage : AbstractPage
    {
        private const string PageUrl = $"{Urls.Host}/";

        RegistrationWindow _registrationWindow = new RegistrationWindow();
        public IWebElement TextBoxLastName { get; set; }
        public IWebElement TextBoxName { get; set; }
        public IWebElement TextBoxPatronymic { get; set; }
        public IWebElement TextBoxBirthDate { get; set; }
        public IWebElement TextBoxPassword { get; set; }
        public IWebElement TextBoxRepeatPassword { get; set; }
        public IWebElement TextBoxEmail { get; set; }
        public IWebElement TextBoxPhone { get; set; }
        public IWebElement CheckBoxConfirmRules { get; set; }
        public IWebElement ButtonRegistrate { get; set; }
        public IWebElement ButtonCancelRegistration { get; set; }
        public IWebElement ButtonAuth { get; set; }

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
            TextBoxLastName = _driver.FindElement(_registrationWindow.XPathLastNameBox);
            TextBoxName = _driver.FindElement(_registrationWindow.XPathFirstNameBox);
            TextBoxPatronymic = _driver.FindElement(_registrationWindow.XPathPatronymicBox);
            TextBoxBirthDate = _driver.FindElement(_registrationWindow.XPathDateBirthBox);
            TextBoxPassword = _driver.FindElement(_registrationWindow.XPathPasswordBox);
            TextBoxRepeatPassword = _driver.FindElement(_registrationWindow.XPathRepeatPasswordBox);
            TextBoxEmail = _driver.FindElement(_registrationWindow.XPathEmailBox);
            CheckBoxConfirmRules = _driver.FindElement(_registrationWindow.XPathPrivatePolicityCheckBox);
            ButtonRegistrate = _driver.FindElement(_registrationWindow.XPathRegisterButton);
            ButtonCancelRegistration = _driver.FindElement(_registrationWindow.XPathCancelRegistrationButton);
            TextBoxPhone = _driver.FindElement(_registrationWindow.XPathPhoneNumberBox);
            ButtonAuth = _driver.FindElement(_registrationWindow.XPathAuthSideBarButton);
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
