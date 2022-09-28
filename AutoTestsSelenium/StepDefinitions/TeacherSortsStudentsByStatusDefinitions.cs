namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class TeacherSortsStudentsByStatusDefinitions
    {
        [When(@"Teacher open tab General Progress")]
        public void WhenTeacherOpenTabGeneralProgress()
        {
            HomeworksTeacherPage homeworksTeacherPage;
            homeworksTeacherPage = new HomeworksTeacherPage();
            homeworksTeacherPage.ClickGeneralProgressButton();
            //TODO Mock(Tack 2.27)
        }

        [When(@"Teacher click ascending sorting in a column ""([^""]*)""")]
        public void WhenTeacherClickAscendingSortingInAColumn(string taskName)
        {
            GeneralStudentsProgressTeacherPage generalStudentsProgressTeacherPage;
            generalStudentsProgressTeacherPage = new GeneralStudentsProgressTeacherPage();
            var helper = new ModelsHelper();
            generalStudentsProgressTeacherPage.ClickSortBottomButton(taskName);
        }

        [Then(@"Teacher should see list after sort on ABC")]
        public void ThenTeacherShouldSeeListAfterSortOnABC()
        {
            throw new PendingStepException();
        }

        [Then(@"Teacher click descending sorting in a column ""([^""]*)""")]
        public void ThenTeacherClickDescendingSortingInAColumn(string name)
        {
            throw new PendingStepException();
        }

        [Then(@"Teacher should see list after sort on CBA")]
        public void ThenTeacherShouldSeeListAfterSortOnCBA()
        {
            throw new PendingStepException();
        }
    }
}