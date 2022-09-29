using AutoTestsSelenium.PageObjects;
using TechTalk.SpecFlow;

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
            var actualResults = helper.GetReducedScale(generalStudentsProgressTeacherPage);
            generalStudentsProgressTeacherPage.ClickSortBottomButton(taskName);
        }

        [Then(@"Teacher should see list after sort on ABC")]
        public void ThenTeacherShouldSeeListAfterSortOnABC(Table table)
        {
            var _homeworksTeacherPage = new HomeworksTeacherPage();
            var expectedResults = table.CreateSet<StudentsHomeworkResultModel>().ToList();
            var actualResultsElements = _homeworksTeacherPage.StudentsResults;
            var actualResults = new List<StudentsHomeworkResultModel>();
            for (int i = 1; i <= actualResultsElements.Count; i++)
            {
                string xpathName = $"//div[@class='list-container']/div[{i}]";
                string xpathResult = $"//div[@class='swiper swiper-initialized swiper-horizontal swiper-pointer-events swiper-backface-hidden']/div[@class='swiper-wrapper']/div[@class='swiper-slide swiper-slide-active']/div[@class='one-block block-column'][{i}]";
                string studentsName = actualResultsElements[i - 1].FindElement(By.XPath(xpathName)).Text;
                string studentsResult = actualResultsElements[i - 1].FindElement(By.XPath(xpathResult)).Text;
                actualResults.Add(new StudentsHomeworkResultModel() { FullName = studentsName, Result = studentsResult });
            }
            Assert.Equal(expectedResults, actualResults);
        }

        [Then(@"Teacher click descending sorting in a column ""([^""]*)""")]
        public void ThenTeacherClickDescendingSortingInAColumn(string taskName)
        {
            GeneralStudentsProgressTeacherPage generalStudentsProgressTeacherPage;
            generalStudentsProgressTeacherPage = new GeneralStudentsProgressTeacherPage();
            generalStudentsProgressTeacherPage.ClickSortBottomButton(taskName);
        }

        [Then(@"Teacher should see list after sort on CBA")]
        public void ThenTeacherShouldSeeListAfterSortOnCBA(Table table)
        {
            throw new PendingStepException();
        }
    }
}
