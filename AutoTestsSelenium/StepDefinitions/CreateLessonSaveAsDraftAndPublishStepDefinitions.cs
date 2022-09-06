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

        private readonly By _emailInput = By.XPath("//input[@name='email']");
        private readonly By _passwordInput = By.XPath("//input[@name='password']");
        private readonly By _enterButton = By.XPath("//button[text()='Войти']");
        private readonly By _newLessonButton = By.CssSelector("a[href='/new-lesson']");

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
            var emailBox = _driver.FindElement(_emailInput);
            emailBox.SendKeys(authModel.Email);
            var passwordBox = _driver.FindElement(_passwordInput);
            passwordBox.Clear();
            passwordBox.SendKeys(authModel.Password);
            var enterButton = _driver.FindElement(_enterButton);
            enterButton.Click();
        }

        [Given(@"Click on create lesson")]
        public void GivenClickOnCreateLesson()
        {
            Thread.Sleep(1000);
            var addLesson = _driver.FindElement(_newLessonButton);
            addLesson.Click();
        }
    }
}
