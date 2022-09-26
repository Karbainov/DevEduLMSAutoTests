namespace AutoTestsSelenium.Support.FindElements
{
    public class TeacherNavigatePanelElements
    {
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
                return By.XPath($"//*[@href='/homeworks']");
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

        public By XPathExitButton
        {
            get
            {
                return By.XPath($"//*[text()='Выйти']/ancestor::button");
            }
            private set { }
        }

        public By XPathLessonsButton
        {
            get
            {
                return By.XPath($"//*[@href='/lessons']");
            }
            private set { }
        }

        public By XPathIssuingHomework
        {
            get
            {
                return By.XPath("//*[text()='Выдача заданий']");
            }
        }

        public By XPathGeneralProgressButton
        {
            get
            {
                return By.XPath($"//*[@href='/general-progress']");
            }
            private set { }
        }

        public By XPathRoleButton(string role)
        {
            switch (role)
            {
                case OptionsSwagger.RoleTeacher:
                    role = "Преподаватель";
                    break;
                case OptionsSwagger.RoleTutor:
                    role = "Тьютор";
                    break;
                case OptionsSwagger.RoleManager:
                    role = "Менеджер";
                    break;
                case OptionsSwagger.RoleAdmin:
                    role = "Администратор";
                    break;
                case OptionsSwagger.RoleStudent:
                    role = "Студент";
                    break;
                case OptionsSwagger.RoleMethodist:
                    role = "Методист";
                    break;
            }
            return By.XPath($"//li[text()='{role}']");
        }
    }
}
