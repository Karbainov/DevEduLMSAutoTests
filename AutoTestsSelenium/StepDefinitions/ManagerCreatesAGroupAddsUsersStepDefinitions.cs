namespace AutoTestsSelenium.StepDefinitions
{
    [Binding]
    public class ManagerCreatesAGroupAddsUsersStepDefinitions
    {
        private ManagerCreatesAGroupAddsUsersStepDefinitions _managerCreatesAGroupAddsUsersBySwagger;
        private IWebDriver _driver;
        private SingInWindow _singInWindow;
        private CreateGroupWindow _createGroupWindow;
        private StudentLessonsWindow _studentLessons;
        private TeacherLessonsWindow _teacherLessons;
        private TutorLessonsWindow _tutorLessons;
        private Actions _action;
        private RegistationModelWithRole _student;
        private RegistationModelWithRole _teacher;
        private RegistationModelWithRole _tutor;
        private ClearTables _clearDB;

        public ManagerCreatesAGroupAddsUsersStepDefinitions()
        {
            _managerCreatesAGroupAddsUsersBySwagger = new ManagerCreatesAGroupAddsUsersStepDefinitions();
            _driver = new ChromeDriver();
            _singInWindow = new SingInWindow();
            _createGroupWindow = new CreateGroupWindow();
            _studentLessons = new StudentLessonsWindow();
            _teacherLessons = new TeacherLessonsWindow();
            _tutorLessons = new TutorLessonsWindow();
            _action = new Actions(_driver);
            _student = new RegistationModelWithRole();
            _teacher = new RegistationModelWithRole();
            _tutor = new RegistationModelWithRole();
            _clearDB = new ClearTables();
        }

        [Given(@"registration users in service")]
        public void GivenRegistrationUsersInService(Table table)
        {
            _clearDB.ClearDB();
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
                _managerCreatesAGroupAddsUsersBySwagger.GivenRegistrationUsersInService(table);
            }
        }

        [Given(@"authorize manager in service")]
        public void GivenAuthorizeManagerInService()
        {
            _managerCreatesAGroupAddsUsersBySwagger.GivenAuthorizeManagerInService();
            //_driver.Navigate().GoToUrl(Urls.Host);
            //var emailBox = _driver.FindElement(_singInWindow.XPathEmailBox);
            //emailBox.SendKeys(DevEduLMSAutoTests.API.Support.Options.ManagersEmail);
            //var passwordBox = _driver.FindElement(_singInWindow.XPathPasswordBox);
            //_action.DoubleClick(passwordBox).Build().Perform();
            //passwordBox.SendKeys(Keys.Backspace);
            //passwordBox.SendKeys(DevEduLMSAutoTests.API.Support.Options.ManagersPassword);
            //_driver.FindElement(_singInWindow.XPathSingInButton).Click();
        }

        [Given(@"manager add roles to users in service")]
        public void GivenManagerAddRolesToUsersInService()
        {
            _managerCreatesAGroupAddsUsersBySwagger.GivenManagerAddRolesToUsersInService();

        }

        [When(@"manager create new group in service")]
        public void WhenManagerCreateNewGroupInService(Table table)
        {
            _managerCreatesAGroupAddsUsersBySwagger.WhenManagerCreateNewGroupInService(table);
            //CreateGroupRequest newGroup = table.CreateInstance<CreateGroupRequest>();
            //_driver.FindElement(_createGroupWindow.XPathCreateGroupButton).Click();
            //var nameGroupBox = _driver.FindElement(_createGroupWindow.XPathNameGroupBox);
            //nameGroupBox.SendKeys(newGroup.Name);
            //var coursesComboBox = _driver.FindElement(CreateGroupWindow.XPathCoursesComboBox((newGroup.CourseId).ToString()));
            //coursesComboBox.SendKeys(Keys.ArrowDown);
            //coursesComboBox.SendKeys(Keys.Enter);
            //_driver.FindElement(CreateGroupWindow.XPathTeacherCheckBox($"{_teacher.FirstName} {_teacher.LastName}")).Click();
            //_driver.FindElement(CreateGroupWindow.XPathTutorCheckBox($"{_tutor.FirstName} {_tutor.LastName}")).Click();
            //_driver.FindElement(_createGroupWindow.XPathSaveButton).Click();
        }

        [When(@"manager add users to group in service")]
        public void WhenManagerAddUsersToGroupInService()
        {
            _managerCreatesAGroupAddsUsersBySwagger.WhenManagerAddUsersToGroupInService();
        }

        [Then(@"authorize student in service and check group")]
        public void ThenAuthorizeStudentInServiceAndCheckGroup()
        {
            AuthorizeUser(_student);
            _driver.FindElement(_studentLessons.XPathLessonsButton).Click();
        }

        [Then(@"authorize teacher in service and check group")]
        public void ThenAuthorizeTeacherInServiceAndCheckGroup()
        {
            AuthorizeUser(_teacher);
            _driver.FindElement(_teacherLessons.XPathLessonsButton).Click();
        }

        [Then(@"authorize tutor in service and check group")]
        public void ThenAuthorizeTutorInServiceAndCheckGroup()
        {
            AuthorizeUser(_tutor);
            _driver.FindElement(_tutorLessons.XPathLessonsButton).Click();
        }

        private void AuthorizeUser(RegistationModelWithRole user)
        {
            _driver.Navigate().GoToUrl(Urls.Host);
            var emailBox = _driver.FindElement(_singInWindow.XPathEmailBox);
            emailBox.SendKeys(user.Email);
            var passwordBox = _driver.FindElement(_singInWindow.XPathPasswordBox);
            _action.DoubleClick(passwordBox).Build().Perform();
            passwordBox.SendKeys(Keys.Backspace);
            passwordBox.SendKeys(user.Password);
            _driver.FindElement(_singInWindow.XPathSingInButton).Click();
        }
    }
}
