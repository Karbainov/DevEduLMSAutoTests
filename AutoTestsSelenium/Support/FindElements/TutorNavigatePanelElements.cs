namespace AutoTestsSelenium.Support.FindElements
{
    public class TutorNavigatePanelElements
    {

        public By XPathLessonsButton
        {
            get
            {
                return By.XPath($"//*[@href='/lessons']");
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

        public By XPathExitButton
        {
            get
            {
                return By.XPath($"//*[text()='Выйти']/..");
            }
            private set { }
        }
    }
}
