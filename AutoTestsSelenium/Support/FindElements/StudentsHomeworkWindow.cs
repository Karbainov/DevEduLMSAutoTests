namespace AutoTestsSelenium.Support.FindElements
{
    public class StudentsHomeworkWindow
    {
        public By XPathGoToTaskButton
        {
            get
            {
                return By.XPath($"//*[@class='arrow-right ']");
            }
            private set { }
        }

        public By XPathLinkToAnswerTB
        {
            get
            {
                return By.XPath($"//input[@name='answer']");
            }
            private set { }
        }

        public By XPathSendAnswerButton
        {
            get
            {
                return By.XPath($"//button[@class='button-fly']");
            }
            private set { }
        }
    }
}
