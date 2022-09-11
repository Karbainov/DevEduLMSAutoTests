using System;
using TechTalk.SpecFlow;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class GroupsStepDefinitions
    {
        private CreateGroupFromBrowser _newGroup;
        private IWebDriver _driver;

        [When(@"manager create new group from browser")]
        public void WhenManagerCreateNewGroupFromBrowser(Table table)
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
            _newGroup = table.CreateInstance<CreateGroupFromBrowser>();
        }

        [When(@"manager add students to group ""([^""]*)""")]
        public void WhenManagerAddStudentsToGroup(string p0)
        {
            Thread.Sleep(100);
            //throw new PendingStepException();
        }

        [Then(@"users should see their group")]
        public void ThenUsersShouldSeeTheirGroup()
        {
            Thread.Sleep(100);
            //throw new PendingStepException();
        }

        [Then(@"manager should see actual group")]
        public void ThenManagerShouldSeeActualGroup()
        {
            Thread.Sleep(100);
            //throw new PendingStepException();
        }

        [When(@"manager edit group ""([^""]*)""")]
        public void WhenManagerEditGroup(string p0)
        {
            Thread.Sleep(100);
            //throw new PendingStepException();
        }

        [When(@"manager delete students from group ""([^""]*)""")]
        public void WhenManagerDeleteStudentsFromGroup(string p0, Table table)
        {
            string groupName = p0;
            List<string> studentsToDelete = table.Header.Select(x => x.ToString()).ToList();

            Thread.Sleep(100);
        }
    }
}
