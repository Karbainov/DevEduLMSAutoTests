namespace AutoTestsSelenium.PageObjects
{
    public abstract class AbstractMethodistAuthorizedPage : AbstractAuthorizedPage
    {
        public IWebElement ButtonCoursesSideBar => _driver.FindElement(By.XPath($"//*[text()='Курсы']/.."));
        public IWebElement ButtonEditCoursesSideBar => _driver.FindElement(By.XPath($"//*[text()='Редактировать курсы']/.."));
        public IWebElement ButtonHomeworksSideBar => GetButtonHomeworksSideBar();
        public IWebElement ButtonAddHomewrksSideBar => _driver.FindElement(By.XPath($"//*[text()='Выдача заданий']/.."));

        protected AbstractMethodistAuthorizedPage()
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

        private IWebElement GetButtonHomeworksSideBar()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            return wait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='Домашние задания']/..")));
        }
    }
}