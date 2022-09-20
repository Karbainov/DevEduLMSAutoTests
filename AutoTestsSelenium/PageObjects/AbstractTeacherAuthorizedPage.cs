namespace AutoTestsSelenium.PageObjects
{
    public abstract class AbstractTeacherAuthorizedPage : AbstractAuthorizedPage
    {
        public IWebElement ButtonLessonsSideBar => _driver.FindElement(By.XPath($"//*[text()='Занятия']/.."));
        public IWebElement ButtonAddLessonSideBar => _driver.FindElement(By.XPath($"//*[text()='Добавить занятие']/.."));
        public IWebElement ButtonHomeworksSideBar => _driver.FindElement(By.XPath($"//*[text()='Домашние задания']/.."));
        public IWebElement ButtonAddHomewrksSideBar => _driver.FindElement(By.XPath($"//*[text()='Выдача заданий']/.."));
        public IWebElement ButtonCheckHomeworksSideBar => _driver.FindElement(By.XPath($"//*[text()='Проверка заданий']/.."));
        public IWebElement ButtonGeneralProgressSideBar => _driver.FindElement(By.XPath($"//*[text()='Общая успеваемость']/.."));
        public IWebElement ButtonJournalSideBar => _driver.FindElement(By.XPath($"//*[text()='Журнал']/.."));

        protected AbstractTeacherAuthorizedPage(IWebDriver driver) : base(driver)
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
            ButtonAddHomewrksSideBar.Click();
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
    }
}