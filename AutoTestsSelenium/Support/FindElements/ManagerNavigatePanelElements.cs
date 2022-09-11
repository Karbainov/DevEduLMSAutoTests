namespace AutoTestsSelenium.Support.FindElements
{
    public class ManagerNavigatePanelElements
    {
        public By XPathCreateGroupButton
        {
            get
            {
                return By.XPath($"//*[text()='Создать группу']/ancestor::*[@href='/new-group']");
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
