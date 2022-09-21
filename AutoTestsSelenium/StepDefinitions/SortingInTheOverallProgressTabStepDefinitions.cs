using System;
using TechTalk.SpecFlow;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class SortingInTheOverallProgressTabStepDefinitions
    {
        private TasksStepDefinitions _stepsBySwagger;

        [Given(@"Register new users with roles")]
        public void GivenRegisterNewUsersWithRoles(Table table)
        {
            _stepsBySwagger = new TasksStepDefinitions();
            _stepsBySwagger.GivenRegisterNewUsersWithRoles(table);
        }

        [Given(@"Manager create new group")]
        public void GivenManagerCreateNewGroup(Table table)
        {
            _stepsBySwagger.GivenManagerCreateNewGroup(table);
        }

        [Given(@"Manager add users to group")]
        public void GivenManagerAddUsersToGroup()
        {
            throw new PendingStepException();
        }

        [When(@"Teacher create new homework")]
        public void WhenTeacherCreateNewHomework(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"Students send links to them")]
        public void WhenStudentsSendLinksToThem()
        {
            throw new PendingStepException();
        }

        [When(@"Teacher rate homeworks")]
        public void WhenTeacherRateHomeworks(Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"Teacher should see students results in homewok tab")]
        public void ThenTeacherShouldSeeStudentsResultsInHomewokTab()
        {
            throw new PendingStepException();
        }

        [Then(@"Teacher should see students results in tab General Progress")]
        public void ThenTeacherShouldSeeStudentsResultsInTabGeneralProgress()
        {
            throw new PendingStepException();
        }

        [Then(@"Teacher click sorting in a column ArrayList")]
        public void ThenTeacherClickSortingInAColumnArrayList()
        {
            throw new PendingStepException();
        }
    }
}
