using AutoTestsSelenium.PageObjects;
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

        [When(@"Methodist click button homework")]
        public void WhenMethodistClickButtonHomework()
        {
            HomeworkCreationMethodistPage homeworkMethodist;
            homeworkMethodist = new HomeworkCreationMethodistPage();
            homeworkMethodist.ClickHomeworksButton();
        }

        [When(@"Methodist click button add homework")]
        public void WhenMethodistClickButtonAddHomework()
        {
            HomeworksMethodistPage homeworksMethodistPage;
            homeworksMethodistPage = new HomeworksMethodistPage();
            homeworksMethodistPage.ClickAddHomework();        
        }

        [When(@"Methodist create homework course name ""([^""]*)""")]
        public void WhenMethodistCreateHomeworkCourseName(string courseName, Table table)
        {
            HomeworkCreationMethodistPage homeworkMethodist;
            homeworkMethodist = new HomeworkCreationMethodistPage();
            AddNewHomework createHomework = table.CreateInstance<AddNewHomework>();
            homeworkMethodist.ClickChoiceGroupNumber(courseName);
            homeworkMethodist.InputNameGroup(createHomework.Name);
            homeworkMethodist.InputDescriptionHomework(createHomework.Description);
            homeworkMethodist.InputLinkHomework(createHomework.Link);
            homeworkMethodist.ClickButtonAttachLink();
            homeworkMethodist.ClickButtonSaveDraft();
            //TODO saved as draft HW are not saved. Emptiness (Task 2.5)
        }

        [When(@"Teacher lays out the task ""([^""]*)"" created by the methodologist")]
        public void WhenTeacherLaysOutTheTaskCreatedByTheMethodologist(string nameHomework)
        {
            HomeworksDraftTeacherPage homeworksDraftTeacherPage;
            homeworksDraftTeacherPage = new HomeworksDraftTeacherPage();
            homeworksDraftTeacherPage.GetNameHomework(nameHomework);
            HomeworksTeacherPage homeworksTeacherPage;
            homeworksTeacherPage = new HomeworksTeacherPage();
            homeworksTeacherPage.ClickHomeworksButton();
            homeworksTeacherPage.ClickSavedHomeworkButton();
            //TODO saved as draft HW are not saved. Emptiness (Task 2.5)
        }

        [When(@"Teacher create issuing homework course name ""([^""]*)""")]
        public void WhenTeacherCreateIssuingHomeworkCourseName(string groupName, Table table)
        {          
            HomeworkExtraditionTeacherPage homeworkExtraditionTeacherPage;
            homeworkExtraditionTeacherPage = new HomeworkExtraditionTeacherPage();
            AddNewHomework homework = table.CreateInstance<AddNewHomework>();
            homeworkExtraditionTeacherPage.ClickRadioButtonGroupName(groupName);
            homeworkExtraditionTeacherPage.InputStarDate(homework.StartDate);
            homeworkExtraditionTeacherPage.InputEndDate(homework.EndDate);
            homeworkExtraditionTeacherPage.InputNameHomework(homework.Name);
            homeworkExtraditionTeacherPage.InputDescriptionHomework(homework.Description);
            homeworkExtraditionTeacherPage.InputUsefulLinks(homework.Link);
            homeworkExtraditionTeacherPage.ClickAddLink();
            //TODO saved as draft HW are not saved. Emptiness (Task 2.5)
        }

        [Then(@"Teacher click button publish")]
        public void ThenTeacherClickButtonPublish()
        {
            HomeworkExtraditionTeacherPage homeworkExtraditionTeacherPage;
            homeworkExtraditionTeacherPage = new HomeworkExtraditionTeacherPage();
            homeworkExtraditionTeacherPage.ClickPublish();
            //TODO saved as draft HW are not saved. Emptiness (Task 2.5)
        }

        [When(@"Teacher see all task")]
        public void WhenSeeAllTask()
        {
            HomeworksTeacherPage homeworksTeacherPage;
            homeworksTeacherPage = new HomeworksTeacherPage();
            homeworksTeacherPage.ClickAddHomeworksButton();
            homeworksTeacherPage.ClickExitButton();
            //TODO saved as draft HW are not saved. Emptiness (Task 2.5)
        }

        [When(@"Student click button homework")]
        public void WhenStudentClickButtonHomework()
        {
            HomeworksStudentPage homeworksStudentPage;
            homeworksStudentPage = new HomeworksStudentPage();
            homeworksStudentPage.ClickHomeworksButton();
        }

        [When(@"Studen click button to the task")]
        public void WhenStudenClickButtonToTheTask()
        {
             HomeworksStudentPage homeworksStudentPage;
            homeworksStudentPage = new HomeworksStudentPage();
            homeworksStudentPage.GoToTaskButton();
        }

        [When(@"Studen attaches a link ""([^""]*)"" to the completed task")]
        public void WhenStudenAttachesALinkToTheCompletedTask(string link)
        {
            HomeworksStudentPage homeworksStudentPage;
            homeworksStudentPage = new HomeworksStudentPage();
            homeworksStudentPage.InputLinkAnswer(link);
            //TODO saved as draft HW are not saved. Emptiness (Task 2.5)
        }

        [When(@"Studen click airplane icon")]
        public void WhenStudenClickAirplaneIcon()
        {
            HomeworksStudentPage homeworksStudentPage;
            homeworksStudentPage = new HomeworksStudentPage();
            homeworksStudentPage.SendAnswerButton();          
        }

        [When(@"Teacher checks homework")]
        public void WhenTeacherChecksHomework()
        {
            HomeworksTeacherPage homeworksTeacherPage;
            homeworksTeacherPage = new HomeworksTeacherPage();
            homeworksTeacherPage.ClickCheckHomeworksButton();
            //TODO homework is not reviewed.Emptiness (Task 2.5)
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
            HomeworksStudentPage homeworksStudentPage;
            homeworksStudentPage = new HomeworksStudentPage();
            homeworksStudentPage.ClickHomeworksButton();
            homeworksStudentPage.GoToTaskButton();
            homeworksStudentPage.InputLinkAnswer(link);
            homeworksStudentPage.SendAnswerButton();
            //TODO �o task, emptiness (Task 2.5)
        }     

        [Then(@"Teacher accepted homework")]
        public void ThenTeacherAcceptedHomework()
        {
            HomeworksTeacherPage homeworksTeacherPage;
            homeworksTeacherPage = new HomeworksTeacherPage();
            homeworksTeacherPage.ClickCheckHomeworksButton();
            //TODO do not continue step due to missing step:Teacher returned homework
        }
    }
}