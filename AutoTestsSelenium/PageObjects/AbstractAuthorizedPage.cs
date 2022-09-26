namespace AutoTestsSelenium.PageObjects
{
    public abstract class AbstractAuthorizedPage : AbstractPage
    {
        public IWebElement ButtonNameSideBar => _driver.FindElement(By.XPath($"//div[@class='avatar-block transition-styles ']/*[@href='/settings']"));
        public IWebElement ButtonNotificationsSideBar => _driver.FindElement(By.XPath($"//*[text()='Уведомления']/.."));
        public IWebElement ComboBoxRoles => _driver.FindElement(By.XPath($"//*[@class='user-roles-wrapper']"));
        public IWebElement ButtonSettingsSideBar => _driver.FindElement(By.XPath($"//*[text()='Настройки']/.."));
        public IWebElement ButtonExitSideBar => _driver.FindElement(By.XPath($"//*[text()='Выйти']/ancestor::button"));
        
        protected AbstractAuthorizedPage()
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
            ComboBoxRoles.Click();
            role = role switch
            {
                OptionsSwagger.RoleTeacher => "Преподаватель",
                OptionsSwagger.RoleTutor => "Тьютор",
                OptionsSwagger.RoleManager => "Менеджер",
                OptionsSwagger.RoleAdmin => "Администратор",
                OptionsSwagger.RoleStudent => "Студент",
                OptionsSwagger.RoleMethodist => "Методист",
                _ => throw new ArgumentOutOfRangeException(nameof(role)),
            };
            _driver.FindElement(By.XPath($"//li[text()='{role}']")).Click();
        }
    }
}