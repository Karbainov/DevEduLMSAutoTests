namespace AutoTestsSelenium.Support.FindElements
{
    public class HomeworkWindow
    {
        public By XPathHomeworkButton
        {
            get
            {
                return By.XPath("//span[text()='Домашние задания'] ");
            }
            private set { }
        }

        public By XpathCreateHomework
        {
            get
            {
                return By.XPath("//*[text()='Домашние задания']");
            }
        }
    }
}
