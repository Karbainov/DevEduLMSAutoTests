namespace AutoTestsSelenium.Support.FindElements
{
    public class TeacherLessons
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
