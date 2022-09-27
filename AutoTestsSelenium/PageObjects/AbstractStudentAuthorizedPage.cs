namespace AutoTestsSelenium.PageObjects
{
    public abstract class AbstractStudentAuthorizedPage : AbstractAuthorizedPage
    {
        public IWebElement ButtonHomeworksSideBar => GetButtonHomeworksSideBar();
        public IWebElement ButtonLessonsSideBar => GetButtonLessonsSideBar();

        protected AbstractStudentAuthorizedPage()
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

        private IWebElement GetButtonLessonsSideBar()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(0.5));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='Занятия']/..")));
        }
        
        private IWebElement GetButtonHomeworksSideBar()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(0.5));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='Домашние задания']/..")));
        }
    }
}