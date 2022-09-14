namespace AutoTestsSelenium.PageObjects
{
    public abstract class AbstractAuthorizedPage : AbstractPage
    {
        public IWebElement ButtonNameSideBar => _driver.FindElement(By.XPath($"//div[@class='avatar-block transition-styles ']/*[@href='/settings']"));
        public IWebElement ButtonNotificationsSideBar => _driver.FindElement(By.XPath($"//*[text()='Уведомления']/.."));
        public IWebElement ButtonSettingsSideBar => _driver.FindElement(By.XPath($"//*[text()='Настройки']/.."));
        public IWebElement ButtonExitSideBar => _driver.FindElement(By.XPath($"//*[text()='Выйти']/ancestor::button"));
        protected AbstractAuthorizedPage(IWebDriver driver) : base(driver)
        {
        }
        
        public void ClickNameButton()
        {
            ButtonNameSideBar.Click();
        }

        public void ClickNotificationsButton()
        {
            ButtonNotificationsSideBar.Click();
        }

        public void ClickSettingsButton()
        {
            ButtonSettingsSideBar.Click();
        }

        public void ClickExitButton()
        {
            ButtonExitSideBar.Click();
        }

        public void ChageRole(string role)
        {
            _driver.FindElement(By.XPath($"//*[@class='user-roles-wrapper']")).Click();
            role = role switch
            {
                Options.RoleTeacher => "Преподаватель",
                Options.RoleTutor => "Тьютор",
                Options.RoleManager => "Менеджер",
                Options.RoleAdmin => "Администратор",
                Options.RoleStudent => "Студент",
                Options.RoleMethodist => "Методист",
                _ => throw new ArgumentOutOfRangeException(nameof(role)),
            };
            string xpathRequiredRole = $"//li[text()='{role}']";
            _driver.FindElement(By.XPath(xpathRequiredRole)).Click();
        }
    }
}