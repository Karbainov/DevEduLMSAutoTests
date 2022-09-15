namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class GroupsStepDefinitions
    {
        private GroupsAPIStepDefinitions _managerCreatesAGroupAddsUsersBySwagger;
        private IWebDriver _driver;
        private AuthorizationUnauthorizedPage _authorizationUnauthorizedPage;
        private CreateGroupPage _createGroupPage;
        private LessonsStudentPage _lessonsStudentPage;
        private LessonsTeacherPage _lessonsTeacherPage;
        private LessonsTutorPage _lessonsTutorPage;
        private RegistationModelWithRole _student;
        private RegistationModelWithRole _teacher;
        private RegistationModelWithRole _tutor;
        private SwaggerSignInRequest _manager;
        private UserMappers _userMappers;
        private string _nameCourse;

        public GroupsStepDefinitions()
        {
            _managerCreatesAGroupAddsUsersBySwagger = new GroupsAPIStepDefinitions();
            _driver = new ChromeDriver();
            _authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage(_driver);
            _createGroupPage = new CreateGroupPage(_driver);
            _lessonsStudentPage = new LessonsStudentPage(_driver);
            _lessonsTeacherPage = new LessonsTeacherPage(_driver);
            _lessonsTutorPage = new LessonsTutorPage(_driver);
            _manager = new SwaggerSignInRequest() { Email = OptionsSwagger.ManagersEmail, Password = OptionsSwagger.ManagersPassword };
            _userMappers = new UserMappers();
        }

        [Given(@"register new users with roles in service")]
        public void GivenRegisterNewUsersWithRolesInService(Table table)
        {
            _managerCreatesAGroupAddsUsersBySwagger.GivenRegisterNewUsersWithRolesInService(table);
            List<RegistationModelWithRole> users = table.CreateSet<RegistationModelWithRole>().ToList();
            foreach (var user in users)
            {               
                var result = user.Role switch
                {
                    OptionsSwagger.RoleStudent => _student = user,
                    OptionsSwagger.RoleTeacher => _teacher = user,
                    OptionsSwagger.RoleTutor => _tutor = user,
                    _ => throw new ArgumentOutOfRangeException(nameof(user.Role)),
                };
            }
        }

        [When(@"manager create new group in service")]
        public void WhenManagerCreateNewGroupInService(Table table)
        {
            _managerCreatesAGroupAddsUsersBySwagger.WhenManagerCreateNewGroupInService(table);
        }

        [When(@"manager add users to group in service")]
        public void WhenManagerAddUsersToGroupInService()
        {
            _managerCreatesAGroupAddsUsersBySwagger.WhenManagerAddUsersToGroupInService();
        }

        [Then(@"authorize student in service and check group")]
        public void ThenAuthorizeStudentInServiceAndCheckGroup()
        {
            AuthorizeUser(_userMappers.MappRegistationModelWithRoleToSwaggerSignInRequest(_student));
            Thread.Sleep(500);
            _lessonsStudentPage.ClickLessonsButton();
            var groups = _lessonsStudentPage.ListStudentGroups;
            Assert.Equal(Urls.ExpectedLessonsUrl, _driver.Url);
            Assert.Contains(groups, i => i.Text == "Базовый C#");
            _lessonsStudentPage.ClickExitButton();
        }

        [Then(@"authorize teacher in service and check group")]
        public void ThenAuthorizeTeacherInServiceAndCheckGroup()
        {
            AuthorizeUser(_userMappers.MappRegistationModelWithRoleToSwaggerSignInRequest(_teacher));
            Thread.Sleep(500);
            _lessonsTeacherPage.ClickLessonsButton();
            _lessonsTeacherPage.ChageRole(_teacher.Role);
            var groups = _lessonsTeacherPage.ListTeacherGroups;
            Assert.Equal(Urls.ExpectedLessonsUrl, _driver.Url);
            Assert.Contains(groups, i => i.Text == "Базовый C#");
            _lessonsTeacherPage.ClickExitButton();
        }

        [Then(@"authorize tutor in service and check group")]
        public void ThenAuthorizeTutorInServiceAndCheckGroup()
        {
            AuthorizeUser(_userMappers.MappRegistationModelWithRoleToSwaggerSignInRequest(_tutor));
            Thread.Sleep(500);
            _lessonsTutorPage.ClickLessonsButton();
            _lessonsTutorPage.ChageRole(_tutor.Role);
            var groups = _lessonsTutorPage.ListTutorGroups;
            Assert.Equal(Urls.ExpectedLessonsUrl, _driver.Url);
            Assert.Contains(groups, i => i.Text == "Базовый C#");
            _lessonsTutorPage.ClickExitButton();
            _driver.Close();
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
