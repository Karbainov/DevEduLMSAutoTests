using AutoTestsSelenium.PageObjects;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class CreatingHomeworkByMethodologist
    {
        private MethodistHomeworkWindow _methodistHomeworkWindow;
        private HomeworkCreationMethodistPage _homeworkMethodist;
        private AuthorizationUnauthorizedPage _authorizationUnauthorizedPage;
        private IWebDriver _driver;
        private DBCleaner _tablesClear;
        private TasksStepDefinitions _stepsBySwagger;

        CreatingHomeworkByMethodologist()
        {
            _methodistHomeworkWindow = new MethodistHomeworkWindow();
            _driver = new ChromeDriver();
            _authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage(_driver);
            _homeworkMethodist = new HomeworkCreationMethodistPage(_driver);
            _tablesClear = new DBCleaner();
            _stepsBySwagger = new TasksStepDefinitions();
        }

        [When(@"Register users with roles")]
        public void WhenRegisterUsersWithRoles(Table table)
        {
            _tablesClear.ClearDB();
            _stepsBySwagger.GivenRegisterNewUsersWithRoles(table);
        }

        [When(@"Authorization user as methodist")]
        public void WhenAuthorizationUserAsMethodist(Table table)
        {
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
            Thread.Sleep(500);
            _homeworkMethodist.ChageRole(checkingModel.Role);
            Thread.Sleep(500);
        }      

        [When(@"Methodist click button add task")]
        public void WhenMethodistClickButtonAddTask()
        {
            _homeworkMethodist.ClickHomeworksButton();
            _homeworkMethodist.ClickCreateHomework();
            Thread.Sleep(1000);
        }

        [When(@"Methodist create draft Homework")]
        public void WhenMethodistCreateDraftHomework(Table table)
        {
            _homeworkMethodist.ClickChoiceGroupNumber();
            AddNewHomework createHomework = table.CreateInstance<AddNewHomework>();
            _homeworkMethodist.InputNameGroup(createHomework.Name);
            _homeworkMethodist.InputDescriptionHomework(createHomework.Description);
            _homeworkMethodist.InputLinkHomework(createHomework.Link);
            _homeworkMethodist.ClickButtonAttachLink();
        }

        [Then(@"Methodist click button save as draft")]
        public void ThenMethodistClickButtonSaveAsDraft()
        {
            _homeworkMethodist.ClickButtonSaveDraft();
        }

        [When(@"Methodist see all created homeworks")]
        public void WhenMethodistSeeAllCreatedHomeworks()
        {
            throw new PendingStepException();
            //TODO The methodologist does not see his drafts. emptiness(Task 2.3)
        }

        [When(@"Methodist click link edit")]
        public void WhenMethodistClickLinkEdit()
        {
            throw new PendingStepException();
        }

        [When(@"Methodist edits homework")]
        public void WhenMethodistEditsHomework()
        {
            throw new PendingStepException();
        }

        [Then(@"Methodist click button save draft")]
        public void ThenMethodistClickButtonSaveDraft()
        {
            throw new PendingStepException();
        }

        [Then(@"Teacher authorization")]
        public void ThenTeacherAuthorization()
        {
            throw new PendingStepException();
        }

        [Then(@"Teacher click button homework assignment")]
        public void ThenTeacherClickButtonHomeworkAssignment()
        {
            throw new PendingStepException();
        }

        [When(@"Teacher fill out a new assignment form")]
        public void WhenTeacherFillOutANewAssignmentForm()
        {
            throw new PendingStepException();
        }

        [When(@"Teacher click button publish")]
        public void WhenTeacherClickButtonPublish()
        {
            throw new PendingStepException();
        }

        [Then(@"Student should sees homework")]
        public void ThenStudentShouldSeesHomework()
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
