using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestsSelenium.PageObjects
{
    public abstract class AbstractPage
    {
        protected IWebDriver _driver;
        
        public AbstractPage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
