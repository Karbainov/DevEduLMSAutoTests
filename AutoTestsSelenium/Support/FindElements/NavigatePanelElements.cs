namespace AutoTestsSelenium.Support.FindElements
{
    public class NavigatePanelElements
    {
        public By XPathNewHomeworkButton
        {
            get
            {
                return By.XPath($"//*[@href='/new-homework']");
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
        public By XPathExitButton
        {
            get
            {
                return By.XPath($"//*[text()='Выйти']/ancestor::button");
            }
            private set { }
        }

    }
}
