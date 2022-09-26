namespace AutoTestsSelenium.PageObjects
{
    public abstract class AbstractUnauthorizedPage:AbstractPage
    {
        public IWebElement ButtonRegisterSideBar => _driver.FindElement(By.XPath($"//*[@href='/register']"));
        public IWebElement ButtonEnterSideBar => _driver.FindElement(By.XPath($"//*[text()='Вход']"));

        public AbstractUnauthorizedPage()
        {
        }

        public void ClickRegisterButton()
        {
            ButtonRegisterSideBar.Click();
        }

        public void ClickEnterSideBarButton()
        {
            ButtonEnterSideBar.Click();
        }
    }
}