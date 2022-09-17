namespace AutoTestsSelenium.PageObjects
{
    public class HomeworksStudentPage : AbstractStudentAuthorizedPage
    {
        private string _homework;
        private const string PageUrl = $"{Urls.Host}/homeworks";
        public IWebElement TaskButton => _driver.FindElement(By.XPath($"//a[@class='link-arrow']"));
        public IWebElement LinkToAnswer => _driver.FindElement(By.XPath($"//input[@name='answer']"));
        public IWebElement AnswerButton => _driver.FindElement(By.XPath($"//button[@class='button-fly']"));
        //public IWebElement TaskButton => _driver.FindElement(By.XPath($"//*[text()='{_homework}']"));

        public HomeworksStudentPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            _driver.Navigate().GoToUrl(PageUrl);
        }

        public IWebElement GetDesiredGroupByCourseName(string courseName)
        {
            return _driver.FindElement(By.XPath($"//*[text()='{courseName}']/.."));
        }

        public void GoToTaskButton()
        {
            TaskButton.Click();
        }

        public void InputLinkAnswer(string linkHome)
        {
            LinkToAnswer.SendKeys(linkHome);
        }

        public void SendAnswerButton()
        {
            AnswerButton.Click();
        }
    }
}
