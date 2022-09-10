namespace AutoTestsSelenium.Support.FindElements
{
    public class StudentLessonsWindow
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
