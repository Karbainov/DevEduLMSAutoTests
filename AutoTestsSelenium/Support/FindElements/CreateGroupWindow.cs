namespace AutoTestsSelenium.Support.FindElements
{
    public class CreateGroupWindow
    {
        private string _course;

        public By XPathNameGroupBox
        {
            get
            {
                return By.XPath($"//*[@name='name']");
            }
            private set { }
        }

        public By XPathSaveButton
        {
            get
            {
                return By.XPath($"//*[text()='Сохранить']");
            }
            private set { }
        }

        public By XPathCancelCreateGroupButton
        {
            get
            {
                return By.XPath($"//*[text()='Отмена']");
            }
            private set { }
        }

        public By XPathCoursesComboBox
        {
            get
            {
                return By.XPath($"//*[@class='drop-down-filter  ']");
            }
            private set { }
        }

        public By XPathTeacherCheckBox(string teacherName)
        {
            return By.XPath($"//*[contains(text(),'{teacherName}')]/..");
        }

        public By XPathTutorCheckBox(string tutorName)
        {
            return By.XPath($"//*[contains(text(),'{tutorName}')]/..");
        }

        public By XPathCourseButton(string courseId)
        {
            switch (courseId)
            {
                case Options.CourseBasicSiSharpId:
                    _course = Options.CourseBasicSiSharp;
                    break;
                case Options.CourseFrontendReactId:
                    _course = Options.CourseFrontendReact;
                    break;
                case Options.CourseBackendSiSharpId:
                    _course = Options.CourseBackendSiSharp;
                    break;
                case Options.CourseBasicJavaId:
                    _course = Options.CourseBasicJava;
                    break;
                case Options.CourseBackendJavaId:
                    _course = Options.CourseBackendJava;
                    break;
                case Options.CourseQAAutomationId:
                    _course = Options.CourseQAAutomation;
                    break;
            }
            return By.XPath($"//li[text()='{_course}']");
        }
    }
}
