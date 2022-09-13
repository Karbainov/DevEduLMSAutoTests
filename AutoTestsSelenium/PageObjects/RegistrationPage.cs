using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestsSelenium.PageObjects
{
    public class RegistrationPage : AbstractPage
    {
        public IWebElement TextBoxLastName { get; set; }
        public IWebElement TextBoxName { get; set; }
        public IWebElement TextBoxPatronymic { get; set; }
        public IWebElement TextBoxBirthDate { get; set; }
        public IWebElement TextBoxPassword { get; set; }
        public IWebElement TextBoxRepeatPassword { get; set; }
        public IWebElement TextBoxEmail { get; set; }
        public IWebElement CheckBoxConfirmRules { get; set; }
        public IWebElement ButtonEnter { get; set; }
        public IWebElement ButtonRegistrate { get; set; }
        public IWebElement ButtonCancelRegistration { get; set; }
        public IWebElement ButtonRegistrationSideBar { get; set; }

        public By ButtonRegistrationSideBarXPath = By.XPath($"//@class='auth-link active-auth-link'");

        public By TextBoxLastNamePath = By.XPath($"");


        public RegistrationPage(IWebDriver driver) : base(driver)
        {
            ButtonRegistrationSideBar = _driver.FindElement(ButtonRegistrationSideBarXPath);
        }

        public void ClickRegistrationSideBarButton()
        {
            ButtonRegistrationSideBar.Click();
        }
    }
}
