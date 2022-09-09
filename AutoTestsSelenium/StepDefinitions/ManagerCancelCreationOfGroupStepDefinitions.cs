using AutoTestsSelenium.Support;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class ManagerCancelCreationOfGroupStepDefinitions
    {
        private IWebDriver _driver;

        private xPaths _xPaths;
        public ManagerCancelCreationOfGroupStepDefinitions()
        {
            _xPaths = new xPaths();
        }
        [Given(@"Open a browser and open a page")]
        public void GivenOpenABrowserAndOpenAPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.LogIn);
        }

        [Given(@"Authorize as manager")]
        public void GivenAuthorizeAsManager(Table table)
        {
            AuthModel authModel = table.CreateInstance<AuthModel>();
            var emailBox = _driver.FindElement(_xPaths.EmailInput);
            emailBox.SendKeys(authModel.Email);
            var passwordBox = _driver.FindElement(_xPaths.PasswordInput);
            passwordBox.SendKeys(authModel.Password);
            var enterButton = _driver.FindElement(_xPaths.EnterButton);
            enterButton.Click();
        }

        [Given(@"Start create a group ""([^""]*)""")]
        public void GivenStartCreateAGroup(string name)
        {
            var createGroup = _driver.FindElement(_xPaths.CreateGroupAside);
            createGroup.Click();
            var groupName = _driver.FindElement(_xPaths.EnterGroupName);
            groupName.SendKeys(name);
            var chooseCourse = _driver.FindElement(_xPaths.ChooseCourse);
            chooseCourse.Click();
            var backendC = _driver.FindElement(_xPaths.BackendC);
            backendC.Click();



        }

        [When(@"Cancel creation")]
        public void WhenCancelCreation()
        {
            throw new PendingStepException();
        }

        [Then(@"Group do not create")]
        public void ThenGroupDoNotCreate()
        {
            throw new PendingStepException();
        }
    }
}
