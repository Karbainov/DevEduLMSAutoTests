namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class GroupsStepDefinitions
    {
        private GroupsAPIStepDefinitions _managerCreatesAGroupAddsUsersBySwagger;
        private IWebDriver _driver;
        private AuthorizationUnauthorizedPage _authorizationUnauthorizedPage;
        private GroupCreationManagerPage _groupCreationManagerPage;
        private GroupsManagerPage _groupsManagerPage;
        private StudentsListPage _studentsListPage;
        private LessonsStudentPage _lessonsStudentPage;
        private LessonsTeacherPage _lessonsTeacherPage;
        private LessonsTutorPage _lessonsTutorPage;
        private SwaggerSignInRequest _manager;

        public GroupsStepDefinitions()
        {
            _managerCreatesAGroupAddsUsersBySwagger = new GroupsAPIStepDefinitions();
            _driver = SingleWebDriver.GetInstance();
            _authorizationUnauthorizedPage = new AuthorizationUnauthorizedPage(_driver);
            _groupCreationManagerPage = new GroupCreationManagerPage(_driver);
            _groupsManagerPage = new GroupsManagerPage(_driver);
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

        [Given(@"SignIn as manager")]
        public void GivenSignInAsManager()
        {
            AuthorizeUser(_manager);
        }

        [Given(@"Manager create new group in service and cancel creation")]
        public void GivenManagerCreateNewGroupInServiceAndCancelCreation(Table table)
        {
            GroupCreationModel newGroup = table.CreateInstance<GroupCreationModel>();
            _groupCreationManagerPage.ClickAddGroupButton();
            _groupCreationManagerPage.EnterGroupName(newGroup.GroupName);
            _groupCreationManagerPage.ClickCoursesComboBox();
            _groupCreationManagerPage.ClickDesiredCourseByName(newGroup.CourseName);
            _groupCreationManagerPage.ChooseTeacher(newGroup.FullNameOfTeacher);
            _groupCreationManagerPage.ChooseTutor(newGroup.FullNameOfTutor);
            _groupCreationManagerPage.ClickCancelCreateGroupButton();
        }

        [When(@"Manager create new group in service")]
        public void WhenManagerCreateNewGroupInService(Table table)
        {
            GroupCreationModel newGroup = table.CreateInstance<GroupCreationModel>();
            _groupCreationManagerPage.ClickAddGroupButton();
            _groupCreationManagerPage.EnterGroupName(newGroup.GroupName);
            _groupCreationManagerPage.ClickCoursesComboBox();
            _groupCreationManagerPage.ClickDesiredCourseByName(newGroup.CourseName);
            _groupCreationManagerPage.ChooseTeacher(newGroup.FullNameOfTeacher);
            _groupCreationManagerPage.ChooseTutor(newGroup.FullNameOfTutor);
            _groupCreationManagerPage.ClickSaveButton();
            //TODO Saves only when there are more than two teachers and tutors (Task 2.6).
        }

        [When(@"Manager add student ""([^""]*)"" to group ""([^""]*)"" in service")]
        public void WhenManagerAddStudentToGroupInService(string fullNameOfStudent, string groupName)
        {
            _studentsListPage.ClickStudentsListButton();
            _studentsListPage.ClickGroupsComboBoxByFullNameOfStudent(fullNameOfStudent);
            _studentsListPage.ClickDesiredGroupByName(groupName);
            _studentsListPage.ClickExitButton();
            //TODO The page is implemented as a mock (Task 2.6).
        }

        [Then(@"Authorize student in service and check group")]
        public void ThenAuthorizeStudentInServiceAndCheckGroup(Table table)
        {
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
            _lessonsStudentPage.ClickLessonsButton();
            var groups = _lessonsStudentPage.StudentGroups;
            Assert.Contains(groups, i => i.Text == checkingModel.CourseName);
            _lessonsStudentPage.ClickExitButton();
        }

        [Then(@"Authorize teacher in service and check group")]
        public void ThenAuthorizeTeacherInServiceAndCheckGroup(Table table)
        {
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
            _lessonsTeacherPage.ChageRole(checkingModel.Role);
            _lessonsTeacherPage.ClickLessonsButton();
            var groups = _lessonsTeacherPage.TeacherGroups;
            Assert.Contains(groups, i => i.Text == checkingModel.CourseName);
            _lessonsTeacherPage.ClickExitButton();
        }

        [Then(@"Authorize tutor in service and check group")]
        public void ThenAuthorizeTutorInServiceAndCheckGroup(Table table)
        {
            CheckingUserInGroupModel checkingModel = table.CreateInstance<CheckingUserInGroupModel>();
            AuthorizeUser(new SwaggerSignInRequest() { Email = checkingModel.Email, Password = checkingModel.Password });
            _lessonsTutorPage.ChageRole(checkingModel.Role);
            _lessonsTutorPage.ClickLessonsButton();
            var groups = _lessonsTutorPage.TutorGroups;
            Assert.Contains(groups, i => i.Text == checkingModel.CourseName);
            _lessonsTutorPage.ClickExitButton();
            _driver.Close();
        }

        [Then(@"Group ""([^""]*)"" do not create")]
        public void ThenGroupDoNotCreate(string groupName)
        {
            _groupsManagerPage.ClickGroupsButton();
            var groups = _groupsManagerPage.AllGroups;
            Assert.DoesNotContain(groups, i => i.Text == groupName);
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
