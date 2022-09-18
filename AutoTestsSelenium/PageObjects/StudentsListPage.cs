namespace AutoTestsSelenium.PageObjects
{
    public class StudentsListPage : AbstractManagerAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/students-list";

        public StudentsListPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public void ClickGroupsComboBoxByFullNameOfStudent(string fullNameOfStudent)
        {
            _driver.FindElement(By.XPath($"//*[text()='{fullNameOfStudent}']/..//*[@class = 'drop-down-filter__wrapper']")).Click();
        }

        public void ClickDesiredGroupByName(string groupName)
        {
            _driver.FindElement(By.XPath($"//li[text()='{groupName}']")).Click();
        }
    }
}
