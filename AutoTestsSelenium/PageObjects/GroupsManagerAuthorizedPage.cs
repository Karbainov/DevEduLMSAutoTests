namespace AutoTestsSelenium.PageObjects
{
    public class GroupsManagerAuthorizedPage : AbstractManagerAuthorizedPage
    {
        public const string PageUrl = $"{Urls.Host}/groups";

        public GroupsManagerAuthorizedPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public IWebElement GetDesiredGroupByName(string groupName)
        {
            string xpath = $"//*[text()='{groupName}']/..";
            return _driver.FindElement(By.XPath(xpath));
        }
        public List<IWebElement> GetAllGroups()
        {
            return _driver.FindElements(By.XPath($"//div[@class='tab-container']/div[contains(@class, 'tab-item')]/div[text()]")).ToList();
        }

        public void ChooseGroup(string groupName)
        {
            GetDesiredGroupByName(groupName).Click();
        }

        public void ClickButtonEdit()
        {
            _driver.FindElement(By.XPath($"//a[text()='Редактировать']")).Click();
        }

        public void ClickButtonEditStudentsList()
        {
            _driver.FindElement(By.XPath($"//a[text()='Редактировать список группы']")).Click();
        }

        public List<IWebElement> GetTeachersInGroup()
        {
            return _driver.FindElements(By.XPath($"//*[text()='Преподаватель:']/parent::div[@class='groups-list']//span")).ToList();
        }
        
        public List<IWebElement> GetTutorsInGroup()
        {
            return _driver.FindElements(By
                .XPath($"//*[text()='Тьютор:']/parent::div[@class='groups-list']//span[contains(text(),'')]")).ToList();
        }
    }
}