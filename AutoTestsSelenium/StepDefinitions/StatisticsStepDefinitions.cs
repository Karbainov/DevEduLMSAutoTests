using DevEduLMSAutoTests.API.StepDefinitions;
using DevEduLMSAutoTests.API.Support.Models.Request;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class StatisticsStepDefinitions
    {
        private TasksStepDefinitions _stepsBySwagger;
        private List<SingInRequest> _studensSignIn;
        private SingInRequest _teacherSingIn;
        private IWebDriver _driver;
        private SingInWindow _singInElements;
        private NavigatePanelElements _navigateButtons;
        private string _groupName;
        private TeachersHomeworkWindow _teacersHomeworkWindowElements;
        private StudentsHomeworkWindow _studentsHomeworkWindowElements;


        public StatisticsStepDefinitions()
        {
            _stepsBySwagger = new TasksStepDefinitions();
            _studensSignIn = new List<SingInRequest>();
            _driver = new ChromeDriver();
            _singInElements = new SingInWindow();
            _navigateButtons = new NavigatePanelElements();
            _teacersHomeworkWindowElements = new TeachersHomeworkWindow();
        }

        [Given(@"register new users with roles")]
        public void GivenRegisterNewUsersWithRoles(Table table)
        {
            _stepsBySwagger.GivenRegisterNewUsersWithRoles(table);
            List<RegistationModelWithRole> users = table.CreateSet<RegistationModelWithRole>().ToList();
            foreach(var user in users)
            {
                if(user.Role == "Student")
                {
                    _studensSignIn.Add(new SingInRequest() { Email=user.Email, Password = user.Password });
                }
                else if(user.Role == "teacher")
                {
                    _teacherSingIn = new SingInRequest() {Email=user.Email, Password=user.Password };
                }
            }
        }

        [Given(@"manager create new group")]
        public void GivenManagerCreateNewGroup(Table table)
        {
            _groupName = _stepsBySwagger.GivenManagerCreateNewGroup(table);
            _teacersHomeworkWindowElements._groupName = _groupName;
        }

        [Given(@"manager add users to group")]
        public void GivenManagerAddUsersToGroup()
        {
            _stepsBySwagger.GivenManagerAddUsersToGroup();
        }

        [When(@"teacher create new homework")]
        public void WhenTeacherCreateNewHomework(Table table)
        {
            AddNewHomework homework = table.CreateInstance<AddNewHomework>();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
            _driver.FindElement(_singInElements.XPathEmailBox).SendKeys(_teacherSingIn.Email);
            _driver.FindElement(_singInElements.XPathPasswordBox).SendKeys(_teacherSingIn.Password);
            _driver.FindElement(_singInElements.XPathSingInButton).Click();
            Thread.Sleep(1500);
            _driver.FindElement(_navigateButtons.XPathNewHomeworkButton).Click();
            _driver.FindElement(_teacersHomeworkWindowElements.XPathGroupRB).Click();
            _driver.FindElement(_teacersHomeworkWindowElements.XPathStartDateTextBox).Clear();
            _driver.FindElement(_teacersHomeworkWindowElements.XPathStartDateTextBox).SendKeys(homework.StartDate);
            _driver.FindElement(_teacersHomeworkWindowElements.XPathEndDateTextBox).Clear();
            _driver.FindElement(_teacersHomeworkWindowElements.XPathEndDateTextBox).SendKeys(homework.EndDate);
            _driver.FindElement(_teacersHomeworkWindowElements.XPathNameTB).SendKeys(homework.Name);
            _driver.FindElement(_teacersHomeworkWindowElements.XPathDescriptionTB).SendKeys(homework.Description);
            _driver.FindElement(_teacersHomeworkWindowElements.XPathLinkTB).SendKeys(homework.Link);
            _driver.FindElement(_teacersHomeworkWindowElements.XPathAddLinkButton).Click();
            _driver.FindElement(_teacersHomeworkWindowElements.XPathPublishButton).Click();
            _driver.FindElement(_navigateButtons.XPathExitButton).Click();
            Thread.Sleep(1500);
        }

        [When(@"students did their homework")]
        public void WhenStudentsDidTheirHomework()
        {
            foreach(var student in _studensSignIn)
            {
                _driver.FindElement(_singInElements.XPathEmailBox).SendKeys(student.Email);
                _driver.FindElement(_singInElements.XPathPasswordBox).SendKeys(student.Password);
                _driver.FindElement(_singInElements.XPathSingInButton).Click();
                Thread.Sleep(1500);
                _driver.FindElement(_navigateButtons.XPathHomeworksButton).Click();
                _driver.FindElement(_studentsHomeworkWindowElements.XPathGoToTaskButton).Click();
                Thread.Sleep(1000);
                _driver.FindElement(_studentsHomeworkWindowElements.XPathLinkToAnswerTB).
                    SendKeys($"https://github.com");
                _driver.FindElement(_studentsHomeworkWindowElements.XPathSendAnswerButton).Click();
                _driver.FindElement(_navigateButtons.XPathExitButton).Click();
            }
        }

        [When(@"teacher accept or decline them")]
        public void WhenTeacherAcceptOrDeclineThem()
        {
            throw new PendingStepException();
        }

        [Then(@"methodist should see statistics of students results")]
        public void ThenMethodistShouldSeeStatisticsOfStudentsResults()
        {
            throw new PendingStepException();
        }
    }
}
