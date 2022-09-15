namespace AutoTestsSelenium.PageObjects
{
    public class CreateGroupPage : AbstractManagerAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/new-group";
        public IWebElement TextBoxNameGroup => _driver.FindElement(By.XPath($"//*[@name='name']"));
        public IWebElement ComboBoxCourses => _driver.FindElement(By.XPath($"//*[@class='drop-down-filter  ']"));
        public IWebElement ButtonSave => _driver.FindElement(By.XPath($"//*[text()='Сохранить']"));
        public IWebElement ButtonCancelCreateGroup => _driver.FindElement(By.XPath($"//*[text()='Отмена']"));

        public CreateGroupPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterNameGroup(string nameGroup)
        {
            TextBoxNameGroup.SendKeys(nameGroup);
        }

        public void ClickSaveButton()
        {
            ButtonSave.Click();
        }

        public void ClickCancelCreateGroupButton()
        {
            ButtonCancelCreateGroup.Click();
        }

        public void ClickTeacherCheckBox(string teacherFirstName, string teacherLastName)
        {
            _driver.FindElement(By.XPath($"//*[text()='{teacherFirstName} {teacherLastName}']/..")).Click();
        }

        public void ClickTutorCheckBox(string tutorFirstName, string tuyorLastName)
        {
            _driver.FindElement(By.XPath($"//*[text()='{tutorFirstName} {tuyorLastName}']/..")).Click();
        }

        public string ChageCourse(string courseId)
        {
            string courseName;
            ComboBoxCourses.Click();
            courseId = courseId switch
            {
                Options.CourseBasicSiSharpId => courseName = Options.CourseBasicSiSharp,
                Options.CourseFrontendReactId => courseName = Options.CourseFrontendReact,
                Options.CourseBackendSiSharpId => courseName = Options.CourseBackendSiSharp,
                Options.CourseBasicJavaId => courseName = Options.CourseBasicJava,
                Options.CourseBackendJavaId => courseName = Options.CourseBackendJava,
                Options.CourseQAAutomationId => courseName = Options.CourseQAAutomation,
                _ => throw new ArgumentOutOfRangeException(nameof(courseId)),
            };
            _driver.FindElement(By.XPath($"//li[text()='{courseName}']")).Click();
            return courseName;
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }
    }
}
