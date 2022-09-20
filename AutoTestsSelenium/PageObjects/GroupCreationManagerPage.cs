using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoTestsSelenium.PageObjects
{
    public class GroupCreationManagerPage : AbstractManagerAuthorizedPage
    {
        private const string PageUrl = $"{Urls.Host}/new-group";
        public IWebElement TextBoxGroupName => _driver.FindElement(By.XPath($"//*[text()='Название']/input"));
        public IWebElement ComboBoxCourses => _driver.FindElement(By.XPath($"//div[@class='drop-down-filter  ']"));
        public IWebElement ButtonSave => _driver.FindElement(By.XPath($"//button[text()='Сохранить']"));
        public IWebElement ButtonCancelCreateGroup => _driver.FindElement(By.XPath($"//*[text()='Отмена']"));

        public GroupCreationManagerPage(IWebDriver driver) : base(driver)
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

        public void ClickDesiredCourseByName(string courseName)
        {
            GetDesiredCourseByName(courseName).Click();
        }

        private IWebElement GetDesiredCourseByName(string courseName)
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//li[text()='{courseName}']")));
        }
    }
}