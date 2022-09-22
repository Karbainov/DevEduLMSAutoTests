namespace AutoTestsSelenium.PageObjects
{
    public abstract class AbstractTeacherAuthorizedPage : AbstractAuthorizedPage
    {
        public IWebElement ButtonAddLessonSideBar => _driver.FindElement(By.XPath($"//*[text()='Добавить занятие']/.."));
        public IWebElement ButtonLessonsSideBar => GetButtonLessonsSideBar();
        public IWebElement ButtonHomeworksSideBar => _driver.FindElement(By.XPath($"//*[text()='Домашние задания']/.."));
        public IWebElement ButtonAddHomeworksSideBar => _driver.FindElement(By.XPath($"//*[text()='Выдача заданий']/.."));
        public IWebElement ButtonAddHomewrksSideBar => GetButtonAddHomewrksSideBar();
        public IWebElement ButtonCheckHomeworksSideBar => _driver.FindElement(By.XPath($"//*[text()='Проверка заданий']/.."));
        public IWebElement ButtonGeneralProgressSideBar => _driver.FindElement(By.XPath($"//*[text()='Общая успеваемость']/.."));
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
            ButtonHomeworksSideBar.Click();
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

        private IWebElement GetButtonAddHomewrksSideBar()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='Выдача заданий']/..")));
        }
    }
}