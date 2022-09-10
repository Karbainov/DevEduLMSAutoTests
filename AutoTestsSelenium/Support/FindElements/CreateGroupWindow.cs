namespace AutoTestsSelenium.Support.FindElements
{
    public class CreateGroupWindow
    {
        public By XPathCreateGroupButton
        {
            get
            {
                return By.XPath($"//*[text()='Создать группу']/..");
            }
            private set { }
        }

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

        public static By XPathCoursesComboBox(string id)
        {
            return By.Id(id);
        }

        public static By XPathTeacherCheckBox(string teacherName)
        {
            return By.XPath($"//*[text()='{teacherName}']/../*");
        }

        public static By XPathTutorCheckBox(string tutorName)
        {
            return By.XPath($"//*[text()='{tutorName}']/../*");
        }
    }
}
