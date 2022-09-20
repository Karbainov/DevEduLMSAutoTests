namespace AutoTestsSelenium.PageObjects
{
    public abstract class AbstractStudentAuthorizedPage : AbstractAuthorizedPage
    {
        public IWebElement ButtonLessonsSideBar => _driver.FindElement(By.XPath($"//*[text()='Занятия']/.."));
        public IWebElement ButtonHomeworksSideBar => _driver.FindElement(By.XPath($"//*[text()='Домашние задания']/.."));
        protected AbstractStudentAuthorizedPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickLessonsButton()
        {
            ButtonLessonsSideBar.Click();
        }
        
        public void ClickHomeworksButton()
        {
            ButtonHomeworksSideBar.Click();
        }
    }
}