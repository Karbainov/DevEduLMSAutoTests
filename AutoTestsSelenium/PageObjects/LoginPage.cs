using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestsSelenium.PageObjects
{
    public class LoginPage:AbstractPage
    {
        public IWebElement TextBoxEmail {get; set;}
        public IWebElement TextBoxPassword {get; set;}
        public IWebElement ButtonEnter {get; set;}
        public IWebElement TextIncorrectEmailFormat {
            get
            {
                return _driver.FindElement(By.XPath($"/html/body/div/div/main/div[1]/form/div[2]"));
            } 
            private set
            {

            }
        }

        public LoginPage(IWebDriver driver):base(driver)
        {
            TextBoxEmail = _driver.FindElement(By.XPath($"//*[@id='root']/div/main/div[1]/form/div[1]/input"));
            TextBoxPassword = _driver.FindElement(By.XPath($"/html/body/div/div/main/div[1]/form/div[2]/input"));
            ButtonEnter = _driver.FindElement(By.XPath($"//button[text()='Войти']"));
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
    }
}
