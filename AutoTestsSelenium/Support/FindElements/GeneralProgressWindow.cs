namespace AutoTestsSelenium.Support.FindElements
{
    public class GeneralProgressWindow
    {
        public By ByXpathAccept => By.XPath($"//*[text()='Сдано']");
        
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
