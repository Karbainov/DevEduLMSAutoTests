namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class GroupsStepDefinitions
    {
        private GroupsAPIStepDefinitions _managerCreatesAGroupAddsUsersBySwagger;
        private IWebDriver _driver;
        private AuthorizationUnauthorizedPage _authorizationUnauthorizedPage;
        private GroupCreationManagerPage _createGroupPage;
        private StudentsListPage _studentsListPage;
        private LessonsStudentPage _lessonsStudentPage;
        private LessonsTeacherPage _lessonsTeacherPage;
        private LessonsTutorPage _lessonsTutorPage;
        private SwaggerSignInRequest _manager;

        public GroupsStepDefinitions()
        {
            _managerCreatesAGroupAddsUsersBySwagger = new GroupsAPIStepDefinitions();
            _driver = new ChromeDriver();
            _authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage(_driver);
            _createGroupPage = new GroupCreationManagerPage(_driver);
            _studentsListPage = new StudentsListPage(_driver);
            _lessonsStudentPage = new LessonsStudentPage(_driver);
            _lessonsTeacherPage = new LessonsTeacherPage(_driver);
            _lessonsTutorPage = new LessonsTutorPage(_driver);
            _manager = new SwaggerSignInRequest() { Email = OptionsSwagger.ManagersEmail, Password = OptionsSwagger.ManagersPassword };
        }

        [Given(@"Register new users with roles in service")]
        public void GivenRegisterNewUsersWithRolesInService(Table table)
        {
            _managerCreatesAGroupAddsUsersBySwagger.GivenRegisterNewUsersWithRolesInService(table);
        }

        [When(@"Manager create new group in service")]
        public void WhenManagerCreateNewGroupInService(Table table)
        {
            GroupCreationModel newGroup = table.CreateInstance<GroupCreationModel>();
            AuthorizeUser(_manager);
            Thread.Sleep(500);
            _createGroupPage.ClickAddGroupButton();
            _createGroupPage.EnterGroupName(newGroup.GroupName);
            _createGroupPage.ClickCoursesComboBox();
            _createGroupPage.ClickDesiredCourseByName(newGroup.CourseName);
            _createGroupPage.ChooseTeacher(newGroup.FullNameOfTeacher);
            _createGroupPage.ChooseTutor(newGroup.FullNameOfTutor);
            _createGroupPage.ClickSaveButton();
            //TODO Сохраняет только в случае, когда больше двух преподавателей и тьюторов (Таска 2.6).
        }

        [When(@"Manager add student ""([^""]*)"" to group ""([^""]*)"" in service")]
        public void WhenManagerAddStudentToGroupInService(string fullNameOfStudent, string groupName)
        {
            _studentsListPage.ClickStudentsListButton();
            _studentsListPage.ClickGroupsComboBoxByFullNameOfStudent(fullNameOfStudent);
            _studentsListPage.ClickDesiredGroupByName(groupName);
            _studentsListPage.ClickExitButton();
            //TODO Страница реализована в виде мока (Таска 2.6).
        }

        [Then(@"Authorize student in service and check group")]
        public void ThenAuthorizeStudentInServiceAndCheckGroup(Table table)
        {
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
            Thread.Sleep(500);
            _lessonsStudentPage.ClickLessonsButton();
            var groups = _lessonsStudentPage.StudentCourses;
            Assert.Contains(groups, i => i.Text == checkingModel.CourseName);
            _lessonsStudentPage.ClickExitButton();
        }

        [Then(@"Authorize teacher in service and check group")]
        public void ThenAuthorizeTeacherInServiceAndCheckGroup(Table table)
        {
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
            Thread.Sleep(500);
            _lessonsTeacherPage.ClickLessonsButton();
            var groups = _lessonsTeacherPage.TeacherCourses;
            Assert.Contains(groups, i => i.Text == checkingModel.CourseName);
            _lessonsTeacherPage.ClickExitButton();
        }

        [Then(@"Authorize tutor in service and check group")]
        public void ThenAuthorizeTutorInServiceAndCheckGroup(Table table)
        {
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
            Thread.Sleep(500);
            _lessonsTutorPage.ClickLessonsButton();
            var groups = _lessonsTutorPage.TutorCourses;
            Assert.Contains(groups, i => i.Text == checkingModel.CourseName);
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
