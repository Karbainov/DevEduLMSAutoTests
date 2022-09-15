namespace AutoTestsSelenium.PageObjects
{
    public class GroupCreationPage : AbstractManagerAuthorizedPage
    {
        public IWebElement InputGroupName => _driver.FindElement(By.XPath($"//*[@name='name']"));
        public IWebElement DivChooseCourse => _driver.FindElement(By.XPath($"//*[@class='drop-down-filter  ']"));
        public IWebElement ButtonSave => _driver.FindElement(By.XPath($"//*[text()='Сохранить']"));
        public IWebElement ButtonCancelGroupCreate => _driver.FindElement(By.XPath($"//*[text()='Отмена']"));
 
        protected GroupCreationPage(IWebDriver driver) : base(driver)
        {
        }
        public void EnterGroupName(string name)
        {
            InputGroupName.SendKeys(name);
        }
        public void ClickOnCourses()
        {
            DivChooseCourse.Click();
        }

        public void 

        public override void OpenThisPage()
        {
            throw new NotImplementedException();
        }
    }
}
