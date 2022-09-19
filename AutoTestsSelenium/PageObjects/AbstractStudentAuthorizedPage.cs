namespace AutoTestsSelenium.PageObjects
{
    public abstract class AbstractStudentAuthorizedPage : AbstractAuthorizedPage
    {
        public IWebElement ButtonHomeworksSideBar => _driver.FindElement(By.XPath($"//*[text()='Домашние задания']/.."));
        protected AbstractStudentAuthorizedPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ButtonLessonsSideBar()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(0.5));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='Занятия']/..")));
        }

        public void ClickLessonsButton()
        {
            ButtonLessonsSideBar().Click();
        }
        
        public void ClickHomeworksButton()
        {
            ButtonHomeworksSideBar.Click();
        }
    }
}