namespace AutoTestsSelenium.PageObjects
{
    public abstract class AbstractAuthorizedPage : AbstractPage
    {
        public IWebElement ButtonNameSideBar => GetButtonNameSideBar();
        public IWebElement ButtonNotificationsSideBar => _driver.FindElement(By.XPath($"//*[text()='Уведомления']/.."));
        public IWebElement ComboBoxRoles => _driver.FindElement(By.XPath($"//*[@class='user-roles-wrapper']"));
        public IWebElement ButtonSettingsSideBar => _driver.FindElement(By.XPath($"//*[text()='Настройки']/.."));
        public IWebElement ButtonExitSideBar => _driver.FindElement(By.XPath($"//*[text()='Выйти']/.."));
        
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

        public string GetUserFullName()
        {
            var buttonName = ButtonNameSideBar;
            var lastName = _driver.FindElement(By.XPath($"//*[contains(@class,'avatar-name m')]")).Text;
            var firstName = _driver.FindElement(By.XPath($"//*[contains(@class,'avatar-name t')]")).Text;
            string fullName = $"{lastName} {firstName}";
            return fullName;
        }

        private IWebElement GetButtonNameSideBar()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[@class='user-info-wrapper']/*[@href='/settings']")));
        }
    }
}