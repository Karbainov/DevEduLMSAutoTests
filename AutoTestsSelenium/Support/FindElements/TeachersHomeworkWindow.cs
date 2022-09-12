namespace AutoTestsSelenium.Support.FindElements
{
    public class TeachersHomeworkWindow
    {
        public string _groupName;

        public By XpathHomework
        {
            get
            {
                return By.XPath("//span[text()='Домашние задания']");
            }
        }

        public By XPathIssuingHomework
        {
            get
            {
                return By.XPath("//*[text()='Выдача заданий']");
            }
        }

        public By XPathPublishButton
        {
            get
            {
                return By.XPath("//button[text()='Опубликовать']");
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
        public By XPathEndDateTextBox
        {
            get
            {
                return By.XPath($"//*[text()='Срок сдачи задания']//input");
            }
            private set { }
        }
        public By XPathGroupRB
        {
            get
            {
                string xpath = $"//*[text()='{_groupName}']/ancestor::*[@class='radio-button']";
                return By.XPath(xpath);
            }
            private set { }
        }
        public By XPathNameTB
        {
            get
            {
                return By.XPath($"//*[@placeholder='Введите название']");
            }
            private set { }
        }
        public By XPathDescriptionTB
        {
            get
            {
                return By.XPath($"//*[text()='Описание задания']//textarea");
            }
            private set { }
        }
        public By XPathLinkTB
        {
            get
            {
                return By.XPath($"//*[text()='Полезные ссылки']//textarea");
            }
            private set { }
        }
        public By XPathAddLinkButton
        {
            get
            {
                return By.XPath($"//*[text()='Полезные ссылки']//button");
            }
            private set { }
        }
    }
}
