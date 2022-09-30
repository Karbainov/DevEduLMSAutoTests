using OpenQA.Selenium.Support.Extensions;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class SortingInTheOverallProgressTabStepDefinitions
    {
        [When(@"Choose group ""([^""]*)""")]
        public void GivenChooseGroup(string groupName)
        {
            var generalProgress = new GeneralStudentsProgressTeacherPage();
            generalProgress.ClickDesiredGroup(groupName);
        }

        [When(@"Teacher sort students by surname")]
        public void WhenTeacherSortStudentsBySurname()
        {
            var generalProgress = new GeneralStudentsProgressTeacherPage();
            generalProgress.ClickSortBySurname();
        }

        [Then(@"Students should sort by surname")]
        public void ThenStudentsShouldSortBySurname(Table table)
        {
            var generalProgress = new GeneralStudentsProgressTeacherPage();
            generalProgress.MoveLeftTopScrollBar();
            var driver = SingleWebDriver.GetInstance();
            driver.ExecuteJavaScript("document.body.style.zoom='0.5'");
            var studentsResults = table.CreateSet<StudentsHomeworkResultModel>().ToList();
            List<string> expected = new List<string>();
            foreach (var student in studentsResults)
            {
                expected.Add(student.FullName);
            }
            foreach (var student in studentsResults)
            {
                expected.Add(student.Result);
            }
            List<IWebElement> students = generalProgress.GetAllFullNames();
            List<string> studentResult = new List<string>();
            foreach (var student in students)
            {
                studentResult.Add(student.Text);
            }
            List<IWebElement> results = generalProgress.GetAllResults();
            foreach (var result in results)
            {
                studentResult.Add(result.Text);
            }
            Assert.Equal(expected, studentResult);
        }

        [When(@"Teacher open tab General Progress")]
        public void WhenTeacherOpenTabGeneralProgress()
        {
            var homeworksTeacherPage = new HomeworksTeacherPage();
            homeworksTeacherPage.ClickGeneralProgressButton();
            //TODO Mock(Tack 2.27)
        }

        [When(@"Teacher click ascending sorting in a column ""([^""]*)""")]
        public void WhenTeacherClickAscendingSortingInAColumn(string taskName)
        {
            var generalStudentsProgressTeacherPage = new GeneralStudentsProgressTeacherPage();
            generalStudentsProgressTeacherPage.MoveLeftTopScrollBar();
            generalStudentsProgressTeacherPage.ClickSortBottomButton(taskName);
        }

        [Then(@"Teacher should see list ""([^""]*)"" after sort on ABC")]
        public void ThenTeacherShouldSeeListAfterSortOnABC(string homeworkName, Table table)
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
            var generalStudentsProgressTeacherPage = new GeneralStudentsProgressTeacherPage();
            generalStudentsProgressTeacherPage.MoveLeftTopScrollBar();
            generalStudentsProgressTeacherPage.ClickSortTopButton(taskName);
        }

        [Then(@"Teacher should see list ""([^""]*)"" after sort on CBA")]
        public void ThenTeacherShouldSeeListAfterSortOnCBA(string homeworkName, Table table)
        {
            var expectedResults = table.CreateSet<StudentsHomeworkResultModel>().ToList();
            var page = new GeneralStudentsProgressTeacherPage();
            var helper = new ModelsHelper();
            var actualResults = helper.GetHomeworkResultsByHomeworkName(page, homeworkName);
            Assert.Equivalent(expectedResults, actualResults);
        }
    }
}