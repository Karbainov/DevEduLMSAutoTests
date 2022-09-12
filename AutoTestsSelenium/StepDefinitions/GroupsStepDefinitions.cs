namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class GroupsStepDefinitions
    {
        private GroupsAPIStepDefinitions _managerCreatesAGroupAddsUsersBySwagger;
        private IWebDriver _driver;
        private SingInWindow _singInWindow;
        private ManagerNavigatePanelElements _managerNavigatePanelElements;
        private StudentNavigatePanelElements _studentNavigatePanelElements;
        private TeacherNavigatePanelElements _teacherNavigatePanelElements;
        private TutorNavigatePanelElements _tutorNavigatePanelElements;
        private CreateGroupWindow _createGroupWindow;
        private StudentLessonWindow _studentLessonWindow;
        private TeacherLessonsWindow _teacherLessonsWindow;
        private TutorLessonsWindow _tutorLessonsWindow;
        private RegistationModelWithRole _student;
        private RegistationModelWithRole _teacher;
        private RegistationModelWithRole _tutor;
        private SwaggerSignInRequest _manager;
        private ClearTables _clearDB;
        private UserMappers _userMappers;
        private SwitchRole _switchRole;
        private string _nameGroup;

        public GroupsStepDefinitions()
        {
            _managerCreatesAGroupAddsUsersBySwagger = new GroupsAPIStepDefinitions();
            _driver = new ChromeDriver();
            _singInWindow = new SingInWindow();
            _managerNavigatePanelElements = new ManagerNavigatePanelElements();
            _studentNavigatePanelElements = new StudentNavigatePanelElements();
            _teacherNavigatePanelElements = new TeacherNavigatePanelElements();
            _tutorNavigatePanelElements = new TutorNavigatePanelElements();
            _createGroupWindow = new CreateGroupWindow();
            _studentLessonWindow = new StudentLessonWindow();
            _teacherLessonsWindow = new TeacherLessonsWindow();
            _tutorLessonsWindow = new TutorLessonsWindow();
            _manager = new SwaggerSignInRequest() { Email = OptionsSwagger.ManagersEmail, Password = OptionsSwagger.ManagersPassword };
            _clearDB = new ClearTables();
            _userMappers = new UserMappers();
            _switchRole = new SwitchRole();
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
            //_driver.FindElement(_managerNavigatePanelElements.XPathCreateGroupButton).Click();
            //_driver.FindElement(_createGroupWindow.XPathNameGroupBox).SendKeys(newGroup.Name);
            //_driver.FindElement(_createGroupWindow.XPathCoursesComboBox).Click();
            //var course = _driver.FindElement(_createGroupWindow.XPathCourseButton((newGroup.CourseId).ToString()));
            //course.Click();
            //_nameGroup = course.Text;
            //_driver.FindElement(_createGroupWindow.XPathTeacherCheckBox($"{_teacher.FirstName} {_teacher.LastName}")).Click();
            //_driver.FindElement(_createGroupWindow.XPathTutorCheckBox($"{_tutor.FirstName} {_tutor.LastName}")).Click();
            //_driver.FindElement(_createGroupWindow.XPathSaveButton).Click();
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
            _driver.FindElement(_studentNavigatePanelElements.XPathLessonsButton).Click();
            var groups = _driver.FindElements(_studentLessonWindow.XPathGroups);
            Assert.Equal(Options.ExpectedLessonsUrl, _driver.Url);
            Assert.Contains(groups, i => i.Text == Options.CourseBasicSiSharp);
            _driver.FindElement(_studentNavigatePanelElements.XPathExitButton).Click();
        }

        [Then(@"authorize teacher in service and check group")]
        public void ThenAuthorizeTeacherInServiceAndCheckGroup()
        {
            AuthorizeUser(_userMappers.MappRegistationModelWithRoleToSwaggerSignInRequest(_teacher));
            Thread.Sleep(500);
            _driver.FindElement(_teacherNavigatePanelElements.XPathSwitchRoleButton).Click();
            _driver.FindElement(_switchRole.XPathRoleButton(_teacher.Role)).Click();
            _driver.FindElement(_teacherNavigatePanelElements.XPathLessonsButton).Click();
            var groups = _driver.FindElements(_teacherLessonsWindow.XPathGroups);
            Assert.Equal(Options.ExpectedLessonsUrl, _driver.Url);
            Assert.Contains(groups, i => i.Text == Options.CourseBasicSiSharp);
            _driver.FindElement(_teacherNavigatePanelElements.XPathExitButton).Click();
        }

        [Then(@"authorize tutor in service and check group")]
        public void ThenAuthorizeTutorInServiceAndCheckGroup()
        {
            AuthorizeUser(_userMappers.MappRegistationModelWithRoleToSwaggerSignInRequest(_tutor));
            Thread.Sleep(500);
            _driver.FindElement(_tutorNavigatePanelElements.XPathSwitchRoleButton).Click();
            _driver.FindElement(_switchRole.XPathRoleButton(_tutor.Role)).Click();
            _driver.FindElement(_tutorNavigatePanelElements.XPathLessonsButton).Click();
            var groups = _driver.FindElements(_tutorLessonsWindow.XPathGroups);
            Assert.Equal(Options.ExpectedLessonsUrl, _driver.Url);
            Assert.Contains(groups, i => i.Text == Options.CourseBasicSiSharp);
            _driver.FindElement(_tutorNavigatePanelElements.XPathExitButton).Click();
            _driver.Close();
            _clearDB.ClearDB();
        }

        private void AuthorizeUser(SwaggerSignInRequest user)
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Urls.Host);
            _driver.FindElement(_singInWindow.XPathEmailBox).SendKeys(user.Email);
            _driver.FindElement(_singInWindow.XPathPasswordBox).Clear();
            _driver.FindElement(_singInWindow.XPathPasswordBox).SendKeys(user.Password);
            _driver.FindElement(_singInWindow.XPathSingInButton).Click();
        }
    }
}
