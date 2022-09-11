namespace AutoTestsSelenium.Support.FindElements
{
    public class StudentLessonWindow
    {
        public By XPathGroups
        {
            get
            {
                return By.XPath($"//*[@class='tab-container']");
            }
            private set { }
        }
    }
}
