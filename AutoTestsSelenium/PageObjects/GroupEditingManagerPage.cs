namespace AutoTestsSelenium.PageObjects
{
    public class GroupEditingManagerPage : AbstractManagerAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/groups/";
        public int GropuId { get; set; }
        public IWebElement TextBoxGroupName => _driver.FindElement(By.XPath($"//*[text()='Название']/input"));
        public IWebElement ComboBoxCourses => _driver.FindElement(By.XPath($"//div[@class='drop-down-filter  ']"));
        public IWebElement ButtonSave => _driver.FindElement(By.XPath($"//button[text()='Сохранить']"));
        public IWebElement ButtonCancelEditGroup => _driver.FindElement(By.XPath($"//*[text()='Отмена']"));
        public IWebElement LabelUnderGroupNameTextBox => _driver.FindElement(By.XPath($"//*[text()='Название']/span"));
        public IWebElement LabelUnderCourcesComboBox => _driver.FindElement(By.XPath($"//*[text()='Курс']/../span"));
        public IWebElement LabelUnderTeachersCheckBoxs => _driver.FindElement(By.XPath($"//*[text()='Преподаватель:']/../span"));

        public GroupEditingManagerPage()
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

        public void ClickSaveButton()
        {
            ButtonSave.Click();
        }

        public void ClickCancelEditGroupButton()
        {
            ButtonCancelEditGroup.Click();
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

        public string GetErrorMessege(string expectedErrorMessege)
        {
            string actualErrorMessege = "";
            if (expectedErrorMessege == "Вы не указали название")
            {
                actualErrorMessege = LabelUnderGroupNameTextBox.Text;
            }
            else if (expectedErrorMessege == "Вы не выбрали курс")
            {
                actualErrorMessege = LabelUnderCourcesComboBox.Text;
            }
            else if (expectedErrorMessege == "Вы не выбрали преподавателя")
            {
                actualErrorMessege = LabelUnderTeachersCheckBoxs.Text;
            }
            return actualErrorMessege;
        }
    }
}
