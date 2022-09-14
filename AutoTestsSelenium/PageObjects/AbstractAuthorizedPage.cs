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
            switch (role)
            {
                case Options.RoleTeacher:
                    role = "Преподаватель";
                    break;
                case Options.RoleTutor:
                    role = "Тьютор";
                    break;
                case Options.RoleManager:
                    role = "Менеджер";
                    break;
                case Options.RoleAdmin:
                    role = "Администратор";
                    break;
                case Options.RoleStudent:
                    role = "Студент";
                    break;
                case Options.RoleMethodist:
                    role = "Методист";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(role));
            }
            string xpathRequiredRole = $"//li[text()='{role}']";
            _driver.FindElement(By.XPath(xpathRequiredRole)).Click();
        }
    }
}