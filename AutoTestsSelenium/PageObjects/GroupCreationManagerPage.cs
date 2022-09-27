namespace AutoTestsSelenium.PageObjects
{
    public class GroupCreationManagerPage : AbstractManagerAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/new-group";
        public IWebElement TextBoxGroupName => _driver.FindElement(By.XPath($"//*[text()='Название']/input"));
        public IWebElement ComboBoxCourses => _driver.FindElement(By.XPath($"//div[@class='drop-down-filter  ']"));
        public IWebElement ButtonSave => _driver.FindElement(By.XPath($"//button[text()='Сохранить']"));
        public IWebElement ButtonCancelCreateGroup => _driver.FindElement(By.XPath($"//*[text()='Отмена']"));

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
            if (courseName != "")
            {
                WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
                webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//li[text()='{courseName}']"))).Click();
            }
        }

        public IWebElement GetDesiredTeacherByName(string fullNameOfTeacher)
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='{fullNameOfTeacher}']/..")));
        }

        public void ChooseTeachers(List<string> fullNamesOfTeachers)
        {
            foreach (var fullNameOfTeacher in fullNamesOfTeachers)
            {
                if (fullNameOfTeacher != "")
                {
                    GetDesiredTeacherByName(fullNameOfTeacher).Click();
                }
            }
        }

        public IWebElement GetDesiredTutorByName(string fullNameOfTutor)
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()='{fullNameOfTutor}']/..")));
        }

        public void ChooseTutors(List<string> fullNamesOfTutors)
        {
            foreach (var fullNameOfTutor in fullNamesOfTutors)
            {
                if (fullNameOfTutor != "")
                {
                    GetDesiredTutorByName(fullNameOfTutor).Click();
                }
            }
        }

        public IWebElement GetLabelElementByText(string errorMessege)
        {
            return _driver.FindElement(By.XPath($"//*[text()='{errorMessege}']"));
        }
    }
}