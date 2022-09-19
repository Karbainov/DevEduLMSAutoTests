namespace AutoTestsSelenium.PageObjects
{
    public class HomeworksTeacherPage : AbstractTeacherAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/homeworks";
        public List<IWebElement> StudentsResults => _driver.FindElements(By.XPath($"//div[@class='homework-result-container']/div[@class='table-row']")).ToList();
        
        public HomeworksTeacherPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public IWebElement GetDesiredGroupByCourseName(string courseName)
        {
            return _driver.FindElement(By.XPath($"//*[text()='{courseName}']/.."));
        }

        public void ClickGoToTaskButton(string taskName)
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='{taskName}']/following-sibling::a"))).Click();
        }

        public bool IsStudentsResultDisapear(string studentsFullName, string studentsResult)
        {
            string xpath = $"//*[text()='{studentsFullName}']/following-sibling::*[text()='{studentsResult}']";
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            return webDriverWait.Until<bool>(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(xpath)));
        }
    }
}