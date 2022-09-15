namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class GroupsStepDefinitions
    {
        private GroupsAPIStepDefinitions _managerCreatesAGroupAddsUsersBySwagger;
        private IWebDriver _driver;
        private AuthorizationUnauthorizedPage _authorizationUnauthorizedPage;
        private CreateGroupPage _createGroupPage;
        private StudentLessonsPage _studentLessonsPage;
        private TeacherLessonsPage _teacherLessonsPage;
        private TutorLessonsPage _tutorLessonsPage;
        private RegistationModelWithRole _student;
        private RegistationModelWithRole _teacher;
        private RegistationModelWithRole _tutor;
        private SwaggerSignInRequest _manager;
        private ClearTables _clearDB;
        private UserMappers _userMappers;
        private string _nameCourse;

        public GroupsStepDefinitions()
        {
            _managerCreatesAGroupAddsUsersBySwagger = new GroupsAPIStepDefinitions();
            _driver = new ChromeDriver();
            _authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage(_driver);
            _createGroupPage = new CreateGroupPage(_driver);
            _studentLessonsPage = new StudentLessonsPage(_driver);
            _teacherLessonsPage = new TeacherLessonsPage(_driver);
            _tutorLessonsPage = new TutorLessonsPage(_driver);
            _manager = new SwaggerSignInRequest() { Email = OptionsSwagger.ManagersEmail, Password = OptionsSwagger.ManagersPassword };
            _clearDB = new ClearTables();
            _userMappers = new UserMappers();
        }

        [Given(@"register new users with roles in service")]
        public void GivenRegisterNewUsersWithRolesInService(Table table)
        {
            _clearDB.ClearDB();
            _managerCreatesAGroupAddsUsersBySwagger.GivenRegisterNewUsersWithRolesInService(table);
            List<RegistationModelWithRole> users = table.CreateSet<RegistationModelWithRole>().ToList();
            foreach (var user in users)
            {
                switch (user.Role)
                {
                    case OptionsSwagger.RoleStudent:
                        {
                            _student = user;
                        }
                        break;
                    case OptionsSwagger.RoleTeacher:
                        {
                            _teacher = user;
                        }
                        break;
                    case OptionsSwagger.RoleTutor:
                        {
                            _tutor = user;
                        }
                        break;
                }
            }
        }

        [When(@"manager create new group in service")]
        public void WhenManagerCreateNewGroupInService(Table table)
        {
            _managerCreatesAGroupAddsUsersBySwagger.WhenManagerCreateNewGroupInService(table);
            //CreateGroupRequest newGroup = table.CreateInstance<CreateGroupRequest>();
            //AuthorizeUser(_manager);
            //Thread.Sleep(500);
            //_createGroupPage.ClickAddGroupButton();
            //_createGroupPage.EnterNameGroup(newGroup.Name);
            //_nameCourse = _createGroupPage.ChageCourse((newGroup.CourseId).ToString());
            //_createGroupPage.ClickTeacherCheckBox(_teacher.FirstName, _teacher.LastName);
            //_createGroupPage.ClickTutorCheckBox(_tutor.FirstName, _tutor.LastName);
            //_createGroupPage.ClickSaveButton();
        }

        [When(@"manager add users to group in service")]
        public void WhenManagerAddUsersToGroupInService()
        {
            _managerCreatesAGroupAddsUsersBySwagger.WhenManagerAddUsersToGroupInService();
            //_driver.FindElement(_managerNavigatePanelElements.XPathExitButton).Click();
        }

        [Then(@"authorize student in service and check group")]
        public void ThenAuthorizeStudentInServiceAndCheckGroup()
        {
            AuthorizeUser(_userMappers.MappRegistationModelWithRoleToSwaggerSignInRequest(_student));
            Thread.Sleep(500);
            _studentLessonsPage.ClickLessonsButton();
            var groups = _studentLessonsPage.FindStudentGroups();
            Assert.Equal(Options.ExpectedLessonsUrl, _driver.Url);
            Assert.Contains(groups, i => i.Text == Options.CourseBasicSiSharp);
            _studentLessonsPage.ClickExitButton();
        }

        [Then(@"authorize teacher in service and check group")]
        public void ThenAuthorizeTeacherInServiceAndCheckGroup()
        {
            AuthorizeUser(_userMappers.MappRegistationModelWithRoleToSwaggerSignInRequest(_teacher));
            Thread.Sleep(500);
            _teacherLessonsPage.ClickLessonsButton();
            _teacherLessonsPage.ChageRole(_teacher.Role);
            var groups = _teacherLessonsPage.FindTeacherGroups();
            Assert.Equal(Options.ExpectedLessonsUrl, _driver.Url);
            Assert.Contains(groups, i => i.Text == Options.CourseBasicSiSharp);
            _teacherLessonsPage.ClickExitButton();
        }

        [Then(@"authorize tutor in service and check group")]
        public void ThenAuthorizeTutorInServiceAndCheckGroup()
        {
            AuthorizeUser(_userMappers.MappRegistationModelWithRoleToSwaggerSignInRequest(_tutor));
            Thread.Sleep(500);
            _tutorLessonsPage.ClickLessonsButton();
            _tutorLessonsPage.ChageRole(_tutor.Role);
            var groups = _tutorLessonsPage.FindTutorGroups();
            Assert.Equal(Options.ExpectedLessonsUrl, _driver.Url);
            Assert.Contains(groups, i => i.Text == Options.CourseBasicSiSharp);
            _tutorLessonsPage.ClickExitButton();
            _driver.Close();
            _clearDB.ClearDB();
        }

        private void AuthorizeUser(SwaggerSignInRequest user)
        {
            _driver.Manage().Window.Maximize();
            _authorizationUnauthorizedPage.OpenThisPage();
            _authorizationUnauthorizedPage.EnterEmail(user.Email);
            _authorizationUnauthorizedPage.EnterPassword(user.Password);
            _authorizationUnauthorizedPage.ClickEnterButton();
        }
    }
}
