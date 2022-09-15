namespace AutoTestsSelenium.PageObjects
{
    public class EditGroupManagerAuthorizedPage : AbstractManagerAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/groups/";
        public int GropuId { get; set; }
        public IWebElement TextBoxGroupName => _driver.FindElement(By.XPath($"//*[text()='Название']/input"));
        public IWebElement ComboBoxCourses => _driver.FindElement(By.XPath($"//div[@class='drop-down-filter  ']"));
        public IWebElement ButtonSave => _driver.FindElement(By.XPath($"//button[text()='Сохранить']"));
        public EditGroupManagerAuthorizedPage(IWebDriver driver) : base(driver)
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

        public void ClickComboBoxCourses()
        {
            ComboBoxCourses.Click();
        }

        public IWebElement DesiredCourse(string courseName)
        {
            ClickComboBoxCourses();
            string xpath = $"//li[text()='{courseName}']";
            return _driver.FindElement(By.XPath(xpath));
        }

        public void ChooseCourse(string courseName)
        {
            DesiredCourse(courseName).Click();
        }

        public IWebElement DesiredTeacher(string firstNameOfTeacher, string lastNameOfTeacher)
        {
            string xpath = $"//div[@class='teachers-list']/descendant::*[text()='{firstNameOfTeacher} {lastNameOfTeacher}']/..";
            return _driver.FindElement(By.XPath(xpath));
        }

        public void ChooseTeacher(string firstNameOfTeacher, string lastNameOfTeacher)
        {
            DesiredTeacher(firstNameOfTeacher, lastNameOfTeacher).Click();
        }

        public IWebElement DesiredTutor(string firstNameOfTutor, string lastNameOfTutor)
        {
            string xpath = $"//div[@class='tutors-list']/descendant::*[text()='{firstNameOfTutor} {lastNameOfTutor}']/..";
            return _driver.FindElement(By.XPath(xpath));
        }

        public void ChooseTutor(string firstNameOfTutor, string lastNameOfTutor)
        {
            DesiredTutor(firstNameOfTutor, lastNameOfTutor).Click();
        }

        public void ClickButtonSave()
        {
            ButtonSave.Click();
        }
    }
}
