namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class TeacherSortsStudentsByStatusDefinitions
    {
        private IWebDriver _driver;

        [When(@"Open DevEdu site https://piter-education\.ru:(.*)/login")]
        public void WhenOpenDevEduSiteHttpsPiter_Education_RuLogin(int p0)
        {
            _driver = SingleWebDriver.GetInstance();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
        }

        [When(@"Teacher create new homework for new group ""([^""]*)""")]
        public void WhenTeacherCreateNewHomeworkForNewGroup(string nameGroup, Table table)
        {
            HomeworkCreationTeacherPage homeworkCreationTeacherPage;
            homeworkCreationTeacherPage = new HomeworkCreationTeacherPage();
            homeworkCreationTeacherPage.ClickHomeworksButton();
            homeworkCreationTeacherPage.ClickCreateHomework();
            AddNewHomework homework = table.CreateInstance<AddNewHomework>();
            homeworkCreationTeacherPage.ClickRadioButtonGroupName(nameGroup);
            homeworkCreationTeacherPage.InputStarDate(homework.StartDate);
            homeworkCreationTeacherPage.InputEndDate(homework.EndDate);
            homeworkCreationTeacherPage.InputNameHomework(homework.Name);
            homeworkCreationTeacherPage.InputDescriptionHomework(homework.Description);
            homeworkCreationTeacherPage.InputLink(homework.Link);
            homeworkCreationTeacherPage.ClickAddLinkButton();
            homeworkCreationTeacherPage.ClickPublishButton();
        }

        [When(@"Teacher should see students results to homework ""([^""]*)"" in tab General Progress")]
        public void WhenTeacherShouldSeeStudentsResultsToHomeworkInTabGeneralProgress(string homeworkName, Table table)
        {
            var _homeworksTeacherPage = new HomeworksTeacherPage();
            _homeworksTeacherPage.OpenThisPage();
            _homeworksTeacherPage.ClickGoToTaskButton(homeworkName);
            var expectedResults = table.CreateSet<StudentsHomeworkResultModel>().ToList();
            var actualResultsElements = _homeworksTeacherPage.StudentsResults;
            var actualResults = new List<StudentsHomeworkResultModel>();
            for (int i = 1; i <= actualResultsElements.Count; i++)
            {
                string xpathName = $"//div[@class='homework-result-container']/div[@class='table-row'][{i}]/div[1]";
                string xpathResult = $"//div[@class='homework-result-container']/div[@class='table-row'][{i}]/div[3]";
                string studentsName = actualResultsElements[i - 1].FindElement(By.XPath(xpathName)).Text;
                string studentsResult = actualResultsElements[i - 1].FindElement(By.XPath(xpathResult)).Text;
                actualResults.Add(new StudentsHomeworkResultModel() { FullName = studentsName, Result = studentsResult });
            }
            Assert.Equal(expectedResults, actualResults);
        }

        [When(@"Teacher click ascending sorting in a column ""([^""]*)""")]
        public void WhenTeacherClickAscendingSortingInAColumn(string taskName)
        {
            GeneralStudentsProgressTeacherPage generalStudentsProgressTeacherPage;
            generalStudentsProgressTeacherPage= new GeneralStudentsProgressTeacherPage();
            generalStudentsProgressTeacherPage.ClickSortBottomButton(taskName);
        }

        [Then(@"Teacher see list after sort")]
        public void ThenTeacherSeeListAfterSort()
        {
            throw new PendingStepException();
        }

        [Then(@"Teacher click descending sorting in a column ""([^""]*)""")]
        public void ThenTeacherClickDescendingSortingInAColumn(string покрыть)
        {
            throw new PendingStepException();
        }
    }
}
