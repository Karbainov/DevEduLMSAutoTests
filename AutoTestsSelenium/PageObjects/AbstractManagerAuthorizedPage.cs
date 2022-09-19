namespace AutoTestsSelenium.PageObjects
{
    public abstract class AbstractManagerAuthorizedPage : AbstractAuthorizedPage
    {
        public IWebElement ButtonGroupsSideBar => _driver.FindElement(By.XPath($"//*[text()='Группы']/.."));
        public IWebElement ButtonSudentsListSideBar => _driver.FindElement(By.XPath($"//*[text()='Список студентов']/.."));
        public IWebElement ButtonPaymentTableSideBar => _driver.FindElement(By.XPath($"//*[text()='Таблица оплат']/.."));
        public IWebElement ButtonAllUsersSideBar => _driver.FindElement(By.XPath($"//*[text()='Все пользователи']/.."));
        
        protected AbstractManagerAuthorizedPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickGroupsButton()
        {
            ButtonGroupsSideBar.Click();
        }
        
        public IWebElement ButtonAddGroupSideBar()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(0.5));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='Создать группу']/..")));
        }

        public void ClickAddGroupButton()
        {
            ButtonAddGroupSideBar().Click();
        }

        public void ClickStudentsListButton()
        {
            ButtonSudentsListSideBar.Click();
        }
        
        public void ClickPaymentTableButton()
        {
            ButtonPaymentTableSideBar.Click();
        }
        
        public void ClickAllUsersButton()
        {
            ButtonAllUsersSideBar.Click();
        }
    }
}