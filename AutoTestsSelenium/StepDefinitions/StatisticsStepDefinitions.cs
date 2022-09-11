using DevEduLMSAutoTests.API.StepDefinitions;
using DevEduLMSAutoTests.API.Support.Models.Request;
using DevEduLMSAutoTests.API.Support;
using AutoTestsSelenium.Support.Models.SupportModels;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class StatisticsStepDefinitions
    {
        private TasksStepDefinitions _stepsBySwagger;
        protected List<SingInRequest> _allStudensSignIn;
        protected SingInRequest _teacherSignIn;
        protected List<SingInRequest> _allTeachersSignIn;
        protected List<SingInRequest> _allTutorsSignIn;
        protected List<SingInRequest> _allMethodistsSignIn;
        private IWebDriver _driver;
        private SingInWindow _singInElements;
        private NavigatePanelElements _navigateButtons;
        private string _groupName;
        private TeachersHomeworkWindow _teacersHomeworkWindowElements;
        private StudentsHomeworkWindow _studentsHomeworkWindowElements;
        private ClearTables clearDB;
        private List<StudentsHomeworkResults> _studentsResults;
        private HomeworkResultsElements _homeworkResultsElements;
        private GeneralProgressWindow _generalProgressElements;


        public StatisticsStepDefinitions()
        {
            _stepsBySwagger = new TasksStepDefinitions();
            _allStudensSignIn = new List<SingInRequest>();
            _allMethodistsSignIn = new List<SingInRequest>();
            _allTeachersSignIn = new List<SingInRequest>();
            _allTutorsSignIn = new List<SingInRequest>();
            _singInElements = new SingInWindow();
            _navigateButtons = new NavigatePanelElements();
            _teacersHomeworkWindowElements = new TeachersHomeworkWindow();
            _studentsHomeworkWindowElements = new StudentsHomeworkWindow();
            clearDB = new ClearTables();
            _studentsResults = new List<StudentsHomeworkResults>();
            _homeworkResultsElements = new HomeworkResultsElements();
            _generalProgressElements = new GeneralProgressWindow();
        }

        [Given(@"register new users with roles")]
        public void GivenRegisterNewUsersWithRoles(Table table)
        {
            clearDB.ClearDB();
            _stepsBySwagger.GivenRegisterNewUsersWithRoles(table);
            List<RegistationModelWithRole> users = table.CreateSet<RegistationModelWithRole>().ToList();
            foreach(var user in users)
            {
                switch (user.Role)
                {
                    case Options.RoleStudent:
                        _allStudensSignIn.Add(new SingInRequest() { Email = user.Email, Password = user.Password });
                        break;
                    case Options.RoleTeacher:
                        _allTeachersSignIn.Add(new SingInRequest() { Email = user.Email, Password = user.Password });
                        break;
                    case Options.RoleMethodist:
                        _allMethodistsSignIn.Add(new SingInRequest() { Email = user.Email, Password = user.Password });
                        break;
                    case Options.RoleTutor:
                        _allTutorsSignIn.Add(new SingInRequest() { Email = user.Email, Password = user.Password });
                        break;
                }
            }
            _teacherSignIn = _allTeachersSignIn.FirstOrDefault();
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
            _driver = new ChromeDriver();
            AddNewHomework homework = table.CreateInstance<AddNewHomework>();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
            Thread.Sleep(200);
            _driver.FindElement(_singInElements.XPathEmailBox).SendKeys(_teacherSignIn.Email);
            _driver.FindElement(_singInElements.XPathPasswordBox).Clear();
            _driver.FindElement(_singInElements.XPathPasswordBox).SendKeys(_teacherSignIn.Password);
            _driver.FindElement(_singInElements.XPathSingInButton).Click();
            Thread.Sleep(100);
            _driver.FindElement(_navigateButtons.XPathSwitchRoleButton).Click();
            _driver.FindElement(_navigateButtons.XPathRoleButton(Options.RoleTeacher)).Click();
            _driver.FindElement(_navigateButtons.XPathNewHomeworkButton).Click();
            _driver.FindElement(_teacersHomeworkWindowElements.XPathGroupRB).Click();
            var dateTB = _driver.FindElement(_teacersHomeworkWindowElements.XPathStartDateTextBox);
            Actions setDate = new Actions(_driver);
            setDate.DoubleClick(dateTB).
                SendKeys(homework.StartDate).
                Build().
                Perform();
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
            foreach(var student in _allStudensSignIn)
            {
                _driver.FindElement(_singInElements.XPathEmailBox).SendKeys(student.Email);
                _driver.FindElement(_singInElements.XPathPasswordBox).Clear();
                _driver.FindElement(_singInElements.XPathPasswordBox).SendKeys(student.Password);
                _driver.FindElement(_singInElements.XPathSingInButton).Click();
                Thread.Sleep(200);
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
            _studentsResults = table.CreateSet<StudentsHomeworkResults>().ToList();
            _driver.FindElement(_singInElements.XPathEmailBox).SendKeys(_teacherSignIn.Email);
            _driver.FindElement(_singInElements.XPathPasswordBox).Clear();
            _driver.FindElement(_singInElements.XPathPasswordBox).SendKeys(_teacherSignIn.Password);
            _driver.FindElement(_singInElements.XPathSingInButton).Click();
            Thread.Sleep(200);
            _driver.FindElement(_navigateButtons.XPathSwitchRoleButton).Click();
            _driver.FindElement(_navigateButtons.XPathRoleButton(Options.RoleTeacher)).Click();
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
            clearDB.ClearDB();
        }
    }
}
