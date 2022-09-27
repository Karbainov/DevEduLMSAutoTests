namespace AutoTestsSelenium.PageObjects
{
    public class StudentsListManagerPage : AbstractManagerAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/students-list";

        public StudentsListManagerPage()
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public IWebElement GetGroupByFullNameOfStudent(string fullNameOfStudent)
        {
            return _driver.FindElement(By.XPath($"//*[text()='{fullNameOfStudent}']/..//*[@class = 'drop-down-filter__wrapper']"));
        }

        public void ClickByFullNameOfStudentComboBox(string fullNameOfStudent)
        {
            GetGroupByFullNameOfStudent(fullNameOfStudent).Click();
        }

        public void ClickDesiredGroupByName(string groupName)
        {
            _driver.FindElement(By.XPath($"//li[text()='{groupName}']")).Click();
        }
    }
}
