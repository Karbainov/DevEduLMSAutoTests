namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class StatisticsStepDefinitions
    {
        private IWebDriver _driver;
        private SingInWindow _singInElements;
        private TeacherNavigatePanelElements _navigateButtons;
        private StudentsHomeworkWindow _studentsHomeworkWindowElements;
        private List<StudentsHomeworkResultModel> _studentsResults;
        private HomeworkResultsElements _homeworkResultsElements;
        private GeneralProgressWindow _generalProgressElements;
        private AuthorizationUnauthorizedPage _authorizationPage;
        private HomeworkCreationTeacherPage _homeworkCreationPage;

        public StatisticsStepDefinitions()
        {
            _driver = SingleWebDriver.GetInstance();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
            _singInElements = new SingInWindow();
            _navigateButtons = new TeacherNavigatePanelElements();
            _studentsHomeworkWindowElements = new StudentsHomeworkWindow();
            _studentsResults = new List<StudentsHomeworkResultModel>();
            _homeworkResultsElements = new HomeworkResultsElements();
            _generalProgressElements = new GeneralProgressWindow();
            _authorizationPage = new AuthorizationUnauthorizedPage(_driver);
            _homeworkCreationPage = new HomeworkCreationTeacherPage(_driver);
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
            _homeworkCreationPage.OpenThisPage();
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

        [When(@"students did their homework")]
        public void WhenStudentsDidTheirHomework(Table table)
        {
            Thread.Sleep(1000);
            List<SwaggerSignInRequest> _studensSignIn = table.CreateSet<SwaggerSignInRequest>().ToList();
            foreach(var student in _studensSignIn)
            {
                _driver.FindElement(_singInElements.XPathEmailBox).SendKeys(student.Email);
                _driver.FindElement(_singInElements.XPathPasswordBox).Clear();
                _driver.FindElement(_singInElements.XPathPasswordBox).SendKeys(student.Password);
                _driver.FindElement(_singInElements.XPathSingInButton).Click();
                Thread.Sleep(500);
                _driver.FindElement(_navigateButtons.XPathHomeworksButton).Click();
                Thread.Sleep(200);
                _driver.FindElement(_studentsHomeworkWindowElements.XPathGoToTaskButton).Click();
                _driver.Navigate().Refresh();
                Thread.Sleep(100);
                _driver.FindElement(_studentsHomeworkWindowElements.XPathLinkToAnswerTB).
                    SendKeys($"https://github.com");
                _driver.FindElement(_studentsHomeworkWindowElements.XPathSendAnswerButton).Click();
                _driver.FindElement(_navigateButtons.XPathExitButton).Click();
            }
        }

        [When(@"teacher rate homeworks")]
        public void WhenTeacherRateHomeworks(Table table)
        {
            _studentsResults = table.CreateSet<StudentsHomeworkResultModel>().ToList();
            Thread.Sleep(200);
            _driver.FindElement(_navigateButtons.XPathCheckHomeworksButton).Click();
            foreach(var result in _studentsResults)
            {

            }
            //check homework page is empty
        }

        [Then(@"teacher should see students results in homewok tab")]
        public void ThenTeacherShouldSeeStudentsResultsInHomewokTab()
        {
            _driver.FindElement(_navigateButtons.XPathHomeworksButton).Click();
            Thread.Sleep(300);
            _driver.FindElement(_studentsHomeworkWindowElements.XPathGoToTaskButton).Click();
            foreach (var result in _studentsResults)
            {
                By desiredElement = _homeworkResultsElements.
                    XPathStudentsResultByNameByResult(result.FullName, result.Result);
                var _expectedResult = _driver.FindElements(desiredElement).FirstOrDefault();
                //Assert.NotNull(_expectedResult);
            }
            Thread.Sleep(1000);
        }

        [Then(@"teacher should see students results in tab General Progress")]
        public void ThenTeacherShouldSeeStudentsResultsInTabGeneralProgress()
        {
            _driver.FindElement(_navigateButtons.XPathGeneralProgressButton).Click();
            Thread.Sleep(300);
            int expectedPassedHomework = 0;
            int expectedDeclinedHomework = 0;
            int actualPassedHomework;
            int actualDeclinedHomework;
            foreach(var result in _studentsResults)
            {
                if (result.Result == "�����")
                {
                    expectedPassedHomework++;
                }
                else if (result.Result == "�� �����")
                {
                    expectedDeclinedHomework++;
                }
            }
            actualPassedHomework =_driver.FindElements(_generalProgressElements.ByXpathAccept).Count;
            actualDeclinedHomework =_driver.FindElements(_generalProgressElements.ByXpathDecline).Count;
            //Assert.Equal(expectedPassedHomework, actualPassedHomework);
            //Assert.Equal(expectedDeclinedHomework, actualDeclinedHomework);
            _driver.Close();
        }
    }
}