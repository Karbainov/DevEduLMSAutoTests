namespace AutoTestsSelenium.PageObjects
{
    public class CreateGroupManagerAuthorizaedPage : AbstractManagerAuthorizedPage
    {
        public const string PageUrl = $"{Urls.Host}/new-group";
        public IWebElement TextBoxGroupName => _driver.FindElement(By.XPath($"//*[text()='Название']/input"));
        public IWebElement ComboBoxCourses => _driver.FindElement(By.XPath($"//div[@class='drop-down-filter  ']"));
        public IWebElement ButtonSave => _driver.FindElement(By.XPath($"//button[text()='Сохранить']"));
        public IWebElement ButtonCancel => _driver.FindElement(By.XPath($"//button[text()='Отмена']"));
        
        public CreateGroupManagerAuthorizaedPage(IWebDriver driver) : base(driver)
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

        public void ClickComboBoxCourses()
        {
            ComboBoxCourses.Click();
        }

        public IWebElement GetDesiredCourseByName(string courseName)
        {
            return _driver.FindElement(By.XPath($"//li[text()='{courseName}']"));
        }

        public void ChooseCourse(string courseName)
        {
            GetDesiredCourseByName(courseName).Click();
        }

        public IWebElement GetDesiredTeacherByName(string firstNameOfTeacher, string lastNameOfTeacher)
        {
            string xpath = $"//div[@class='teachers-list']/descendant::*[text()='{firstNameOfTeacher} {lastNameOfTeacher}']/..";
            return _driver.FindElement(By.XPath(xpath));
        }

        public void ChooseTeacher(string firstNameOfTeacher, string lastNameOfTeacher)
        {
            GetDesiredTeacherByName(firstNameOfTeacher, lastNameOfTeacher).Click();
        }
        
        public IWebElement GetDesiredTutorByName(string firstNameOfTutor, string lastNameOfTutor)
        {
            string xpath = $"//div[@class='tutors-list']/descendant::*[text()='{firstNameOfTutor} {lastNameOfTutor}']/..";
            return _driver.FindElement(By.XPath(xpath));
        }

        public void ChooseTutor(string firstNameOfTutor, string lastNameOfTutor)
        {
            GetDesiredTutorByName(firstNameOfTutor, lastNameOfTutor).Click();
        }

        public void ClickButtonSave()
        {
            ButtonSave.Click();
        }

        public void ClickButtonCancel()
        {
            ButtonCancel.Click();
        }

    }
}