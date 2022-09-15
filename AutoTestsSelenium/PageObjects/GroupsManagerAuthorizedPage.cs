namespace AutoTestsSelenium.PageObjects
{
    public class GroupsManagerAuthorizedPage : AbstractManagerAuthorizedPage
    {
        public const string PageUrl = $"{Urls.Host}/groups";
        public IWebElement ButtonEdit => _driver.FindElement(By.XPath($"//a[text()='Редактировать']"));
        public IWebElement ButtonEditStudentsList => _driver.FindElement(By.XPath($"//a[text()='Редактировать список группы']"));
        public List<IWebElement> ListTeachersInGroup => _driver.FindElements(By
            .XPath($"//*[text()='Преподаватель:']/parent::div[@class='groups-list']//span")).ToList();
        public List<IWebElement> ListTutorsInGroup => _driver.FindElements(By
                .XPath($"//*[text()='Тьютор:']/parent::div[@class='groups-list']//span[contains(text(),'')]")).ToList();

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
            ButtonEditStudentsList.Click();
        }
    }
}