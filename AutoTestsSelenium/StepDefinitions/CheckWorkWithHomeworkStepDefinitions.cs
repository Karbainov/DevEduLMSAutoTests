using TechTalk.SpecFlow;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class CheckWorkWithHomeworkStepDefinitions
    {
        private IWebDriver _driver;

        [When(@"Open DevEdu site ""([^""]*)""")]
        public void WhenOpenDevEduSite(string link)
        {
            _driver = SingleWebDriver.GetInstance();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
        }

        [When(@"Methodist authorization on the site")]
        public void WhenMethodistAuthorizationOntheSite(Table table)
        {
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
        }

        [When(@"Methodist click button homework")]
        public void WhenMethodistClickButtonHomework()
        {
            HomeworkCreationMethodistPage _homeworkMethodist;
            _homeworkMethodist = new HomeworkCreationMethodistPage();
            _homeworkMethodist.ClickHomeworksButton();
        }

        [When(@"Methodist click button add homework")]
        public void WhenMethodistClickButtonAddHomework()
        {
            HomeworksTeacherPage _homeworksTeacherPage;
            _homeworksTeacherPage = new HomeworksTeacherPage();
            _homeworksTeacherPage.ClickAddHomework();        
        }

        [When(@"Methodist create homework course name ""([^""]*)""")]
        public void WhenMethodistCreateHomeworkCourseName(string courseName, Table table)
        {
            HomeworkCreationMethodistPage _homeworkMethodist;
            _homeworkMethodist = new HomeworkCreationMethodistPage();
            AddNewHomework createHomework = table.CreateInstance<AddNewHomework>();
            _homeworkMethodist.ClickChoiceGroupNumber(courseName);
            _homeworkMethodist.InputNameGroup(createHomework.Name);
            _homeworkMethodist.InputDescriptionHomework(createHomework.Description);
            _homeworkMethodist.InputLinkHomework(createHomework.Link);
            _homeworkMethodist.ClickButtonAttachLink();
            _homeworkMethodist.ClickButtonSaveDraft();
            //TODO teacher does not see homework in saved assignments (Task 2.5)
        }  

        [Then(@"Teacher lays out the task ""([^""]*)"" created by the methodologist")]
        public void ThenTeacherLaysOutTheTaskCreatedByTheMethodologist(string nameHomework)
        {
            HomeworksDraftTeacherPage _homeworksDraftTeacherPage;
            _homeworksDraftTeacherPage = new HomeworksDraftTeacherPage();
            HomeworksTeacherPage _homeworksTeacherPage;
            _homeworksTeacherPage = new HomeworksTeacherPage();
            _homeworksTeacherPage.ClickHomeworksButton();
            _homeworksTeacherPage.ClickSavedHomeworkButton();
            _homeworksDraftTeacherPage.ClickEditHomeworkButton(nameHomework);
            //TODO �o task, emptiness (Task 2.5)
        }

        [When(@"Teacher create issuing homework course name ""([^""]*)""")]
        public void WhenTeacherCreateIssuingHomeworkCourseName(string groupName, Table table)
        {          
            HomeworkExtraditionTeacherPage _homeworkExtraditionTeacherPage;
            _homeworkExtraditionTeacherPage = new HomeworkExtraditionTeacherPage();
            AddNewHomework homework = table.CreateInstance<AddNewHomework>();
            _homeworkExtraditionTeacherPage.ClickRadioButtonGroupName(groupName);
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
            HomeworkExtraditionTeacherPage _homeworkExtraditionTeacherPage;
            _homeworkExtraditionTeacherPage = new HomeworkExtraditionTeacherPage();
            _homeworkExtraditionTeacherPage.ClickPublish();
            //TODO �o task, emptiness (Task 2.5)
        }

        [When(@"Teacher see all task")]
        public void WhenSeeAllTask()
        {
            HomeworksTeacherPage _homeworksTeacherPage;
            _homeworksTeacherPage = new HomeworksTeacherPage();
            _homeworksTeacherPage.ClickAddHomeworksButton();
            _homeworksTeacherPage.ClickExitButton();
            //TODO �o task, emptiness (Task 2.5)
        }

        [When(@"Student click button homework")]
        public void WhenStudentClickButtonHomework()
        {
            HomeworksTeacherPage _homeworksTeacherPage;
            _homeworksTeacherPage = new HomeworksTeacherPage();
            _homeworksTeacherPage.ClickHomeworksButton();
        }

        [When(@"Studen click button to the task")]
        public void WhenStudenClickButtonToTheTask()
        {
             HomeworksStudentPage _homeworksStudentPage;
            _homeworksStudentPage = new HomeworksStudentPage();
            _homeworksStudentPage.GoToTaskButton();
        }

        [When(@"Studen attaches a link ""([^""]*)"" to the completed task")]
        public void WhenStudenAttachesALinkToTheCompletedTask(string link)
        {
            HomeworksStudentPage _homeworksStudentPage;
            _homeworksStudentPage = new HomeworksStudentPage();
            _homeworksStudentPage.InputLinkAnswer(link);
            //TODO �o task, emptiness (Task 2.5)
        }      

        [When(@"Studen click airplane icon")]
        public void WhenStudenClickAirplaneIcon()
        {
            HomeworksTeacherPage _homeworksTeacherPage;
            _homeworksTeacherPage = new HomeworksTeacherPage();
            HomeworksStudentPage _homeworksStudentPage;
            _homeworksStudentPage = new HomeworksStudentPage();
            _homeworksStudentPage.SendAnswerButton();
            _homeworksTeacherPage.ClickExitButton();
            //TODO �o task, emptiness (Task 2.5)
        }

        [When(@"Teacher checks homework")]
        public void WhenTeacherChecksHomework()
        {
            HomeworksTeacherPage _homeworksTeacherPage;
            _homeworksTeacherPage = new HomeworksTeacherPage();
            _homeworksTeacherPage.ClickCheckHomeworksButton();
            //TODO �o task, emptiness (Task 2.5)
        }

        [When(@"Teacher returned homework")]
        public void WhenTeacherReturnedHomework()
        {
            throw new PendingStepException();
            //TODO Blank sheet task 2.5
        }

        [When(@"Student attached link ""([^""]*)"" of corrected homework")]
        public void WhenStudentAttachedLinkOfCorrectedHomework(string link)
        {
            HomeworksTeacherPage _homeworksTeacherPage;
            _homeworksTeacherPage = new HomeworksTeacherPage();
            HomeworksStudentPage _homeworksStudentPage;
            _homeworksStudentPage = new HomeworksStudentPage();
            _homeworksTeacherPage.ClickHomeworksButton();
            _homeworksStudentPage.GoToTaskButton();
            _homeworksStudentPage.InputLinkAnswer(link);
            _homeworksStudentPage.SendAnswerButton();
            _homeworksTeacherPage.ClickExitButton();
            //TODO �o task, emptiness (Task 2.5)
        }     

        [Then(@"Teacher accepted homework")]
        public void ThenTeacherAcceptedHomework()
        {
            HomeworksTeacherPage _homeworksTeacherPage;
            _homeworksTeacherPage = new HomeworksTeacherPage();
            _homeworksTeacherPage.ClickCheckHomeworksButton();
            //TODO do not continue step due to missing step:Teacher returned homework
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