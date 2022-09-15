namespace AutoTestsSelenium.PageObjects
{
    public class GroupEditManagerAuthorizedPage : AbstractManagerAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/groups/";
        public int GropuId { get; set; }
        public IWebElement TextBoxGroupName => _driver.FindElement(By.XPath($"//*[text()='Название']/input"));
        public IWebElement ComboBoxCourses => _driver.FindElement(By.XPath($"//div[@class='drop-down-filter  ']"));
        public IWebElement ButtonSave => _driver.FindElement(By.XPath($"//button[text()='Сохранить']"));
        
        public GroupEditManagerAuthorizedPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl($"{PageUrl}{GropuId}");
        }

        public void EnterGroupName(string groupName)
        {
            TextBoxGroupName.SendKeys(groupName);
        }

        public void ClickCoursesComboBox()
        {
            ComboBoxCourses.Click();
        }

        public IWebElement GetDesiredCourse(string courseName)
        {
            ClickCoursesComboBox();
            string xpath = $"//li[text()='{courseName}']";
            return _driver.FindElement(By.XPath(xpath));
        }

        public void ChooseCourse(string courseName)
        {
            GetDesiredCourse(courseName).Click();
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

        public void ClickSaveButton()
        {
            ButtonSave.Click();
        }
    }
}
