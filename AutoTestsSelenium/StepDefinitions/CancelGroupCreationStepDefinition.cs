namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class CancelGroupCreationStepDefinition
    {
        private IWebDriver _driver;
        private GroupsAPIStepDefinitions _swaggerGroupSteps;
        private AuthorizationUnauthorizedPage _authorizationUnauthorizedPage;
        private CreateGroupManagerAuthorizaedPage _createGroupManagerAuthorizaedPage;
        private GroupsManagerPage _groupsManagerPage;
        private string _groupName;
        private List<string> _groups;
        public CancelGroupCreationStepDefinition()
        {
            _swaggerGroupSteps = new GroupsAPIStepDefinitions();
            _groups = new List<string>();
        }

        [Given(@"Registrate users with roles")]
        public void GivenRegistrateUsersWithRoles(Table table)
        {
            _swaggerGroupSteps.GivenRegisterNewUsersWithRolesInService(table);
            List<RegistationModelWithRole> users = table.CreateSet<RegistationModelWithRole>().ToList();
        }

        [Given(@"Open a browser and open login page")]
        public void GivenOpenABrowserAndOpenLoginPage()
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

        [Given(@"Start create a group")]
        public void GivenStartCreateAGroup(Table table)
        {
            _createGroupManagerAuthorizaedPage = new CreateGroupManagerAuthorizaedPage(_driver);
            GroupCreationRequest groupModel = table.CreateInstance<GroupCreationRequest>();
            _groupName = groupModel.Name;
            Thread.Sleep(1500);
            _createGroupManagerAuthorizaedPage.ClickAddGroupButton();
            _createGroupManagerAuthorizaedPage.EnterGroupName(groupModel.Name);
            _createGroupManagerAuthorizaedPage.ClickComboBoxCourses();
            Thread.Sleep(1500);
            _createGroupManagerAuthorizaedPage.ChooseCourse(groupModel.CourseName);
            _createGroupManagerAuthorizaedPage.ChooseTeacher(groupModel.Teacher);
            _createGroupManagerAuthorizaedPage.ChooseTutor(groupModel.Tutor);
        }

        [When(@"Cancel creation")]
        public void WhenCancelCreation()
        {
            _createGroupManagerAuthorizaedPage.ClickButtonCancel();
        }

        [Then(@"Group ""([^""]*)"" do not create")]
        public void ThenGroupDoNotCreate(string groupName)
        {
            _groupsManagerPage = new GroupsManagerPage(_driver);
            _groupsManagerPage.ClickGroupsButton();
            List<IWebElement> actualGroups = _groupsManagerPage.GetAllGroups();
            Assert.DoesNotContain(actualGroups, i => i.Text == groupName);
            _driver.Close();
        }
    }
}