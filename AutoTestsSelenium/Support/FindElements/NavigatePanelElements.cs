namespace AutoTestsSelenium.Support.FindElements
{
    public class NavigatePanelElements
    {
        public By XPathNewHomeworkButton
        {
            get
            {
                return By.XPath($"//*[@href='/new-homework']");
            }
            private set { }
        }
    }
}
