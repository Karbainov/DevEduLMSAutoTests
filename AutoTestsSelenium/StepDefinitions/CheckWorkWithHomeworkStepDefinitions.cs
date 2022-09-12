using AutoTestsSelenium.Support.FindElements;
using AutoTestsSelenium.Support.Models.SupportModels;
using DevEduLMSAutoTests.API.StepDefinitions;
using DevEduLMSAutoTests.API.Support;
using DevEduLMSAutoTests.API.Support.Models.Request;
using FluentAssertions.Equivalency.Tracing;
using OpenQA.Selenium.DevTools.V102.Network;
using System.Threading.Channels;


namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class CheckWorkWithHomeworkStepDefinitions
    {
        private TasksStepDefinitions _stepsBySwagger;
        private List<SingInRequest> _studensSignIn;
        private ChangeRoleCombobox _changeRoleOfTeacher;
        private SingInRequest _teacherSingIn;
        private SingInRequest _methodist;
        private StudentAttachesHomework _studentAttachesHomework;
        private IWebDriver _driver;
        private SingInWindow _singInWindow;
        private NavigatePanelElements _navigateButtons;
        private string _groupName;
        private TeachersHomeworkWindow _teachersHomeworkWindowElements;
        private StudentsHomeworkWindow _studentsHomeworkWindowElements;
        private ClearTables clearDB;
        private List<StudentsHomeworkResults> _studentsResults;
        private HomeworkResultsElements _homeworkResultsElements;
        GeneralProgressWindow _generalProgressElements;

        public CheckWorkWithHomeworkStepDefinitions()
        {
            _stepsBySwagger = new TasksStepDefinitions();
            _studensSignIn = new List<SingInRequest>();
            _driver = new ChromeDriver();
            _singInWindow = new SingInWindow();
            _navigateButtons = new NavigatePanelElements();
            _teachersHomeworkWindowElements = new TeachersHomeworkWindow();
            _studentsHomeworkWindowElements = new StudentsHomeworkWindow();
            clearDB = new ClearTables();
            _studentsResults = new List<StudentsHomeworkResults>();
            _homeworkResultsElements = new HomeworkResultsElements();
            _generalProgressElements = new GeneralProgressWindow();
            _changeRoleOfTeacher = new ChangeRoleCombobox();
            _studentAttachesHomework = new StudentAttachesHomework();
        }

        [When(@"register users with and assigned roles")]
        public void WhenRegisterUsersWithAndAssignedRoles(Table table)
        {
            clearDB.ClearDB();
            _stepsBySwagger.GivenRegisterNewUsersWithRoles(table);
            List<RegistationModelWithRole> users = table.CreateSet<RegistationModelWithRole>().ToList();
            foreach (var user in users)
            {
                if (user.Role == "Student")
                {
                    _studensSignIn.Add(new SingInRequest() { Email = user.Email, Password = user.Password });
                }
                else if (user.Role == "Teacher")
                {
                    _teacherSingIn = new SingInRequest() { Email = user.Email, Password = user.Password };
                }
                else
                {
                    _methodist = new SingInRequest() { Email = user.Email, Password = user.Password };
                }
            }
        }

        [When(@"manager create new group")]
        public void WhenManagerCreateNewGroup(Table table)
        {           
            _groupName = _stepsBySwagger.GivenManagerCreateNewGroup(table);
            _teachersHomeworkWindowElements._groupName = _groupName;
        }

        [When(@"manager add users to group")]
        public void WhenManagerAddUsersToGroup()
        {
            _stepsBySwagger.GivenManagerAddUsersToGroup();
        }

        [Then(@"methodist create homework")]
        public void ThenMethodistCreateHomework(Table table)
        {
            _stepsBySwagger.GivenMethodistCreateNewTask(table);
        }

        [Then(@"authorization user as teacher")]
        public void ThenAuthorizationUserAsTeacher(Table table)
        {

            SingInRequest singInRequest = table.CreateInstance<SingInRequest>();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
            Thread.Sleep(1000);
            var emailBox = _driver.FindElement(_singInWindow.XPathEmailBox);
            emailBox.SendKeys(singInRequest.Email);
            var passBox = _driver.FindElement(_singInWindow.XPathPasswordBox);
            passBox.Clear();
            passBox.SendKeys(singInRequest.Password);
        }

        [Then(@"teacher click button issuing homework")]
        public void ThenTeacherClickButtonIssuingHomework()
        {
            var enter = _driver.FindElement(_singInWindow.XPathSingInButton);
            enter.Click();
            Thread.Sleep(500);
        }
        [Then(@"teacher changes role")]
        public void ThenTeacherChangesRole()
        {
            var combobox = _driver.FindElement(_changeRoleOfTeacher.XpathCombobox);
            combobox.Click();
            Thread.Sleep(500);
            var chanceRole = _driver.FindElement(_changeRoleOfTeacher.XpathChangeRole);
            chanceRole.Click();

        }

        [When(@"teacher create issuing homework")]
        public void WhenTeacherCreateIssuingHomework(Table table)
        {
            AddNewHomework homework = table.CreateInstance<AddNewHomework>();
            _driver.FindElement(_teachersHomeworkWindowElements.XPathIssuingHomework).Click();
            _driver.FindElement(_teachersHomeworkWindowElements.XPathGroupRB).Click();
            var dateTB = _driver.FindElement(_teachersHomeworkWindowElements.XPathStartDateTextBox);
            Actions setDate = new Actions(_driver);
            setDate.DoubleClick(dateTB).SendKeys(homework.StartDate).Build().Perform();
            dateTB = _driver.FindElement(_teachersHomeworkWindowElements.XPathEndDateTextBox);
            setDate.DoubleClick(dateTB).SendKeys(homework.EndDate).Build().Perform();
            CreateHomework createHomework = table.CreateInstance<CreateHomework>();
            var nameHomework = _driver.FindElement(_teachersHomeworkWindowElements.XPathNameTB);
            nameHomework.SendKeys(createHomework.Name);
            var textInput = _driver.FindElement(_teachersHomeworkWindowElements.XPathDescriptionTB);
            textInput.SendKeys(createHomework.Description);
            _driver.FindElement(_teachersHomeworkWindowElements.XPathLinkTB).SendKeys(createHomework.LinkToRecord);          
        }

        [Then(@"teacher click button publish")]
        public void ThenTeacherClickButtonPublish()
        {
            _driver.FindElement(_teachersHomeworkWindowElements.XPathPublishButton).Click();
        }

        [When(@"teacher see all task")]
        public void WhenSeeAllTask()
        {
            _driver.FindElement(_teachersHomeworkWindowElements.XpathHomework).Click();

        }

        [When(@"teacher click button exit")]
        public void WhenTeacherClickButtonExit()
        {
            _driver.FindElement(_singInWindow.XPathCancelSingInButton).Click();
        }

        [When(@"student authorization")]
        public void WhenStudentAuthorization(Table table)
        {
            SingInRequest singInRequest = table.CreateInstance<SingInRequest>();
            _driver.FindElement(_singInWindow.XPathEmailBox).SendKeys(singInRequest.Email);         
            var passBox = _driver.FindElement(_singInWindow.XPathPasswordBox);
            passBox.Clear();
            passBox.SendKeys(singInRequest.Password);
            _driver.FindElement(_singInWindow.XPathSingInButton).Click();
            Thread.Sleep(500);
        }

        [When(@"student click button homework")]
        public void WhenStudentClickButtonHomework()
        {
            _driver.FindElement(_navigateButtons.XPathHomeworksButton).Click();
            Thread.Sleep(500);
        }

        [When(@"studen click button to the task")]
        public void WhenStudenClickButtonToTheTask()
        {
            _driver.FindElement(_studentsHomeworkWindowElements.XPathGoToTaskButton).Click();
            Thread.Sleep(500);
        }

        [When(@"studen attaches a link to the completed task")]
        public void WhenStudenAttachesALinkToTheCompletedTask(Table table)
        {
            var linkGithub = _driver.FindElement(_studentsHomeworkWindowElements.XPathLinkToAnswerTB);
            linkGithub.Click();
            linkGithub.SendKeys(_studentAttachesHomework.LinkToGitHub);
            Thread.Sleep(500);
        }

        [When(@"studen click airplane icon")]
        public void WhenStudenClickAirplaneIcon()
        {
            _driver.FindElement(_studentsHomeworkWindowElements.XPathSendAnswerButton).Click();
            Thread.Sleep(500);
        }

        [When(@"studen click button exit")]
        public void WhenStudenClickButtonExit()
        {
            _driver.FindElement(_singInWindow.XPathCancelSingInButton).Click();
        }

        [When(@"authorization user as teacher")]
        public void WhenAuthorizationUserAsTeacher(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"teacher click botton to come in")]
        public void WhenTeacherClickBottonToComeIn()
        {
            throw new PendingStepException();
        }

        [When(@"teacher click button checking assignments")]
        public void WhenTeacherClickButtonCheckingAssignments()
        {
            throw new PendingStepException();
        }
    }
}
