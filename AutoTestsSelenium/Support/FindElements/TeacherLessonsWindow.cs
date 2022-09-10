namespace AutoTestsSelenium.Support.FindElements
{
    public class TeacherLessonsWindow
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
