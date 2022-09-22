namespace AutoTestsSelenium.StepDefinitions
{
    [Binding] 
    public class CreatingHomeworkByMethodologistDefinitions
    {
        private IWebDriver _driver;

        [When(@"Register users with roles")]
        public void WhenRegisterUsersWithRoles(Table table)
        {              
           TasksStepDefinitions _stepsBySwagger;
           _driver = SingleWebDriver.GetInstance();
           _stepsBySwagger = new TasksStepDefinitions();
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
             HomeworkCreationMethodistPage _homeworkMethodist;
             HomeworksTeacherPage _homeworksTeacherPage;
            _homeworkMethodist = new HomeworkCreationMethodistPage(_driver);
            _homeworkMethodist.ClickHomeworksButton();
            _homeworksTeacherPage = new HomeworksTeacherPage(_driver);
            _homeworksTeacherPage.ClickAddHomework();
        }

        [When(@"Methodist create draft Homework")]
        public void WhenMethodistCreateDraftHomework(Table table)
        {
            AddNewHomework createHomework = table.CreateInstance<AddNewHomework>();
             HomeworkCreationMethodistPage _homeworkMethodist;
            _homeworkMethodist = new HomeworkCreationMethodistPage(_driver);
            _homeworkMethodist.ClickChoiceGroupNumber(createHomework.CourseName);
            _homeworkMethodist.InputNameGroup(createHomework.Name);
            _homeworkMethodist.InputDescriptionHomework(createHomework.Description);
            _homeworkMethodist.InputLinkHomework(createHomework.Link);
            _homeworkMethodist.ClickButtonAttachLink();
        }

        [Then(@"Methodist click button save as draft")]
        public void ThenMethodistClickButtonSaveAsDraft()
        {
            HomeworkCreationMethodistPage _homeworkMethodist;
            _homeworkMethodist = new HomeworkCreationMethodistPage(_driver);
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
            HomeworkCreationMethodistPage _homeworkMethodist;
            _homeworkMethodist = new HomeworkCreationMethodistPage(_driver);
            _homeworkMethodist.ClickHomeworksButton();
            _homeworkMethodist.ClickAddHomeworksButton();
        }

        [When(@"Teacher fill out a new assignment form")]
        public void WhenTeacherFillOutANewAssignmentForm(Table table)
        {
            HomeworkExtraditionTeacherPage _homeworkExtraditionTeacherPage;
            _homeworkExtraditionTeacherPage = new HomeworkExtraditionTeacherPage(_driver);
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
            HomeworkExtraditionTeacherPage _homeworkExtraditionTeacherPage;
            _homeworkExtraditionTeacherPage = new HomeworkExtraditionTeacherPage(_driver);
            _homeworkExtraditionTeacherPage.ClickPublish();
        }

        [Then(@"Student should sees homework")]
        public void ThenStudentShouldSeesHomework(Table table)
        {
            HomeworkExtraditionTeacherPage _homeworkExtraditionTeacherPage;
            _homeworkExtraditionTeacherPage = new HomeworkExtraditionTeacherPage(_driver);
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
            _homeworkExtraditionTeacherPage.ClickHomeworksButton();
            //TODO Homework does not appear. emptiness (Tasl 2.3)
        }

        private void AuthorizeUser(SwaggerSignInRequest user)
        {
            _driver.Manage().Window.Maximize();
            AuthorizationUnauthorizedPage _authorizationUnauthorizedPage;
            _authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage(_driver);
            _authorizationUnauthorizedPage.OpenThisPage();
            _authorizationUnauthorizedPage.EnterEmail(user.Email);
            _authorizationUnauthorizedPage.EnterPassword(user.Password);
            _authorizationUnauthorizedPage.ClickEnterButton();
        }
    }
}
