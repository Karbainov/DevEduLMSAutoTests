using OpenQA.Selenium.Support.Extensions;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class SortingInTheOverallProgressTabStepDefinitions
    {
        [Given(@"Teacher go to common progress")]
        public void GivenTeacherGoToCommonProgress()
        {
            var generalProgress = new GeneralStudentsProgressTeacherPage();
            generalProgress.ClickGeneralProgressButton();
        }

        [Given(@"Choose group ""([^""]*)""")]
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
            List<StudentsHomeworkResultModel> studentsResults = table.CreateSet<StudentsHomeworkResultModel>().ToList();
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
    }
}
