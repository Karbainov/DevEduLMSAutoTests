namespace AutoTestsSelenium.PageObjects
{
    public abstract class AbstractMethodistAuthorizedPage : AbstractAuthorizedPage
    {
        public IWebElement ButtonCoursesSideBar => _driver.FindElement(By.XPath($"//*[text()='Курсы']/.."));
        public IWebElement ButtonEditCoursesSideBar => _driver.FindElement(By.XPath($"//*[text()='Редактировать курсы']/.."));
        public IWebElement ButtonHomeworksSideBar => _driver.FindElement(By.XPath($"//*[text()='Домашние задания']/.."));
        public IWebElement ButtonAddHomewrksSideBar => _driver.FindElement(By.XPath($"//*[text()='Выдача заданий']/.."));

        protected AbstractMethodistAuthorizedPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickCoursesButton()
        {
            ButtonCoursesSideBar.Click();
        }

        public void ClickEditCoursesButton()
        {
            ButtonEditCoursesSideBar.Click();
        }
        
        public void ClickHomeworksButton()
        {
            ButtonHomeworksSideBar.Click();
        }
        
        public void ClickAddHomeworksButton()
        {
            ButtonAddHomewrksSideBar.Click();
        }
    }
}
