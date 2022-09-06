using AutoTestsSelenium.Support;
using AutoTestsSelenium.Support.Models.Request;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]

    public class CreateLessonSaveAsDraftAndPublishStepDefinitions
    {
        private IWebDriver _driver;

        [Given(@"Open a browser and go to devedu page")]
        public void GivenOpenABrowserAndGoToDeveduPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.LogIn);
        }

        [Given(@"Login as teacher")]
        public void GivenLoginAsTescher(Table table)
        {
            AuthModel authModel = table.CreateInstance<AuthModel>();
            var emailBox = _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/main/div[1]/form/div[1]/input"));
            emailBox.SendKeys(authModel.Email);
            var passwordBox = _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/main/div[1]/form/div[2]/input"));
            passwordBox.Clear();
            passwordBox.SendKeys(authModel.Password);
            var enterButton = _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/main/div[1]/form/div[3]/button[1]"));
            enterButton.Click();
        }

        [Given(@"Click on create lesson")]
        public void GivenClickOnCreateLesson()
        {
            var addLesson = _driver.FindElement(By.XPath("/html/body/div/div/aside/div/nav/a[3]"));
            addLesson.Click();
        }
    }
}
