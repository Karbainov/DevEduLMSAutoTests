using OpenQA.Selenium.Chrome;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class SpecialTwoPointFiveStepDefinitions
    {
        private IWebDriver _driver;

        [Given(@"Open DevEdu web page")]
        public void GivenOpenDevEduWebPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl($"https://piter-education.ru:7074/login");
        }

        [When(@"authorization user as methodist")]
        public void WhenAuthorizationUserAsMethodist()
        {
            
        }

        [When(@"methodist click botton to come in")]
        public void WhenMethodistClickBottonToComeIn()
        {
            throw new PendingStepException();
        }

        [When(@"methodist click button add task")]
        public void WhenMethodistClickButtonAddTask()
        {
            throw new PendingStepException();
        }

        [When(@"methodist create draft Homework")]
        public void WhenMethodistCreateDraftHomework()
        {
            throw new PendingStepException();
        }

        [When(@"methodist click button save as draft")]
        public void WhenMethodistClickButtonSaveAsDraft()
        {
            throw new PendingStepException();
        }

        [When(@"methodist see all created homeworks")]
        public void WhenMethodistSeeAllCreatedHomeworks()
        {
            throw new PendingStepException();
        }

        [When(@"methodist click link edit")]
        public void WhenMethodistClickLinkEdit()
        {
            throw new PendingStepException();
        }

        [When(@"methodist edits homework")]
        public void WhenMethodistEditsHomework()
        {
            throw new PendingStepException();
        }

        [When(@"Authorization in as a teacher")]
        public void WhenAuthorizationInAsATeacher()
        {
            throw new PendingStepException();
        }

        [When(@"teacher click buttom homework assignment")]
        public void WhenTeacherClickButtomHomeworkAssignment()
        {
            throw new PendingStepException();
        }

        [When(@"teacher fill out a new assignment form")]
        public void WhenTeacherFillOutANewAssignmentForm()
        {
            throw new PendingStepException();
        }

        [When(@"teacher click button publish")]
        public void WhenTeacherClickButtonPublish()
        {
            throw new PendingStepException();
        }

        [Then(@"student should sees homework")]
        public void ThenStudentShouldSeesHomework()
        {
            throw new PendingStepException();
        }
    }
}
