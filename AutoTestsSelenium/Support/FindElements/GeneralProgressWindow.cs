namespace AutoTestsSelenium.Support.FindElements
{
    public class GeneralProgressWindow
    {
        public By ByXpathAccept
        {
            get 
            { 
                return By.XPath($"//*[text()='Сдано']");
            }
            private set { }
        }
        public By ByXpathDecline
        {
            get 
            { 
                return By.XPath($"//*[text()='Не сдано']");
            }
            private set { }
        }

    }
}
