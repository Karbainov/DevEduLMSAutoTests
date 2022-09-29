using AutoTestsSelenium.PageObjects;
using TechTalk.SpecFlow.Assist;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class SortingInTheOverallProgressTabStepDefinitions
    {
        [Given(@"Teacher go to common progress")]
        public void GivenTeacherGoToCommonProgress()
        {
            var journalTeacherPage = new JournalTeacherPage();
            journalTeacherPage.ClickJournalButton();
        }

        [When(@"Teacher sort students by surname")]
        public void WhenTeacherSortStudentsBySurname()
        {
            var journalTeacherPage = new JournalTeacherPage();
            journalTeacherPage.ClickSortBySurname();
        }

        [Then(@"Students should sort by surname")]
        public void ThenStudentsShouldSortBySurname(Table table)
        {
            List<StudentsHomeworkResultModel> studentsResults = table.CreateSet<StudentsHomeworkResultModel>().ToList();

        }
    }
}
