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


        public StatisticsStepDefinitions()
        {
            _stepsBySwagger = new TasksStepDefinitions();
            _studensSignIn = new List<SingInRequest>();
            _driver = new ChromeDriver();
            _singInElements = new SingInWindow();
            _navigateButtons = new NavigatePanelElements();
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
            _stepsBySwagger.GivenManagerCreateNewGroup(table);
        }

        [Given(@"manager add users to group")]
        public void GivenManagerAddUsersToGroup()
        {
            _stepsBySwagger.GivenManagerAddUsersToGroup();
        }

        [When(@"teacher create new homework")]
        public void WhenTeacherCreateNewHomework()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
            _driver.FindElement(_singInElements.XPathEmailBox).SendKeys(_teacherSingIn.Email);
            _driver.FindElement(_singInElements.XPathPasswordBox).SendKeys(_teacherSingIn.Password);
            _driver.FindElement(_singInElements.XPathSingInButton).Click();
            Thread.Sleep(1500);
            _driver.FindElement(_navigateButtons.XPathNewHomeworkButton).Click();
        }

        [When(@"students did their homework")]
        public void WhenStudentsDidTheirHomework()
        {
            throw new PendingStepException();
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
