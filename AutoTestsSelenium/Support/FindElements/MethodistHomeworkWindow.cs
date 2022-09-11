namespace AutoTestsSelenium.Support.FindElements
{
    public class MethodistHomeworkWindow
    {
        public By XPathHomeworkButton
        {
            get
            {
                return By.XPath("//span[text()='Домашние задания'] ");
            }
            private set { }
        }

        public By XpathCreateHomework
        {
            get
            {
                return By.XPath("//button[text()='Добавить задание'] ");
            }
        }

        public By XpathChoiceGroupNumber
        {
            get
            {
                return By.XPath("//span[text()='QA Automation']");
            }
        }

        public By XpathNameCreateHomework
        {
            get
            {
                return By.XPath("//input[@class='form-input']");
            }
        }

        public By XpathDescriptionHomework
        {
            get
            {
                return By.XPath("//textarea[@class='form-input']");
            }
        }

        public By XpathLinkInputHomework
        {
            get
            {
                return By.XPath("//textarea[@class='form-input_link form-input']");
            }
        }

        public By XpathButtonSaveDraftHomework
        {
            get
            {
                return By.XPath("//button[text()='Сохранить как черновик']");
            }
        }

    }
}
