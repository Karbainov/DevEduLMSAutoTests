namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class StatisticsStepDefinitions
    {
        private TasksStepDefinitions _stepsBySwagger;
        private List<SwaggerSignInRequest> _studensSignIn;
        private SwaggerSignInRequest _teacherSingIn;
        private IWebDriver _driver;
        private SingInWindow _singInElements;
        private TeacherNavigatePanelElements _navigateButtons;
        private string _groupName;
        private TeachersHomeworkWindow _teacersHomeworkWindowElements;
        private StudentsHomeworkWindow _studentsHomeworkWindowElements;
        private ClearTables _clearDB;
        private SwitchRole _switchRole;

        public StatisticsStepDefinitions()
        {
            _stepsBySwagger = new TasksStepDefinitions();
            _studensSignIn = new List<SwaggerSignInRequest>();
            _driver = new ChromeDriver();
            _singInElements = new SingInWindow();
            _navigateButtons = new TeacherNavigatePanelElements();
            _teacersHomeworkWindowElements = new TeachersHomeworkWindow();
            _studentsHomeworkWindowElements = new StudentsHomeworkWindow();
            _clearDB = new ClearTables();
            _switchRole = new SwitchRole();
        }

        [Given(@"register new users with roles")]
        public void GivenRegisterNewUsersWithRoles(Table table)
        {
            _clearDB.ClearDB();
            _stepsBySwagger.GivenRegisterNewUsersWithRoles(table);
            List<RegistationModelWithRole> users = table.CreateSet<RegistationModelWithRole>().ToList();
            foreach(var user in users)
            {
                if(user.Role == "Student")
                {
                    _studensSignIn.Add(new SwaggerSignInRequest() { Email=user.Email, Password = user.Password });
                }
                else if(user.Role == "Teacher")
                {
                    _teacherSingIn = new SwaggerSignInRequest() {Email=user.Email, Password=user.Password };
                }
            }
        }

        [Given(@"manager create new group")]
        public void GivenManagerCreateNewGroup(Table table)
        {
            _groupName = _stepsBySwagger.GivenManagerCreateNewGroup(table);
            _teacersHomeworkWindowElements._groupName = _groupName;
        }

        [Given(@"manager add users to group")]
        public void GivenManagerAddUsersToGroup()
        {
            _stepsBySwagger.GivenManagerAddUsersToGroup();
        }

        [When(@"teacher create new homework")]
        public void WhenTeacherCreateNewHomework(Table table)
        {
            AddNewHomework homework = table.CreateInstance<AddNewHomework>();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
            Thread.Sleep(200);
            _driver.FindElement(_singInElements.XPathEmailBox).SendKeys(_teacherSingIn.Email);
            _driver.FindElement(_singInElements.XPathPasswordBox).Clear();
            _driver.FindElement(_singInElements.XPathPasswordBox).SendKeys(_teacherSingIn.Password);
            _driver.FindElement(_singInElements.XPathSingInButton).Click();
            Thread.Sleep(100);
            _driver.FindElement(_navigateButtons.XPathSwitchRoleButton).Click();
            _driver.FindElement(_switchRole.XPathRoleButton(OptionsSwagger.RoleTeacher)).Click();
            _driver.FindElement(_navigateButtons.XPathNewHomeworkButton).Click();
            _driver.FindElement(_teacersHomeworkWindowElements.XPathGroupRB).Click();
            var dateTB = _driver.FindElement(_teacersHomeworkWindowElements.XPathStartDateTextBox);
            Actions setDate = new Actions(_driver);
            setDate.DoubleClick(dateTB).SendKeys(homework.StartDate).Build().Perform();
            dateTB = _driver.FindElement(_teacersHomeworkWindowElements.XPathEndDateTextBox);
            setDate.DoubleClick(dateTB).SendKeys(homework.EndDate).Build().Perform();
            _driver.FindElement(_teacersHomeworkWindowElements.XPathNameTB).SendKeys(homework.Name);
            _driver.FindElement(_teacersHomeworkWindowElements.XPathDescriptionTB).SendKeys(homework.Description);
            _driver.FindElement(_teacersHomeworkWindowElements.XPathLinkTB).SendKeys(homework.Link);
            _driver.FindElement(_teacersHomeworkWindowElements.XPathAddLinkButton).Click();
            _driver.FindElement(_teacersHomeworkWindowElements.XPathPublishButton).Click();
            _driver.FindElement(_navigateButtons.XPathExitButton).Click();
        }

        [When(@"students did their homework")]
        public void WhenStudentsDidTheirHomework()
        {
            foreach(var student in _studensSignIn)
            {
                _driver.FindElement(_singInElements.XPathEmailBox).SendKeys(student.Email);
                _driver.FindElement(_singInElements.XPathPasswordBox).Clear();
                _driver.FindElement(_singInElements.XPathPasswordBox).SendKeys(student.Password);
                _driver.FindElement(_singInElements.XPathSingInButton).Click();
                Thread.Sleep(100);
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

        [When(@"teacher accept or decline them")]
        public void WhenTeacherAcceptOrDeclineThem()
        {
            _driver.FindElement(_singInElements.XPathEmailBox).SendKeys(_teacherSingIn.Email);
            _driver.FindElement(_singInElements.XPathPasswordBox).Clear();
            _driver.FindElement(_singInElements.XPathPasswordBox).SendKeys(_teacherSingIn.Password);
            _driver.FindElement(_singInElements.XPathSingInButton).Click();
            Thread.Sleep(100);
            _driver.FindElement(_navigateButtons.XPathSwitchRoleButton).Click();
            _driver.FindElement(_switchRole.XPathRoleButton(OptionsSwagger.RoleTeacher)).Click();
            _driver.FindElement(_navigateButtons.XPathCheckHomeworksButton).Click();            
        }

        [Then(@"methodist should see statistics of students results")]
        public void ThenMethodistShouldSeeStatisticsOfStudentsResults()
        {
            throw new PendingStepException();
        }
    }
}
