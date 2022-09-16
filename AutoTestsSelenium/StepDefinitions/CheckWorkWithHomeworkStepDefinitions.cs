using AutoTestsSelenium.PageObjects;
using AutoTestsSelenium.Support.FindElements;
using AutoTestsSelenium.Support.Models;
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
        private IWebDriver _driver;
        private SingInWindow _singInWindow;
        private NavigatePanelElements _navigateButtons;
        private string _groupName;
        private TeachersHomeworkWindow _teachersHomeworkWindowElements;
        private StudentsHomeworkWindow _studentsHomeworkWindowElements;
        private ClearTables clearDB;
        private AuthorizationUnauthorizedPage _authorizationUnauthorizedPage;
        private AbstractTeacherAuthorizedPage _abstractTeacherAuthorizedPage;
        private AbstractAuthorizedPage _abstractAuthorizedPage;

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
            _changeRoleOfTeacher = new ChangeRoleCombobox();
            _authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage(_driver);
           
    }

        [When(@"Register users with and assigned roles")]
        public void WhenRegisterUsersWithAndAssignedRoles(Table table)
        {
            clearDB.ClearDB();
            _stepsBySwagger.GivenRegisterNewUsersWithRoles(table);
        }

        [When(@"Manager create new group")]
        public void WhenManagerCreateNewGroup(Table table)
        {           
            _groupName = _stepsBySwagger.GivenManagerCreateNewGroup(table);
            _teachersHomeworkWindowElements._groupName = _groupName;
        }

        [When(@"Manager add users to group")]
        public void WhenManagerAddUsersToGroup()
        {
            _stepsBySwagger.GivenManagerAddUsersToGroup();
        }

        [Then(@"Methodist create homework")]
        public void ThenMethodistCreateHomework(Table table)
        {
            _stepsBySwagger.GivenMethodistCreateNewTask(table);
        }

        [Then(@"Authorization user as teacher")]
        public void ThenAuthorizationUserAsTeacher(Table table)
        {

            SingInRequest singInRequest = table.CreateInstance<SingInRequest>();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
            Thread.Sleep(1000);
            _authorizationUnauthorizedPage.EnterEmail(singInRequest.Email);
            _authorizationUnauthorizedPage.EnterPassword(singInRequest.Password);
            _authorizationUnauthorizedPage.ClickEnterButton();
            Thread.Sleep(500);
        }

        [Then(@"Teacher changes role")]
        public void ThenTeacherChangesRole()
        {
            _abstractAuthorizedPage.ClickNameButton();         
            Thread.Sleep(500);
            _abstractAuthorizedPage.ChageRole(Options.RoleTeacher);
        }
        [Then(@"Teacher click button issuing homework")]
        public void ThenTeacherClickButtonIssuingHomework()
        {
            _abstractTeacherAuthorizedPage.ButtonAddHomewrksSideBar.Click();
            Thread.Sleep(500);
        }

        [When(@"Teacher create issuing homework")]
        public void WhenTeacherCreateIssuingHomework(Table table)
        {
            AddNewHomework homework = table.CreateInstance<AddNewHomework>();
            _driver.FindElement(_navigateButtons.XPathIssuingHomework).Click();
            _driver.FindElement(_teachersHomeworkWindowElements.XPathGroupRB).Click();
            var dateTB = _driver.FindElement(_teachersHomeworkWindowElements.XPathStartDateTextBox);
            dateTB.Clear();
            Actions setDate = new Actions(_driver);
            setDate.DoubleClick(dateTB).SendKeys(homework.StartDate).Build().Perform();
            dateTB = _driver.FindElement(_teachersHomeworkWindowElements.XPathEndDateTextBox);
            dateTB.Clear();
            setDate.DoubleClick(dateTB).SendKeys(homework.EndDate).Build().Perform();
            CreateHomework createHomework = table.CreateInstance<CreateHomework>();
            var nameHomework = _driver.FindElement(_teachersHomeworkWindowElements.XPathNameTB);
            nameHomework.SendKeys(createHomework.Name);
            var textInput = _driver.FindElement(_teachersHomeworkWindowElements.XPathDescriptionTB);
            textInput.SendKeys(createHomework.Description);
            _driver.FindElement(_teachersHomeworkWindowElements.XPathLinkTB).SendKeys(createHomework.LinkToRecord);          
        }

        [Then(@"Teacher click button publish")]
        public void ThenTeacherClickButtonPublish()
        {
            _driver.FindElement(_teachersHomeworkWindowElements.XPathPublishButton).Click();
        }

        [When(@"Teacher see all task")]
        public void WhenSeeAllTask()
        {
            _driver.FindElement(_navigateButtons.XPathHomeworksButton).Click();

        }

        [When(@"Teacher click button exit")]
        public void WhenTeacherClickButtonExit()
        {
            _driver.FindElement(_singInWindow.XPathCancelSingInButton).Click();
        }

        [When(@"Student authorization")]
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

        [When(@"Student click button homework")]
        public void WhenStudentClickButtonHomework()
        {
            _driver.FindElement(_navigateButtons.XPathHomeworksButton).Click();
            Thread.Sleep(500);
        }

        [When(@"Studen click button to the task")]
        public void WhenStudenClickButtonToTheTask()
        {
            _driver.FindElement(_studentsHomeworkWindowElements.XPathGoToTaskButton).Click();
            Thread.Sleep(500);
        }

        [When(@"Studen attaches a link to the completed task")]
        public void WhenStudenAttachesALinkToTheCompletedTask(Table table)
        {
            StudentAttachesHomework studentAttachesHomework = table.CreateInstance<StudentAttachesHomework>();
            var linkGithub = _driver.FindElement(_studentsHomeworkWindowElements.XPathLinkToAnswerTB);
            linkGithub.Click();
            linkGithub.SendKeys(studentAttachesHomework.LinkToGitHub);
        }

        [When(@"Studen click airplane icon")]
        public void WhenStudenClickAirplaneIcon()
        {
            _driver.FindElement(_studentsHomeworkWindowElements.XPathSendAnswerButton).Click();
        }

        [When(@"Studen click button exit")]
        public void WhenStudenClickButtonExit()
        {
            _driver.FindElement(_singInWindow.XPathCancelSingInButton).Click();
        }

        [When(@"Teacher checks homework")]
        public void WhenTeacherChecksHomework(Table table)
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
            var enter = _driver.FindElement(_singInWindow.XPathSingInButton);
            enter.Click();
            Thread.Sleep(500);
            var combobox = _driver.FindElement(_changeRoleOfTeacher.XpathCombobox);
            combobox.Click();
            Thread.Sleep(500);
            var chanceRole = _driver.FindElement(_changeRoleOfTeacher.XpathChangeRole);
            chanceRole.Click();
            _driver.FindElement(_navigateButtons.XPathCheckHomeworksButton).Click();
        }

        [Then(@"Teacher returned homework")]
        public void ThenTeacherReturnedHomework()
        {
            throw new PendingStepException();
        }

        [When(@"Student attached link of corrected homework")]
        public void WhenStudentAttachedLinkOfCorrectedHomework()
        {
            throw new PendingStepException();
        }

        [Then(@"Teacher accepted homework")]
        public void ThenTeacherAcceptedHomework()
        {
            throw new PendingStepException();
        }
    }
}
