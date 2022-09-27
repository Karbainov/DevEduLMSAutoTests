namespace AutoTestsSelenium.PageObjects
{
    public abstract class AbstractTeacherAuthorizedPage : AbstractAuthorizedPage
    {
        public IWebElement ButtonAddLessonSideBar => GetButtonAddLessonSideBar();
        public IWebElement ButtonLessonsSideBar => GetButtonLessonsSideBar();
        public IWebElement ButtonHomeworksSideBar => GetButtonHomeworkSideBar();
        public IWebElement ButtonAddHomeworksSideBar => GetButtonAddHomewrksSideBar();
        public IWebElement ButtonCheckHomeworksSideBar => _driver.FindElement(By.XPath($"//*[text()='Проверка заданий']/.."));
        public IWebElement ButtonGeneralProgressSideBar => GetButtonGeneralProgressSideBar();
        public IWebElement ButtonJournalSideBar => _driver.FindElement(By.XPath($"//*[text()='Журнал']/.."));

        protected AbstractTeacherAuthorizedPage()
        {
        }

        public void ClickLessonsButton()
        {
            ButtonLessonsSideBar.Click();
        }
        
        public void ClickAddLessonButton()
        {
            ButtonAddLessonSideBar.Click();
        }

        public void ClickHomeworksButton()
        {
            GetButtonHomeworkSideBar().Click();
        }

        public void ClickAddHomeworksButton()
        {
            ButtonAddHomeworksSideBar.Click();
        }

        public void ClickCheckHomeworksButton()
        {
            ButtonCheckHomeworksSideBar.Click();
        }
        
        public void ClickGeneralProgressButton()
        {
            ButtonGeneralProgressSideBar.Click();
        }

        public void ClickJournalButton()
        {
            ButtonJournalSideBar.Click();
        }

        private IWebElement GetButtonLessonsSideBar()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(0.5));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='Занятия']/..")));
        }

        private IWebElement GetButtonHomeworkSideBar()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(0.5));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='Домашние задания']/..")));
        }

        private IWebElement GetButtonAddHomewrksSideBar()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='Выдача заданий']/..")));
        }

        private IWebElement GetButtonGeneralProgressSideBar()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='Общая успеваемость']/..")));
        }

        private IWebElement GetButtonAddLessonSideBar()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='Добавить занятие']/..")));
        }
    }
}