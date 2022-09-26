namespace AutoTestsSelenium.PageObjects
{
    public abstract class AbstractPage
    {
        public IWebElement ButtonVisibleSideBar => _driver.FindElement(By.XPath($"//button[@class='collapse-button']"));
        public IWebElement ButtonChangeTheme => _driver.FindElement(By.XPath($"//*[@class='toggle']"));
        protected IWebDriver _driver;
        
        public AbstractPage()
        {
            _driver = SingleWebDriver.GetInstance();
            _driver.Manage().Window.Maximize();
        }

        public abstract void OpenThisPage();
        
        public void ClickVisibleSideBarButton()
        {
            ButtonVisibleSideBar.Click();
        }

        public void ClickChangeThemeButton()
        {
            ButtonChangeTheme.Click();
        }

        public void RefreshPage()
        {
            _driver.Navigate().Refresh();
        }
    }
}