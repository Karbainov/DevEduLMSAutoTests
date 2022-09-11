namespace AutoTestsSelenium.Support.FindElements
{
    public class StudentNavigatePanelElements
    {
        public By XPathLessonsButton
        {
            get
            {
                return By.XPath($"//*[@href='/lessons']");
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
