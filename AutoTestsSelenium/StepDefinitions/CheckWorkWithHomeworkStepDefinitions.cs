using FluentAssertions.Equivalency.Tracing;

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
        private HomeworksTeacherPage _homeworksTeacherPage;
        private HomeworksDraftTeacherPage _homeworksDraftTeacherPage;
        private HomeworkCreationMethodistPage _homeworkMethodist;

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
            _homeworksTeacherPage = new HomeworksTeacherPage(_driver);
            _homeworksDraftTeacherPage = new HomeworksDraftTeacherPage(_driver);
            _homeworkMethodist = new HomeworkCreationMethodistPage(_driver);
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
            _homeworkMethodist.ClickChoiceGroupNumber();
            AddNewHomework createHomework = table.CreateInstance<AddNewHomework>();
            _homeworkMethodist.InputNameGroup(createHomework.Name);
            _homeworkMethodist.InputDescriptionHomework(createHomework.Description);
            _homeworkMethodist.InputLinkHomework(createHomework.Link);
            _homeworkMethodist.ClickButtonAttachLink();
            //TODO teacher does not see homework in saved assignments (Task 2.5)
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

        [Then(@"Teacher lays out the task ""([^""]*)"" created by the methodologist")]
        public void ThenTeacherLaysOutTheTaskCreatedByTheMethodologist(string nameHomework)
        {
            _lessonsTeacherPage.ClickHomeworksButton();
            _homeworksTeacherPage.ClickSavedHomeworkButton();
            _homeworksDraftTeacherPage.ClickEditHomeworkButton(nameHomework);
            //TODO �o task, emptiness (Task 2.5)
        }    

        [When(@"Teacher create issuing homework")]
        public void WhenTeacherCreateIssuingHomework(Table table)
        {
            AddNewHomework homework = table.CreateInstance<AddNewHomework>();
            _homeworkExtraditionTeacherPage.ClickNumberGroupRadiobox(_groupName);
            _homeworkExtraditionTeacherPage.InputStarDate(homework.StartDate);
            _homeworkExtraditionTeacherPage.InputEndDate(homework.EndDate);
            _homeworkExtraditionTeacherPage.InputNameHomework(homework.Name);
            _homeworkExtraditionTeacherPage.InputDescriptionHomework(homework.Description);
            _homeworkExtraditionTeacherPage.InputUsefulLinks(homework.Link);
            _homeworkExtraditionTeacherPage.ClickAddLink();
            //TODO �o task, emptiness (Task 2.5)
        }

        [Then(@"Teacher click button publish")]
        public void ThenTeacherClickButtonPublish()
        {
            _homeworkExtraditionTeacherPage.ClickPublish();
            //TODO �o task, emptiness (Task 2.5)
        }

        [When(@"Teacher see all task")]
        public void WhenSeeAllTask()
        {
            _lessonsTeacherPage.ClickAddHomeworksButton();           
            _lessonsTeacherPage.ClickExitButton();
            //TODO �o task, emptiness (Task 2.5)
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

        [When(@"Studen attaches a link ""([^""]*)"" to the completed task")]
        public void WhenStudenAttachesALinkToTheCompletedTask(string link)
        {
            _homeworksStudent.InputLinkAnswer(link);
            //TODO �o task, emptiness (Task 2.5)
        }      

        [When(@"Studen click airplane icon")]
        public void WhenStudenClickAirplaneIcon()
        {
            _homeworksStudent.SendAnswerButton();
            _lessonsTeacherPage.ClickExitButton();
            //TODO �o task, emptiness (Task 2.5)
        }

        [When(@"Teacher checks homework")]
        public void WhenTeacherChecksHomework(Table table)
        {
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
            Thread.Sleep(500);
            _lessonsTeacherPage.ChageRole(checkingModel.Role);
            _lessonsTeacherPage.ClickCheckHomeworksButton();
            //TODO �o task, emptiness (Task 2.5)
        }

        [Then(@"Teacher returned homework")]
        public void ThenTeacherReturnedHomework()
        {
            throw new PendingStepException();
            //TODO Blank sheet task 2.5
        }

        [When(@"Student attached link ""([^""]*)"" of corrected homework")]
        public void WhenStudentAttachedLinkOfCorrectedHomework(string link, Table table)
        {
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
            Thread.Sleep(500);
            _lessonsTeacherPage.ClickHomeworksButton();
            _homeworksStudent.GoToTaskButton();
            _homeworksStudent.InputLinkAnswer(link);
            _homeworksStudent.SendAnswerButton();
            _lessonsTeacherPage.ClickExitButton();
            //TODO �o task, emptiness (Task 2.5)
        }     

        [Then(@"Teacher accepted homework")]
        public void ThenTeacherAcceptedHomework(Table table)
        {
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
            Thread.Sleep(500);
            _lessonsTeacherPage.ChageRole(checkingModel.Role);
            _lessonsTeacherPage.ClickCheckHomeworksButton();
            //TODO do not continue step due to missing step:Teacher returned homework
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