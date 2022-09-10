namespace AutoTestsSelenium.Support.FindElements
{
    public class StudentLessons
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
