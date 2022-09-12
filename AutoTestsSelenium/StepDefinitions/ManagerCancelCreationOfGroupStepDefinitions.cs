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
        private UsersClient _usersClient;
        private ClearTables _clearDb;
        private List<RegisterResponse> _students;
        private RegisterResponse _teacher;
        private RegisterResponse _tutor;
        private string _managerToken;

        private xPaths _xPaths;
        public ManagerCancelCreationOfGroupStepDefinitions()
        {
            _xPaths = new xPaths();
            _clearDb = new ClearTables();
            _authenticationClient = new AuthenticationClient();
            _usersClient = new UsersClient();
            _students = new List<RegisterResponse>();
            _teacher = new RegisterResponse();
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
            RegisterRequest teacherRegister = table.CreateInstance<RegisterRequest>();
            _teacher = _authenticationClient.RegisterUser(teacherRegister);
            _usersClient.AddNewRoleToUser(_teacher.Id, OptionsSwagger.RoleTeacher,_managerToken);
            _usersClient.DeleteUsersRole(_teacher.Id, OptionsSwagger.RoleStudent, _managerToken);
        }
        [Given(@"Registrate a tutor")]
        public void GivenRegistrateATutor(Table table)
        {
            RegisterRequest tutorRegister = table.CreateInstance<RegisterRequest>();
            _tutor = _authenticationClient.RegisterUser(tutorRegister);
            _usersClient.AddNewRoleToUser(_tutor.Id, OptionsSwagger.RoleTutor, _managerToken);
            _usersClient.DeleteUsersRole(_tutor.Id, OptionsSwagger.RoleStudent, _managerToken);
        }

        [Given(@"Open a browser and open a page")]
        public void GivenOpenABrowserAndOpenAPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.LogIn);
        }

        [Given(@"SignIn as manager")]
        public void GivenSignInAsManager(Table table)
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
