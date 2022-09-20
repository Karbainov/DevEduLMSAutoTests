namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class CreatingHomeworkByMethodologistDefinitions
    {
        private HomeworkCreationMethodistPage _homeworkMethodist;
        private AuthorizationUnauthorizedPage _authorizationUnauthorizedPage;
        private IWebDriver _driver;
        private DBCleaner _tablesClear;
        private TasksStepDefinitions _stepsBySwagger;
        private HomeworksTeacherPage _homeworksTeacherPage;
        private HomeworkExtraditionTeacherPage _homeworkExtraditionTeacherPage;

        CreatingHomeworkByMethodologistDefinitions()
        {
            _driver = SingleWebDriver.GetInstance();
            _authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage(_driver);
            _homeworkMethodist = new HomeworkCreationMethodistPage(_driver);
            _tablesClear = new DBCleaner();
            _stepsBySwagger = new TasksStepDefinitions();
            _homeworkExtraditionTeacherPage = new HomeworkExtraditionTeacherPage(_driver);
            _homeworksTeacherPage = new HomeworksTeacherPage(_driver);
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
        }      

        [When(@"Methodist click button add task")]
        public void WhenMethodistClickButtonAddTask()
        {
            _homeworkMethodist.ClickHomeworksButton();
            _homeworksTeacherPage.ClickAddHomework();
        }

        [When(@"Methodist create draft Homework")]
        public void WhenMethodistCreateDraftHomework(Table table)
        {
            AddNewHomework createHomework = table.CreateInstance<AddNewHomework>();
            _homeworkMethodist.ClickChoiceGroupNumber(createHomework.CourseName);
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
            //TODO (Task 2.3)
        }

        [When(@"Methodist edits homework")]
        public void WhenMethodistEditsHomework()
        {
            throw new PendingStepException();
            //TODO (Task 2.3)
        }

        [Then(@"Methodist click button save draft")]
        public void ThenMethodistClickButtonSaveDraft()
        {
            throw new PendingStepException();
            //TODO(Task 2.3)
        }

        [Then(@"Teacher authorization")]
        public void ThenTeacherAuthorization(Table table)
        {
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
        }

        [Then(@"Teacher click button homework assignment")]
        public void ThenTeacherClickButtonHomeworkAssignment()
        {
            _homeworkMethodist.ClickHomeworksButton();
            _homeworkMethodist.ClickAddHomeworksButton();
        }

        [When(@"Teacher fill out a new assignment form")]
        public void WhenTeacherFillOutANewAssignmentForm(Table table)
        {
            AddNewHomework homework = table.CreateInstance<AddNewHomework>();
            _homeworkExtraditionTeacherPage.GetNumberGroup(homework.CourseName);
            _homeworkExtraditionTeacherPage.InputStarDate(homework.StartDate);
            _homeworkExtraditionTeacherPage.InputEndDate(homework.EndDate);
            _homeworkExtraditionTeacherPage.InputNameHomework(homework.Name);
            _homeworkExtraditionTeacherPage.InputDescriptionHomework(homework.Description);
            _homeworkExtraditionTeacherPage.InputUsefulLinks(homework.Link);
            _homeworkExtraditionTeacherPage.ClickAddLink();
            //TODO No choice of job number. combobox not implemented (Task 2.3)
        }

        [When(@"Teacher click button publish")]
        public void WhenTeacherClickButtonPublish()
        {
            _homeworkExtraditionTeacherPage.ClickPublish();
        }

        [Then(@"Student should sees homework")]
        public void ThenStudentShouldSeesHomework(Table table)
        {
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
            _homeworkExtraditionTeacherPage.ClickHomeworksButton();
            //TODO Homework does not appear. emptiness (Tasl 2.3)
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
