namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class CancelGroupCreationStepDefinition
    {
        private IWebDriver _driver;
        private GroupsAPIStepDefinitions _swaggerGroupSteps;
        private AuthorizationUnauthorizedPage _authorizationUnauthorizedPage;
        private GroupCreationManagerPage _groupCreationManagerPage;
        private GroupsManagerPage _groupsManagerPage;

        public CancelGroupCreationStepDefinition()
        {
            _driver = new ChromeDriver();
            _swaggerGroupSteps = new GroupsAPIStepDefinitions();
            _authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage(_driver);
            _groupCreationManagerPage = new GroupCreationManagerPage(_driver);
            _groupsManagerPage = new GroupsManagerPage(_driver);
        }

        [Given(@"Registrate users with roles")]
        public void GivenRegistrateUsersWithRoles(Table table)
        {
            _swaggerGroupSteps.GivenRegisterNewUsersWithRolesInService(table);
        }

        [Given(@"Open a browser and open login page")]
        public void GivenOpenABrowserAndOpenLoginPage()
        {
            _driver.Manage().Window.Maximize();
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
            GroupCreationModel groupModel = table.CreateInstance<GroupCreationModel>();
            Thread.Sleep(500);
            _groupCreationManagerPage.ClickAddGroupButton();
            _groupCreationManagerPage.EnterGroupName(groupModel.GroupName);
            _groupCreationManagerPage.ClickCoursesComboBox();
            Thread.Sleep(500);
            _groupCreationManagerPage.ClickDesiredCourseByName(groupModel.CourseName);
            _groupCreationManagerPage.ChooseTeacher(groupModel.FullNameOfTeacher);
            _groupCreationManagerPage.ChooseTutor(groupModel.FullNameOfTutor);
        }

        [When(@"Cancel creation")]
        public void WhenCancelCreation()
        {
            _groupCreationManagerPage.ClickCancelCreateGroupButton();
        }

        [Then(@"Group ""([^""]*)"" do not create")]
        public void ThenGroupDoNotCreate(string groupName)
        {
            _groupsManagerPage.ClickGroupsButton();
            List<IWebElement> actualGroups = _groupsManagerPage.GetAllGroups();
            Assert.DoesNotContain(actualGroups, i => i.Text == groupName);
            _driver.Close();
        }
    }
}