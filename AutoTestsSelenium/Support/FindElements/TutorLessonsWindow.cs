namespace AutoTestsSelenium.Support.FindElements
{
    public class TutorLessonsWindow
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
