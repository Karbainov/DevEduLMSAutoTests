namespace AutoTestsSelenium.PageObjects
{
    public class HomeworkAnswerStudentsPage : AbstractStudentAuthorizedPage
    {
        public int HomeworkId { get; set; }
        public IWebElement TextBoxLinkToAnswer => GetTextBoxLinkToAnswer();
        public IWebElement ButtonSendAnswer => _driver.FindElement(By.XPath($"//button[@class='button-fly']"));

        public HomeworkAnswerStudentsPage(IWebDriver driver) : base(driver)
        {
        }

        public override void OpenThisPage()
        {
            string url = $"{Urls.Host}/{HomeworkId}/new";
        }

        public void EnterAnswer(string answer)
        {
            TextBoxLinkToAnswer.SendKeys(answer);
        }

        public void ClickSendAnswerButton()
        {
            ButtonSendAnswer.Click();
        }

        private IWebElement GetTextBoxLinkToAnswer()
        {
            WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
            return webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//input[@name='answer']")));
        }
    }
}
