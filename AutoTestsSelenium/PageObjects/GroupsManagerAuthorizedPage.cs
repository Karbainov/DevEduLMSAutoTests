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

        public IWebElement DesiredGroup(string groupName)
        {
            string xpath = $"//*[text()='{groupName}']/..";
            return _driver.FindElement(By.XPath(xpath));
        }

        public void ChooseGroup(string groupName)
        {
            DesiredGroup(groupName).Click();
        }

        public void ClickButtonEdit()
        {
            _driver.FindElement(By.XPath($"//a[text()='Редактировать']")).Click();
        }

        public void ClickButtonEditStudentsList()
        {
            _driver.FindElement(By.XPath($"//a[text()='Редактировать список группы']")).Click();
        }
    }
}