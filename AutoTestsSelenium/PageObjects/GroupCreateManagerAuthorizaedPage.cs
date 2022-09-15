namespace AutoTestsSelenium.PageObjects
{
    public class GroupCreateManagerAuthorizaedPage : AbstractManagerAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/new-group";
        public IWebElement TextBoxGroupName => _driver.FindElement(By.XPath($"//*[text()='Название']/input"));
        public IWebElement ComboBoxCourses => _driver.FindElement(By.XPath($"//div[@class='drop-down-filter  ']"));
        public IWebElement ButtonSave => _driver.FindElement(By.XPath($"//button[text()='Сохранить']"));
        public IWebElement ButtonCancelCreateGroup => _driver.FindElement(By.XPath($"//*[text()='Отмена']"));

        public GroupCreateManagerAuthorizaedPage(IWebDriver driver) : base(driver)
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

        public IWebElement GetDesiredCourseByName(string courseName)
        {
            ClickCoursesComboBox();
            string xpath = $"//li[text()='{courseName}']";
            return _driver.FindElement(By.XPath(xpath));
        }

        public void ChooseCourse(string courseName)
        {
            GetDesiredCourseByName(courseName).Click();
        }

        public string ChooseCourseById(string courseId)
        {
            string courseName;
            ClickCoursesComboBox();
            var result = courseId switch
            {
                "1370" => courseName = "Базовый C#",
                "1371" => courseName = "Frontend React",
                "2371" => courseName = "Backend C#",
                "2374" => courseName = "Базовый Java",
                "2375" => courseName = "Backend Java",
                "2376" => courseName = "QA Automation",
                _ => throw new ArgumentOutOfRangeException(nameof(courseId)),
            };
            _driver.FindElement(By.XPath($"//li[text()='{courseName}']")).Click();
            return courseName;
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
    }
}