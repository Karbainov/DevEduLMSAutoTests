namespace AutoTestsSelenium.StepDefinitions
{

    [Binding] 
    public class CreatingHomeworkByMethodologistDefinitions
    {
        private IWebDriver _driver;

        [Given(@"Authorization user as methodist")]
        public void GivenAuthorizationUserAsMethodist(Table table)
        {
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
        }

        [Given(@"Open DevEdu site")]
        public void WhenOpenDevEduWebSite()
        {
            _driver = SingleWebDriver.GetInstance();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
        }

        [Given(@"Methodist click button add task")]
        public void GivenMethodistClickButtonAddTask()
        {
             HomeworkCreationMethodistPage _homeworkMethodist;
             HomeworksTeacherPage _homeworksTeacherPage;
            _homeworkMethodist = new HomeworkCreationMethodistPage();
            _homeworkMethodist.ClickHomeworksButton();
            _homeworksTeacherPage = new HomeworksTeacherPage();
            _homeworksTeacherPage.ClickAddHomework();
        }

        [When(@"Methodist create draft Homework course name ""([^""]*)""")]
        public void WhenMethodistCreateDraftHomeworkCourseName(string courseName, Table table)
        {
            AddNewHomework createHomework = table.CreateInstance<AddNewHomework>();
             HomeworkCreationMethodistPage _homeworkMethodist;
            _homeworkMethodist = new HomeworkCreationMethodistPage();
            _homeworkMethodist.ClickChoiceGroupNumber(courseName);
            _homeworkMethodist.InputNameGroup(createHomework.Name);
            _homeworkMethodist.InputDescriptionHomework(createHomework.Description);
            _homeworkMethodist.InputLinkHomework(createHomework.Link);
            _homeworkMethodist.ClickButtonAttachLink();         
        }

        [Then(@"Methodist click button save as draft")]
        public void ThenMethodistClickButtonSaveAsDraft()
        {
            HomeworkCreationMethodistPage _homeworkMethodist;
            _homeworkMethodist = new HomeworkCreationMethodistPage();
            _homeworkMethodist.ClickButtonSaveDraft();
        }

        [When(@"Methodist see all created homeworks")]
        public void WhenMethodistSeeAllCreatedHomeworks()
        {
            HomeworkCreationMethodistPage _homeworkMethodist;
            _homeworkMethodist = new HomeworkCreationMethodistPage();
            _homeworkMethodist.ClickHomeworksButton();
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
            _homeworkMethodist = new HomeworkCreationMethodistPage();
            _homeworkMethodist.ClickHomeworksButton();
            _homeworkMethodist.ClickAddHomeworksButton();
        }

        [When(@"Teacher fill out a new assignment form course name ""([^""]*)""")]
        public void WhenTeacherFillOutANewAssignmentFormCourseName(string courseName, Table table)
        {
            HomeworkExtraditionTeacherPage _homeworkExtraditionTeacherPage;
            _homeworkExtraditionTeacherPage = new HomeworkExtraditionTeacherPage();
            AddNewHomework homework = table.CreateInstance<AddNewHomework>();
            _homeworkExtraditionTeacherPage.GetNumberGroup(courseName);
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
            _homeworkExtraditionTeacherPage = new HomeworkExtraditionTeacherPage();
            _homeworkExtraditionTeacherPage.ClickPublish();
        }

        [Then(@"Student should sees homework")]
        public void ThenStudentShouldSeesHomework(Table table)
        {
            HomeworkExtraditionTeacherPage _homeworkExtraditionTeacherPage;
            _homeworkExtraditionTeacherPage = new HomeworkExtraditionTeacherPage();
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
            _homeworkExtraditionTeacherPage.ClickHomeworksButton();
            //TODO Homework does not appear. emptiness (Tasl 2.3)
        }

        private void AuthorizeUser(SwaggerSignInRequest user)
        {
            _driver.Manage().Window.Maximize();
            AuthorizationUnauthorizedPage _authorizationUnauthorizedPage;
            _authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage();
            _authorizationUnauthorizedPage.OpenThisPage();
            _authorizationUnauthorizedPage.EnterEmail(user.Email);
            _authorizationUnauthorizedPage.EnterPassword(user.Password);
            _authorizationUnauthorizedPage.ClickEnterButton();
        }
    }
}
