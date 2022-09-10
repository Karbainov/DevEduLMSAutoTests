namespace AutoTestsSelenium.Support.FindElements
{
    public class TutorLessons
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
