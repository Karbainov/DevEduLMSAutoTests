using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestsSelenium.PageObjects
{
    public abstract class AbstractUnauthorizedPage:AbstractPage
    {
        public IWebElement ButtonRegisterSideBar => _driver.FindElement(By.XPath($"//*[@href='/register']"));

        public AbstractUnauthorizedPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickRegisterButton()
        {
            ButtonRegisterSideBar.Click();
        }
    }
}
