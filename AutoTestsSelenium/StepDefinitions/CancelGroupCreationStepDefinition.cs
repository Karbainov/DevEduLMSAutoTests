namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class CancelGroupCreationStepDefinition
    {
        private IWebDriver _driver;
        private GroupsAPIStepDefinitions _swaggerGroupSteps;
        private AuthorizationUnauthorizedPage _authorizationUnauthorizedPage;
        private CreateGroupManagerAuthorizaedPage _createGroupManagerAuthorizaedPage;
        private GroupsManagerAuthorizedPage _groupsManagerAuthorizedPage;
        private ClearTables _clearDb;
        private RegistrationRequest _teacher;
        private RegistrationRequest _tutor;
        private string _groupName;
        private List<string> _groups;
        public CancelGroupCreationStepDefinition()
        {
            _clearDb = new ClearTables();
            _swaggerGroupSteps = new GroupsAPIStepDefinitions();
            _groups = new List<string>();
        }

        [Given(@"Registrate users with roles")]
        public void GivenRegistrateUsersWithRoles(Table table)
        {
            _clearDb.ClearDB();
            _swaggerGroupSteps.GivenRegisterNewUsersWithRolesInService(table);
            List<RegistationModelWithRole> users = table.CreateSet<RegistationModelWithRole>().ToList();
            foreach(var user in users)
            {
                if(user.Role == "Teacher")
                {
                    _teacher = new RegistrationRequest() { LastName = user.LastName, FirstName = user.FirstName};
                }
                if(user.Role == "Tutor")
                {
                    _tutor = new RegistrationRequest() { LastName = user.LastName, FirstName = user.FirstName };
                }
            }
        }

        [Given(@"Open a browser and open a page")]
        public void GivenOpenABrowserAndOpenAPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage(_driver);
            _authorizationUnauthorizedPage.OpenThisPage();
        }

        [Given(@"SignIn as manager")]
        public void GivenSignInAsManager(Table table)
        {
            SwaggerSignInRequest authModel = table.CreateInstance<SwaggerSignInRequest>();
            _authorizationUnauthorizedPage.EnterEmail(authModel.Email);
            _authorizationUnauthorizedPage.EnterPassword(authModel.Password);
            _authorizationUnauthorizedPage.ClickEnterButton();
        }

        [Given(@"Start create a group ""([^""]*)""")]
        public void GivenStartCreateAGroup(string name)
        {
            _createGroupManagerAuthorizaedPage = new CreateGroupManagerAuthorizaedPage(_driver);
            _groupName = name;
            Thread.Sleep(1500);
            _createGroupManagerAuthorizaedPage.ClickAddGroupButton();
            _createGroupManagerAuthorizaedPage.EnterGroupName(name);
            _createGroupManagerAuthorizaedPage.ClickComboBoxCourses();
            Thread.Sleep(1500);
            _createGroupManagerAuthorizaedPage.ChooseCourse(Options.CourseBackendJava);
            _createGroupManagerAuthorizaedPage.ChooseTeacher(_teacher.FirstName, _teacher.LastName);
            _createGroupManagerAuthorizaedPage.ChooseTutor(_tutor.FirstName, _tutor.LastName);
        }

        [When(@"Cancel creation")]
        public void WhenCancelCreation()
        {
            _createGroupManagerAuthorizaedPage.ClickButtonCancel();
        }

        [Then(@"Group do not create")]
        public void ThenGroupDoNotCreate()
        {
            _groupsManagerAuthorizedPage = new GroupsManagerAuthorizedPage(_driver);
            _groupsManagerAuthorizedPage.ClickGroupsButton();
            List<IWebElement> actualGroups = _groupsManagerAuthorizedPage.GetAllGroups();
            foreach (var group in actualGroups)
            {
                _groups.Add(group.Text);
            }
            Assert.DoesNotContain(_groupName, _groups);
            _driver.Close();
            _clearDb.ClearDB();
        }
    }
}