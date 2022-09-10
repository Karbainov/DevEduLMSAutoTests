namespace AutoTestsSelenium.Support.FindElements
{
    public class TutorLessonsWindow
    {
        public By XPathLessonsButton
        {
            get
            {
                return By.XPath($"//*[@href='/lessons']");
            }
            private set { }
        }
    }
}
