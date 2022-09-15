namespace AutoTestsSelenium.Support.FindElements
{
    public class NavigatePanelElements
    {
        public By XPathIssuingHomework
        {
            get
            {
                return By.XPath("//*[text()='Выдача заданий']");
            }
        }

        public By XPathNewHomeworkButton
        {
            get
            {
                return By.XPath($"//*[@href='/new-homework']");
            }
            private set { }
        }
        public By XPathSwitchRoleButton
        {
            get
            {
                return By.XPath($"//*[@class='user-roles-wrapper']");
            }
            private set { }
        }

        public By XPathHomeworksButton
        {
            get
            {
                return By.XPath("//span[text()='Домашние задания']");
            }
            private set { }
        }
        public By XPathCheckHomeworksButton
        {
            get
            {
                return By.XPath($"//*[@href='/check-homework']");
            }
            private set { }
        }
        public By XPathGeneralProgressButton
        {
            get
            {
                return By.XPath($"//*[@href='/general-progress']");
            }
            private set { }
        }
        public By XPathExitButton
        {
            get
            {
                return By.XPath($"//*[text()='Выйти']/ancestor::button");
            }
            private set { }
        }
        public By XPathRoleButton(string role)
        {
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
            }
            return By.XPath($"//li[text()='{role}']");
        }

    }
}
