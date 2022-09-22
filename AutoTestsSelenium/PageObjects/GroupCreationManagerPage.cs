namespace AutoTestsSelenium.PageObjects
{
    public class GroupCreationManagerPage : AbstractManagerAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/new-group";
        public IWebElement TextBoxGroupName => _driver.FindElement(By.XPath($"//*[text()='Название']/input"));
        public IWebElement ComboBoxCourses => _driver.FindElement(By.XPath($"//div[@class='drop-down-filter  ']"));
        public IWebElement ButtonSave => _driver.FindElement(By.XPath($"//button[text()='Сохранить']"));
        public IWebElement ButtonCancelCreateGroup => _driver.FindElement(By.XPath($"//*[text()='Отмена']"));
        public IWebElement LabelEmptyGroupName => _driver.FindElement(By.XPath($"//*[text()='Вы не указали название']"));
        public IWebElement LabelEmptyCourseComboBox => _driver.FindElement(By.XPath($"//*[text()='Вы не выбрали курс']"));
        public IWebElement LabelEmptyTeacherCheckBox => _driver.FindElement(By.XPath($"//*[text()='Вы не выбрали преподавателя']"));

        public GroupCreationManagerPage()
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public void EnterGroupName(string groupName)
        {
            TextBoxGroupName.SendKeys(groupName);
        }

        public void ClickCoursesComboBox()
        {
            ComboBoxCourses.Click();
        }

        public void ClickSaveButton()
        {
            ButtonSave.Click();
        }

        public void ClickCancelCreateGroupButton()
        {
            ButtonCancelCreateGroup.Click();
        }

        public void ClickDesiredCourseByName(string courseName)
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(0.5));
            webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//li[text()='{courseName}']"))).Click();
        }

        public IWebElement GetDesiredTeacherByName(string fullNameOfTeacher)
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(0.5));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='{fullNameOfTeacher}']/..")));
        }

        public void ChooseTeacher(string fullNameOfTeacher)
        {
            GetDesiredTeacherByName(fullNameOfTeacher).Click();
        }
        
        public IWebElement GetDesiredTutorByName(string fullNameOfTutor)
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(0.5));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='{fullNameOfTutor}']/..")));
        }

        public void ChooseTutor(string fullNameOfTutor)
        {
            GetDesiredTutorByName(fullNameOfTutor).Click();
        }
    }
}