namespace AutoTestsSelenium.Support.FindElements
{
    public class HomeworkWindow
    {
        public By XPathPublishButton
        {
            get
            {
                return By.XPath($"//button[text()='Опубликовать']");
            }
            private set { }
        }
        public By XPathStartDateTextBox
        {
            get
            {
                return By.XPath($"//*[text()='Дата выдачи задания']//input");
            }
            private set { }
        }
    }
}
