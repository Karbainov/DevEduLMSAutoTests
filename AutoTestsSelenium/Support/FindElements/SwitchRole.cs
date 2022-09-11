namespace AutoTestsSelenium.Support.FindElements
{
    public class SwitchRole
    {
        public By XPathRoleButton(string role)
        {
            switch (role)
            {
                case OptionsSwagger.RoleTeacher:
                    role = Options.Teacher;
                    break;
                case OptionsSwagger.RoleTutor:
                    role = Options.Tutor;
                    break;
                case OptionsSwagger.RoleManager:
                    role = Options.Manager;
                    break;
                case OptionsSwagger.RoleAdmin:
                    role = Options.Admin;
                    break;
                case OptionsSwagger.RoleStudent:
                    role = Options.Student;
                    break;
                case OptionsSwagger.RoleMethodist:
                    role = Options.Methodist;
                    break;
            }
            return By.XPath($"//li[text()='{role}']");        
        }
    }
}
