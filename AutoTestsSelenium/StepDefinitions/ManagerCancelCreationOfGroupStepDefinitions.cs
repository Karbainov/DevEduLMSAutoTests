using DevEduLMSAutoTests.API.Clients;
using DevEduLMSAutoTests.API.Support;
using DevEduLMSAutoTests.API.Support.Models.Request;
using DevEduLMSAutoTests.API.Support.Models.Response;

namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class ManagerCancelCreationOfGroupStepDefinitions
    {
        private IWebDriver _driver;
        private AuthenticationClient _authenticationClient;
        private ClearTables _clearDb;
        private List<RegisterResponse> _students;
        private List<RegisterResponse> _teachers;
        private RegisterResponse _tutor;
        private string _managerToken;

        private xPaths _xPaths;
        public ManagerCancelCreationOfGroupStepDefinitions()
        {
            _xPaths = new xPaths();
            _clearDb = new ClearTables();
            _authenticationClient = new AuthenticationClient();
            _students = new List<RegisterResponse>();
            _teachers = new List<RegisterResponse>();
            _tutor = new RegisterResponse();
        }

        [Given(@"Authorize as manager")]
        public void GivenAuthorizeAsManager(Table table)
        {
            SwaggerSignInRequest authManager = table.CreateInstance<SwaggerSignInRequest>();
            _managerToken = _authenticationClient.AuthorizeUser(authManager);
        }

        [Given(@"Registrate few students")]
        public void GivenRegistrateFewStudents(Table table)
        {
            List<RegisterRequest> usersRegistartion = table.CreateSet<RegisterRequest>().ToList();
            foreach (var user in usersRegistartion)
            {
                RegisterResponse student = _authenticationClient.RegisterUser(user);
                _students.Add(student);
            };
        }
        [Given(@"Registrate a teacher")]
        public void GivenRegistrateATeacher(Table table)
        {

        }
        [Given(@"Registrate a tutor")]
        public void GivenRegistrateATutor(Table table)
        {

        }

        [Given(@"Open a browser and open a page")]
        public void GivenOpenABrowserAndOpenAPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.LogIn);
        }

        [Given(@"Authorize as manager")]
        public void GivenAuthorizeAsManager(Table table)
        {
            AuthModel authModel = table.CreateInstance<AuthModel>();
            var emailBox = _driver.FindElement(_xPaths.EmailInput);
            emailBox.SendKeys(authModel.Email);
            var passwordBox = _driver.FindElement(_xPaths.PasswordInput);
            passwordBox.SendKeys(authModel.Password);
            var enterButton = _driver.FindElement(_xPaths.EnterButton);
            enterButton.Click();
        }

        [Given(@"Start create a group ""([^""]*)""")]
        public void GivenStartCreateAGroup(string name)
        {
            var createGroup = _driver.FindElement(_xPaths.CreateGroupAside);
            createGroup.Click();
            var groupName = _driver.FindElement(_xPaths.EnterGroupName);
            groupName.SendKeys(name);
            var chooseCourse = _driver.FindElement(_xPaths.ChooseCourse);
            chooseCourse.Click();
            var backendC = _driver.FindElement(_xPaths.BackendC);
            backendC.Click();



        }

        [When(@"Cancel creation")]
        public void WhenCancelCreation()
        {
            throw new PendingStepException();
        }

        [Then(@"Group do not create")]
        public void ThenGroupDoNotCreate()
        {
            throw new PendingStepException();
        }
    }
}
