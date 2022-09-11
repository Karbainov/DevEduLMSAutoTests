﻿namespace AutoTestsSelenium.Support.FindElements
{
    public class CreateGroupWindow
    {
        private static string _course;

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

        public static By XPathTeacherCheckBox(string teacherName)
        {
            return By.XPath($"//*[text()='{teacherName}']/..");
        }

        public static By XPathTutorCheckBox(string tutorName)
        {
            return By.XPath($"//*[text()='{tutorName}']/..");
        }

        public static By XPathCourseButton(string courseId)
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