namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class StatisticsStepDefinitions
    {
        private IWebDriver _driver;

        [When(@"Open DevEdu web site")]
        public void WhenOpenDevEduWebSite()
        {
            _driver = SingleWebDriver.GetInstance();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
        }

        [When(@"Authorize user")]
        public void WhenAuthorizeAsAUser(Table table)
        {
            SwaggerSignInRequest signIn = table.CreateInstance<SwaggerSignInRequest>();
            var authorizationPage = new AuthorizationUnauthorizedPage();
            authorizationPage.OpenThisPage();
            authorizationPage.EnterEmail(signIn.Email);
            authorizationPage.EnterPassword(signIn.Password);
            authorizationPage.ClickEnterButton();
        }

        [When(@"teacher create new homework for group ""([^""]*)""")]
        public void WhenTeacherCreateNewHomeworkForGroup(string groupName, Table table)
        {
            AddNewHomework homework = table.CreateInstance<AddNewHomework>();
            var homeworkCreationPage = new HomeworkCreationTeacherPage();
            homeworkCreationPage.ClickAddHomeworksButton();
            homeworkCreationPage.ClickRadioButtonGroupName(groupName);
            homeworkCreationPage.InputStarDate(homework.StartDate);
            homeworkCreationPage.InputEndDate(homework.EndDate);
            homeworkCreationPage.InputNameHomework(homework.Name);
            homeworkCreationPage.InputDescriptionHomework(homework.Description);
            homeworkCreationPage.InputLink(homework.Link);
            homeworkCreationPage.ClickAddLinkButton();
            homeworkCreationPage.ClickPublishButton();
        }

        [When(@"User exit")]
        public void WhenUserExit()
        {
            var page = new HomeworkCreationTeacherPage();
            page.ClickExitButton();
        }

        [When(@"Students did their homework ""([^""]*)""")]
        public void WhenStudentsDidTheirHomework(string homeworkName, Table table)
        {
            var authorizationPage = new AuthorizationUnauthorizedPage();
            var homeworksStudentPage = new HomeworksStudentPage();
            var answerHomework = new HomeworkAnswerStudentsPage();
            string studentsAnswer = "https://github.com";
            List<SwaggerSignInRequest> _studensSignIn = table.CreateSet<SwaggerSignInRequest>().ToList();
            foreach (var student in _studensSignIn)
            {
                authorizationPage.EnterEmail(student.Email);
                authorizationPage.EnterPassword(student.Password);
                authorizationPage.ClickEnterButton();
                homeworksStudentPage.OpenThisPage();
                homeworksStudentPage.ClickGoToTaskButton(homeworkName);
                _driver.Navigate().Refresh();
                answerHomework.EnterAnswer(studentsAnswer);
                answerHomework.ClickSendAnswerButton();
                answerHomework.ClickExitButton();
            }
        }

        [When(@"Teacher rate homeworks")]
        public void WhenTeacherRateHomeworks(Table table)
        {
            var homeworkCheckingPage = new HomeworksCheckingTeacherPage();
            var studentsResults = table.CreateSet<StudentsHomeworkResultModel>().ToList();
            homeworkCheckingPage.OpenThisPage();
            foreach(var result in studentsResults)
            {
            //TODO: check homework page is empty now
            }
        }

        [Then(@"Teacher should see students results in homework ""([^""]*)"" page")]
        public void ThenTeacherShouldSeeStudentsResultsInHomeworkPage(string homeworkName, Table table)
        {
            var _homeworksTeacherPage = new HomeworksTeacherPage();
            _homeworksTeacherPage.OpenThisPage();
            _homeworksTeacherPage.ClickGoToTaskButton(homeworkName);
            var expectedResults = table.CreateSet<StudentsHomeworkResultModel>().ToList();
            var actualResultsElements = _homeworksTeacherPage.StudentsResults;
            var actualResults = new List<StudentsHomeworkResultModel>();
            for(int i = 1; i <= actualResultsElements.Count; i++)
            {
                string xpathName = $"//div[@class='homework-result-container']/div[@class='table-row'][{i}]/div[1]";
                string xpathResult = $"//div[@class='homework-result-container']/div[@class='table-row'][{i}]/div[3]";
                string studentsName = actualResultsElements[i-1].FindElement(By.XPath(xpathName)).Text;
                string studentsResult = actualResultsElements[i-1].FindElement(By.XPath(xpathResult)).Text;
                actualResults.Add(new StudentsHomeworkResultModel() { FullName = studentsName, Result = studentsResult });
            }
            Assert.Equal(expectedResults, actualResults);
        }
        
        [Then(@"teacher should see students results to homework ""([^""]*)"" in tab General Progress")]
        public void ThenTeacherShouldSeeStudentsResultsToHomeworkInTabGeneralProgress(string homeworkName, Table table)
        {
            var generalProgressTeacher = new GeneralStudentsProgressTeacherPage();
            generalProgressTeacher.OpenThisPage();
            //TODO: сделать чтобы были читаемы все элементы
            Thread.Sleep(15000); //уменьшить масштаб страницы, прокрутить ползунок, иначе не считывает информацию
            var expectedResults = new List<GeneralProgressResultsModel>();
            var expectedHWresults = table.CreateSet<StudentsHomeworkResultModel>().ToList();
            expectedResults.Add(new GeneralProgressResultsModel{ HomeworkName = homeworkName, StudentsHomeworkResults = expectedHWresults });
            var actualResults = GeneralProgressResultsModel.GetResults(generalProgressTeacher);
            Assert.Equal(expectedResults, actualResults);
        }
    }
}