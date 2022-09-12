namespace AutoTestsSelenium.Support.FindElements
{
    public class GroupsWindow
    {
        public By XPathGroupName(string groupName)
        {
            return By.XPath($"//*[contains(text(),'{groupName}')]");
        }
        public By XPathAllGroupsName
        {
            get
            {
                return By.XPath("//div[@class='groups-header']");
            }
            set { }
        }
    }
}
