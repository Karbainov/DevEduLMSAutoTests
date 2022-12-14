namespace AutoTestsSelenium.PageObjects
{
    public class JournalTeacherPage : AbstractTeacherAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/journal";
        public List<IWebElement> StudentsNames => _driver.FindElements(By.XPath($"//*[text()='Сортировать по фамилии']/../following-sibling::div")).ToList();

        public JournalTeacherPage()
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
    }
}