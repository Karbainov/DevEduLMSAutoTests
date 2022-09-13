using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestsSelenium.PageObjects
{
    public class AuthorizationPage:AbstractPage
    {
        public IWebElement TextBoxEmail {get; set;}
        public IWebElement TextBoxPassword {get; set;}
        public IWebElement ButtonEnter {get; set;}
        public IWebElement ButtonRegisterSideBar { get; set; }

        SingInWindow _singInWindow = new SingInWindow();

        public AuthorizationPage(IWebDriver driver):base(driver)
        {
            TextBoxEmail = _driver.FindElement(_singInWindow.XPathEmailBox);
            TextBoxPassword = _driver.FindElement(_singInWindow.XPathPasswordBox);
            ButtonEnter = _driver.FindElement(_singInWindow.XPathSingInButton);
            ButtonRegisterSideBar = _driver.FindElement(_singInWindow.XPathRegistrationButton);
        }

        public void EnterEmail(string email)
        {
            TextBoxEmail.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            TextBoxPassword.Clear();
            TextBoxPassword.SendKeys(password);
        }
        public void ClickEnterButton()
        {
            ButtonEnter.Click();
        }
        public void ClickRegisterButton()
        {
            ButtonRegisterSideBar.Click();
        }
        
    }
}
