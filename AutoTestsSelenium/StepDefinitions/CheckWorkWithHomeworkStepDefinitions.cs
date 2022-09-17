using AutoTestsSelenium.PageObjects;
using TechTalk.SpecFlow;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class CheckWorkWithHomeworkStepDefinitions
    {
        private TasksStepDefinitions _stepsBySwagger;
        private IWebDriver _driver;
        private string _groupName;
        private TeachersHomeworkWindow _teachersHomeworkWindowElements;
        private DBCleaner _tablesClear;
        private AuthorizationUnauthorizedPage _authorizationUnauthorizedPage;
        private LessonsTeacherPage _lessonsTeacherPage;
        private HomeworkExtraditionTeacherPage _homeworkExtraditionTeacherPage;
        private HomeworksStudentPage _homeworksStudent;

        public CheckWorkWithHomeworkStepDefinitions()
        {
            _stepsBySwagger = new TasksStepDefinitions();          
            _driver = new ChromeDriver();
            _teachersHomeworkWindowElements = new TeachersHomeworkWindow();
            _tablesClear = new DBCleaner();
            _authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage(_driver);
            _lessonsTeacherPage = new LessonsTeacherPage(_driver);
            _homeworkExtraditionTeacherPage= new HomeworkExtraditionTeacherPage(_driver);
            _homeworksStudent = new HomeworksStudentPage(_driver);
        }
   
        [When(@"Register users with and assigned roles")]
        public void WhenRegisterUsersWithAndAssignedRoles(Table table)
        {
            _tablesClear.ClearDB();
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
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
            Thread.Sleep(500);
            _lessonsTeacherPage.ChageRole(checkingModel.Role);
            Thread.Sleep(500);
        }
      
        [Then(@"Teacher click button issuing homework")]
        public void ThenTeacherClickButtonIssuingHomework()
        {
            _lessonsTeacherPage.ClickAddHomeworksButton();
            Thread.Sleep(500);
        }

        [When(@"Teacher create issuing homework")]
        public void WhenTeacherCreateIssuingHomework(Table table)
        {
            AddNewHomework homework = table.CreateInstance<AddNewHomework>();
            _homeworkExtraditionTeacherPage.GetNumberGroup(_groupName).Click();
            _homeworkExtraditionTeacherPage.InputStarDate(homework.StartDate);
            _homeworkExtraditionTeacherPage.InputEndDate(homework.EndDate);
            _homeworkExtraditionTeacherPage.InputNameHomework(homework.Name);
            _homeworkExtraditionTeacherPage.InputDescriptionHomework(homework.Description);
            _homeworkExtraditionTeacherPage.InputUsefulLinks(homework.Link);
            _homeworkExtraditionTeacherPage.ClickAddLink();                    
        }

        [Then(@"Teacher click button publish")]
        public void ThenTeacherClickButtonPublish()
        {
            _homeworkExtraditionTeacherPage.ClickPublish();
        }

        [When(@"Teacher see all task")]
        public void WhenSeeAllTask()
        {
            _lessonsTeacherPage.ClickAddHomeworksButton();           
        }

        [When(@"Teacher click button exit")]
        public void WhenTeacherClickButtonExit()
        {
            _lessonsTeacherPage.ClickExitButton();
        }

        [When(@"Student authorization")]
        public void WhenStudentAuthorization(Table table)
        {
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });         
            Thread.Sleep(500);
        }

        [When(@"Student click button homework")]
        public void WhenStudentClickButtonHomework()
        {
            _lessonsTeacherPage.ClickHomeworksButton();
            Thread.Sleep(500);
        }

        [When(@"Studen click button to the task")]
        public void WhenStudenClickButtonToTheTask()
        {
            _homeworksStudent.GoToTaskButton();
            Thread.Sleep(500);
        }

        [When(@"Studen attaches a link to the completed task")]
        public void WhenStudenAttachesALinkToTheCompletedTask(Table table)
        {
            StudentAttachesHomework studentAttachesHomework = table.CreateInstance<StudentAttachesHomework>();
            _homeworksStudent.InputLinkAnswer(studentAttachesHomework.LinkToGitHub);
        }

        [When(@"Studen click airplane icon")]
        public void WhenStudenClickAirplaneIcon()
        {
            _homeworksStudent.SendAnswerButton();
        }

        [When(@"Studen click button exit")]
        public void WhenStudenClickButtonExit()
        {

            _lessonsTeacherPage.ClickExitButton();
        }

        [When(@"Teacher checks homework")]
        public void WhenTeacherChecksHomework(Table table)
        {
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
            Thread.Sleep(500);
            _lessonsTeacherPage.ChageRole(checkingModel.Role);
            Thread.Sleep(500);
            _lessonsTeacherPage.ClickCheckHomeworksButton();
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

        private void AuthorizeUser(SwaggerSignInRequest user)
        {
            _driver.Manage().Window.Maximize();
            _authorizationUnauthorizedPage.OpenThisPage();
            _authorizationUnauthorizedPage.EnterEmail(user.Email);
            _authorizationUnauthorizedPage.EnterPassword(user.Password);
            _authorizationUnauthorizedPage.ClickEnterButton();
        }
    }
}
