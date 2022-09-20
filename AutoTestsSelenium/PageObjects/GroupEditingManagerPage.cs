﻿namespace AutoTestsSelenium.PageObjects
{
    public class GroupEditingManagerPage : AbstractManagerAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/groups/";
        public int GropuId { get; set; }
        public IWebElement TextBoxGroupName => _driver.FindElement(By.XPath($"//*[text()='Название']/input"));
        public IWebElement ComboBoxCourses => _driver.FindElement(By.XPath($"//div[@class='drop-down-filter  ']"));
        public IWebElement ButtonSave => _driver.FindElement(By.XPath($"//button[text()='Сохранить']"));
        public IWebElement ButtonCancelEditGroup => _driver.FindElement(By.XPath($"//*[text()='Отмена']"));

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
            _driver.FindElement(By.XPath($"//li[text()='{courseName}']")).Click();
        }

        public IWebElement GetDesiredTeacherByName(string fullNameOfTeacher)
        {
            return _driver.FindElement(By.XPath($"//*[text()='{fullNameOfTeacher}']/.."));
        }

        public void ChooseTeacher(string fullNameOfTeacher)
        {
            GetDesiredTeacherByName(fullNameOfTeacher).Click();
        }

        public IWebElement GetDesiredTutorByName(string fullNameOfTutor)
        {
            return _driver.FindElement(By.XPath($"//*[text()='{fullNameOfTutor}']/.."));
        }

        public void ChooseTutor(string fullNameOfTutor)
        {
            GetDesiredTutorByName(fullNameOfTutor).Click();
        }
    }
}
