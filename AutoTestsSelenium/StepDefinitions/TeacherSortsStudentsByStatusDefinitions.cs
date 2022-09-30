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
            generalStudentsProgressTeacherPage.MoveLeftTopScrollBar();
            Thread.Sleep(5000);
            generalStudentsProgressTeacherPage.ClickSortBottomButton(taskName);
        }

        [Then(@"Teacher should see list ""([^""]*)"" after sort on ABC")]
        public void ThenTeacherShouldSeeListAfterSortOnABC(string homeworkName,Table table)
        {
            var expectedResults = table.CreateSet<StudentsHomeworkResultModel>().ToList();
            var page = new GeneralStudentsProgressTeacherPage();
            var helper = new ModelsHelper();
            var actualResults = helper.GetHomeworkResultsByHomeworkName(page, homeworkName);
            Assert.Equivalent(expectedResults, actualResults);
        }

        [Then(@"Teacher click descending sorting in a column ""([^""]*)""")]
        public void ThenTeacherClickDescendingSortingInAColumn(string taskName)
        {
            GeneralStudentsProgressTeacherPage generalStudentsProgressTeacherPage;
            generalStudentsProgressTeacherPage = new GeneralStudentsProgressTeacherPage();
            generalStudentsProgressTeacherPage.MoveLeftTopScrollBar();
            generalStudentsProgressTeacherPage.ClickSortTopButton(taskName);
        }

        [Then(@"Teacher should see list ""([^""]*)"" after sort on CBA")]
        public void ThenTeacherShouldSeeListAfterSortOnCBA(string homeworkName,Table table)
        {
            var expectedResults = table.CreateSet<StudentsHomeworkResultModel>().ToList();
            var page = new GeneralStudentsProgressTeacherPage();
            var helper = new ModelsHelper();
            var actualResults = helper.GetHomeworkResultsByHomeworkName(page, homeworkName);
            Assert.Equivalent(expectedResults, actualResults);
        }
    }
}
