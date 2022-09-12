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
        private SingInWindow _singInWindow;
        private GroupsWindow _groupsWindow;
        private NavigatePanelElements _navigatePanelElements;
        private CreateGroupWindow _createGroupWindow;
        private ClearTables _clearDb;
        private RegisterResponse _teacher;
        private RegisterResponse _tutor;
        private string _managerToken;
        private string _groupName;
        private List<string> _groups;
        public ManagerCancelCreationOfGroupStepDefinitions()
        {
            _clearDb = new ClearTables();
            _authenticationClient = new AuthenticationClient();
            _usersClient = new UsersClient();
            _singInWindow = new SingInWindow();
            _groupsWindow = new GroupsWindow();
            _createGroupWindow = new CreateGroupWindow();
            _navigatePanelElements = new NavigatePanelElements();
            _teacher = new RegisterResponse();
            _tutor = new RegisterResponse();
            _groups = new List<string>();
        }

        [Given(@"Authorize as manager")]
        public void GivenAuthorizeAsManager(Table table)
        {
            _clearDb.ClearDB();
            SwaggerSignInRequest authManager = table.CreateInstance<SwaggerSignInRequest>();
            _managerToken = _authenticationClient.AuthorizeUser(authManager);
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
            var emailBox = _driver.FindElement(_singInWindow.XPathEmailBox);
            emailBox.SendKeys(authModel.Email);
            var passwordBox = _driver.FindElement(_singInWindow.XPathPasswordBox);
            passwordBox.Clear();
            passwordBox.SendKeys(authModel.Password);
            var enterButton = _driver.FindElement(_singInWindow.XPathSingInButton);
            enterButton.Click();
        }

        [Given(@"Start create a group ""([^""]*)""")]
        public void GivenStartCreateAGroup(string name)
        {
            Thread.Sleep(1500);
            var createGroup = _driver.FindElement(_navigatePanelElements.XPathCreateGroupButton);
            createGroup.Click();
            var groupName = _driver.FindElement(_createGroupWindow.XPathNameGroupBox);
            groupName.SendKeys(name);
            _groupName = name;
            var chooseCourse = _driver.FindElement(_createGroupWindow.XPathCoursesComboBox);
            chooseCourse.Click();
            Thread.Sleep(1500);
            var qa = _driver.FindElement(CreateGroupWindow.XPathCourseButton(Options.CourseQAAutomationId));
            qa.Click();
            chooseCourse.Click();
            var chooseTeacher = _driver.FindElement(CreateGroupWindow.XPathTeacherCheckBox(_teacher.FirstName));
            chooseTeacher.Click();
            var chooseTutor = _driver.FindElement(CreateGroupWindow.XPathTutorCheckBox(_tutor.FirstName));
            chooseTutor.Click();
        }

        [When(@"Cancel creation")]
        public void WhenCancelCreation()
        {
            var cancelButton = _driver.FindElement(_createGroupWindow.XPathCancelCreateGroupButton);
            cancelButton.Click();
        }

        [Then(@"Group do not create")]
        public void ThenGroupDoNotCreate()
        {
            var actualGroups = _driver.FindElements(_groupsWindow.XPathAllGroupsName);
            foreach (var group in actualGroups)
            {
                _groups.Add(group.Text);
            }
            var groupsButton = _driver.FindElement(_navigatePanelElements.XPathGroupsButton);
            groupsButton.Click();
            Assert.DoesNotContain(_groupName, _groups);
            _driver.Close();
            _clearDb.ClearDB();
        }
    }
}
