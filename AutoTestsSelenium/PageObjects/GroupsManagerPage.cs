namespace AutoTestsSelenium.PageObjects
{
    public class GroupsManagerPage : AbstractManagerAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/groups";
        public IWebElement ButtonEdit => _driver.FindElement(By.XPath($"//a[text()='Редактировать']"));
        public IWebElement ButtonEditStudents => _driver.FindElement(By.XPath($"//a[text()='Редактировать список группы']"));
        public List<IWebElement> TeachersInGroup => _driver.FindElements(By.XPath($"//*[text()='Преподаватель:']/parent::div[@class='groups-list']//span")).ToList();
        public List<IWebElement> TutorsInGroup => _driver.FindElements(By.XPath($"//*[text()='Тьютор:']/parent::div[@class='groups-list']//span[contains(text(),'')]")).ToList();

        public GroupsManagerPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public IWebElement GetDesiredGroupByName(string groupName)
        {
            return _driver.FindElement(By.XPath($"//*[text()='{groupName}']/.."));
        }
        public List<IWebElement> GetAllGroups()
        {
            return _driver.FindElements(By.XPath($"//div[@class='tab-container']")).ToList();
        }

        public void ChooseGroup(string groupName)
        {
            GetDesiredGroupByName(groupName).Click();
        }

        public void ClickEditButton()
        {
            ButtonEdit.Click();
        }

        public void ClickEditStudentsListButton()
        {
            ButtonEditStudents.Click();
        }
    }
}