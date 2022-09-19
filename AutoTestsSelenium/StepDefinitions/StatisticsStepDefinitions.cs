namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class StatisticsStepDefinitions
    {
        private IWebDriver _driver;
        private List<StudentsHomeworkResultModel> _studentsResults;
        private AuthorizationUnauthorizedPage _authorizationPage;
        private HomeworkCreationTeacherPage _homeworkCreationPage;
        private HomeworksStudentPage _homeworksStudentPage;
        private HomeworkAnswerStudentsPage _answerHomework;
        private HomeworksCheckingTeacherPage _homeworksCheckingPage;
        private HomeworksTeacherPage _homeworksTeacherPage;
        private GeneralStudentsProgressTeacherPage _generalProgressTeacher;

        public StatisticsStepDefinitions()
        {
            _driver = SingleWebDriver.GetInstance();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
            _studentsResults = new List<StudentsHomeworkResultModel>();
            _authorizationPage = new AuthorizationUnauthorizedPage(_driver);
            _homeworkCreationPage = new HomeworkCreationTeacherPage(_driver);
            _homeworksStudentPage = new HomeworksStudentPage(_driver);
            _answerHomework = new HomeworkAnswerStudentsPage(_driver);
            _homeworksCheckingPage = new HomeworksCheckingTeacherPage(_driver);
            _homeworksTeacherPage = new HomeworksTeacherPage(_driver);
            _generalProgressTeacher = new GeneralStudentsProgressTeacherPage(_driver);
        }

        [When(@"Authorize as a teacher")]
        public void WhenAuthorizeAsATeacher(Table table)
        {
            SwaggerSignInRequest signIn = table.CreateInstance<SwaggerSignInRequest>();
            _authorizationPage.OpenThisPage();
            _authorizationPage.EnterEmail(signIn.Email);
            _authorizationPage.EnterPassword(signIn.Password);
            _authorizationPage.ClickEnterButton();
        }

        [When(@"teacher create new homework for group ""([^""]*)""")]
        public void WhenTeacherCreateNewHomeworkForGroup(string groupName, Table table)
        {
            AddNewHomework homework = table.CreateInstance<AddNewHomework>();
            _homeworkCreationPage.ClickAddHomeworksButton();
            _homeworkCreationPage.ClickRadioButtonGroupName(groupName);
            _homeworkCreationPage.InputStarDate(homework.StartDate);
            _homeworkCreationPage.InputEndDate(homework.EndDate);
            _homeworkCreationPage.InputNameHomework(homework.Name);
            _homeworkCreationPage.InputDescriptionHomework(homework.Description);
            _homeworkCreationPage.InputLink(homework.Link);
            _homeworkCreationPage.ClickAddLinkButton();
            _homeworkCreationPage.ClickPublishButton();
            _homeworkCreationPage.ClickExitButton();
        }

        [When(@"Students did their homework ""([^""]*)""")]
        public void WhenStudentsDidTheirHomework(string homeworkName, Table table)
        {
            string studentsAnswer = "https://github.com";
            List<SwaggerSignInRequest> _studensSignIn = table.CreateSet<SwaggerSignInRequest>().ToList();
            foreach (var student in _studensSignIn)
            {
                _authorizationPage.EnterEmail(student.Email);
                _authorizationPage.EnterPassword(student.Password);
                _authorizationPage.ClickEnterButton();
                _homeworksStudentPage.OpenThisPage();
                _homeworksStudentPage.ClickGoToTaskButton(homeworkName);
                _driver.Navigate().Refresh();
                _answerHomework.EnterAnswer(studentsAnswer);
                _answerHomework.ClickSendAnswerButton();
                _answerHomework.ClickExitButton();
            }
        }

        [When(@"Teacher rate homeworks")]
        public void WhenTeacherRateHomeworks(Table table)
        {
            _studentsResults = table.CreateSet<StudentsHomeworkResultModel>().ToList();
            _homeworksCheckingPage.OpenThisPage();
            foreach(var result in _studentsResults)
            {

            }
            //TODO: check homework page is empty now
        }

        [Then(@"Teacher should see students results in homework ""([^""]*)"" page")]
        public void ThenTeacherShouldSeeStudentsResultsInHomeworkPage(string homeworkName)
        {
            _homeworksTeacherPage.OpenThisPage();
            _homeworksTeacherPage.ClickGoToTaskButton(homeworkName);
            var actualResults = _homeworksTeacherPage.StudentsResults;
            foreach(var result in actualResults)
            {
                string resultText = result.Text;
                Assert.Contains("ss", resultText);
                //как написать проверку????
            }
        }

        [Then(@"teacher should see students results in tab General Progress")]
        public void ThenTeacherShouldSeeStudentsResultsInTabGeneralProgress()
        {
            _generalProgressTeacher.OpenThisPage();
            //как написать проверку???
        }
    }
}