namespace AutoTestsSelenium.Support.FindElements
{
    public class ChangeRoleCombobox
    {
        public By XpathCombobox
        {
            get
            {
                return By.XPath("//div[text()='Студент']");
            }

            private set { }                                   
        }

        public By XpathChangeRole
        {
            get
            {
                return By.XPath("//li[text()='Преподаватель']");
            }
        }
    }

}
