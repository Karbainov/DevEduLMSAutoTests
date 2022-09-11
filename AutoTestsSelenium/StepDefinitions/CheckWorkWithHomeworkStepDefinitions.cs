using AutoTestsSelenium.Support.FindElements;
using AutoTestsSelenium.Support.Models.SupportModels;
using DevEduLMSAutoTests.API.StepDefinitions;
using DevEduLMSAutoTests.API.Support;
using DevEduLMSAutoTests.API.Support.Models.Request;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class CheckWorkWithHomeworkStepDefinitions
    {
        private TasksStepDefinitions _stepsBySwagger;
        private List<SingInRequest> _studensSignIn;
        private SingInRequest _teacherSingIn;
        private SingInRequest _methodist;
        private IWebDriver _driver;
        private SingInWindow _singInWindow;
        private NavigatePanelElements _navigateButtons;
        private string _groupName;
        private TeachersHomeworkWindow _teacersHomeworkWindowElements;
        private StudentsHomeworkWindow _studentsHomeworkWindowElements;
        private ClearTables clearDB;
        private List<StudentsHomeworkResults> _studentsResults;
        private HomeworkResultsElements _homeworkResultsElements;
        GeneralProgressWindow _generalProgressElements;

        public CheckWorkWithHomeworkStepDefinitions()
        {
            _stepsBySwagger = new TasksStepDefinitions();
            _studensSignIn = new List<SingInRequest>();
            _driver = new ChromeDriver();
            _singInWindow = new SingInWindow();
            _navigateButtons = new NavigatePanelElements();
            _teacersHomeworkWindowElements = new TeachersHomeworkWindow();
            _studentsHomeworkWindowElements = new StudentsHomeworkWindow();
            clearDB = new ClearTables();
            _studentsResults = new List<StudentsHomeworkResults>();
            _homeworkResultsElements = new HomeworkResultsElements();
            _generalProgressElements = new GeneralProgressWindow();
        }

        [When(@"register users with and assigned roles")]
        public void WhenRegisterUsersWithAndAssignedRoles(Table table)
        {
            clearDB.ClearDB();
            _stepsBySwagger.GivenRegisterNewUsersWithRoles(table);
            List<RegistationModelWithRole> users = table.CreateSet<RegistationModelWithRole>().ToList();
            foreach (var user in users)
            {
                if (user.Role == "Student")
                {
                    _studensSignIn.Add(new SingInRequest() { Email = user.Email, Password = user.Password });
                }
                else if (user.Role == "Teacher")
                {
                    _teacherSingIn = new SingInRequest() { Email = user.Email, Password = user.Password };
                }
                else 
                {
                    _methodist = new SingInRequest() { Email = user.Email, Password = user.Password };
                }
            }
        }

        [When(@"authorization user as manager")]
        public void WhenAuthorizationUserAsManager(Table table)
        {
            SingInRequest singInRequest = table.CreateInstance<SingInRequest>();
            var emailBox = _driver.FindElement(_singInWindow.XPathEmailBox);
            emailBox.SendKeys(singInRequest.Email);
            var passBox = _driver.FindElement(_singInWindow.XPathPasswordBox);
            passBox.Clear();
            passBox.SendKeys(singInRequest.Password);
        }

        [When(@"manager create new groups")]
        public void WhenManagerCreateNewGroups(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"manager add studant in new group")]
        public void WhenManagerAddStudantInNewGroup()
        {
            throw new PendingStepException();
        }

        [When(@"manager add teacher in new group")]
        public void WhenManagerAddTeacherInNewGroup()
        {
            throw new PendingStepException();
        }

        [Then(@"manager click button exit")]
        public void ThenManagerClickButtonExit()
        {
            throw new PendingStepException();
        }

        [Then(@"authorization user as methodist")]
        public void ThenAuthorizationUserAsMethodist(Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"methodist click button homework")]
        public void ThenMethodistClickButtonHomework()
        {
            throw new PendingStepException();
        }

        [When(@"methodist create homework")]
        public void WhenMethodistCreateHomework(Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"methodist see all created homeworks")]
        public void ThenMethodistSeeAllCreatedHomeworks()
        {
            throw new PendingStepException();
        }

        [Then(@"methoist click button exit")]
        public void ThenMethoistClickButtonExit()
        {
            throw new PendingStepException();
        }

        [Then(@"authorization user as teacher")]
        public void ThenAuthorizationUserAsTeacher(Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"teacher click button issuing homework")]
        public void ThenTeacherClickButtonIssuingHomework()
        {
            throw new PendingStepException();
        }

        [When(@"teacher create issuing homework")]
        public void WhenTeacherCreateIssuingHomework()
        {
            throw new PendingStepException();
        }

        [Then(@"teacher click button publish")]
        public void ThenTeacherClickButtonPublish()
        {
            throw new PendingStepException();
        }

        [When(@"see all task")]
        public void WhenSeeAllTask()
        {
            throw new PendingStepException();
        }

        [When(@"teacher click button exit")]
        public void WhenTeacherClickButtonExit()
        {
            throw new PendingStepException();
        }

        [When(@"student authorization")]
        public void WhenStudentAuthorization(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"student click button homework")]
        public void WhenStudentClickButtonHomework()
        {
            throw new PendingStepException();
        }

        [When(@"studen click button to the task")]
        public void WhenStudenClickButtonToTheTask()
        {
            throw new PendingStepException();
        }

        [When(@"studen attaches a link to the completed task")]
        public void WhenStudenAttachesALinkToTheCompletedTask(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"studen click airplane icon")]
        public void WhenStudenClickAirplaneIcon()
        {
            throw new PendingStepException();
        }

        [When(@"studen click button exit")]
        public void WhenStudenClickButtonExit()
        {
            throw new PendingStepException();
        }

        [When(@"authorization user as teacher")]
        public void WhenAuthorizationUserAsTeacher(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"teacher click botton to come in")]
        public void WhenTeacherClickBottonToComeIn()
        {
            throw new PendingStepException();
        }

        [When(@"teacher click button checking assignments")]
        public void WhenTeacherClickButtonCheckingAssignments()
        {
            throw new PendingStepException();
        }
    }
}
