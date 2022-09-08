namespace DevEduLMSAutoTests.API.StepDefinitions
{
    [Binding]
    public class StudentHomeworkCheckingStepDefinitions
    {
        private AuthenticationClient _authenticationClient;
        private UsersClient _usersClient;
        private GroupsClient _groupsClient;
        private TasksClient _tasksClient;
        private HomeworksClient _homeworksClient;
        private StudentHomeworksClient _studentHomeworksClient;
        private List<RegisterResponse> _students;
        private List<RegisterResponse> _teachers;
        private string _homeworkStatus;
        private string _managerToken;
        private string _teacherToken;
        private string _studentToken;
        private int _groupId;
        private int _taskId;
        private int _homeworkId;
        private int _studentHomeworkId;

        public StudentHomeworkCheckingStepDefinitions()
        {
            _authenticationClient = new AuthenticationClient();
            _usersClient = new UsersClient();
            _groupsClient = new GroupsClient();
            _homeworksClient = new HomeworksClient();
            _tasksClient = new TasksClient();
            _studentHomeworksClient = new StudentHomeworksClient();
            _students = new List<RegisterResponse>();
            _teachers = new List<RegisterResponse>();
        }

        [Given(@"Register students")]
        public void GivenRegisterStudents(Table table)
        {
            List<RegisterRequest> usersRegistartion = table.CreateSet<RegisterRequest>().ToList();
            foreach(var user in usersRegistartion)
            {
                RegisterResponse student = _authenticationClient.RegisterUser(user);
                _students.Add(student);
            };
        }

        [Given(@"Register teachers")]
        public void GivenRegisterTeachers(Table table)
        {
            List<RegisterRequest> usersRegistartion = table.CreateSet<RegisterRequest>().ToList();
            foreach (var user in usersRegistartion)
            {
                RegisterResponse teacher = _authenticationClient.RegisterUser(user);
                _teachers.Add(teacher);
            };
        }

        [Given(@"Authorize as manager")]
        public void GivenAuthorizeAsManager(Table table)
        {
            SwaggerSignInRequest authManager = table.CreateInstance<SwaggerSignInRequest>();
            _managerToken = _authenticationClient.AuthorizeUser(authManager);
        }

        [Given(@"Give teacher role to first user")]
        public void GivenGiveTeacherRoleToFirstUser()
        {      
            foreach (var teacher in _teachers)
            {
                _usersClient.AddNewRoleToUser(teacher.Id, Options.RoleTeacher, _managerToken);
            }
        }

        [Given(@"Manager create new group")]
        public void GivenManagerCreateNewGroup(Table table)
        {
            CreateGroupRequest group = table.CreateInstance<CreateGroupRequest>();
            _groupId = _groupsClient.CreateNewGroup(group, _managerToken, HttpStatusCode.Created).Id;
        }

        [Given(@"Manager add users to group")]
        public void GivenManagerAddUsersToGroup()
        {
            foreach (var student in _students)
            {
                _groupsClient.AddUserToGroup(_groupId, student.Id, Options.RoleStudent, _managerToken);
            }
            foreach (var teacher in _teachers)
            {
                _groupsClient.AddUserToGroup(_groupId, teacher.Id, Options.RoleTeacher, _managerToken);
            }
        }

        [Given(@"Authorize as teacher")]
        public void GivenAuthorizeAsTeacher(Table table)
        {
            SwaggerSignInRequest authManager = table.CreateInstance<SwaggerSignInRequest>();
            _teacherToken = _authenticationClient.AuthorizeUser(authManager);
        }

        [Given(@"Teacher create new task")]
        public void GivenTeacherCreateNewTask(Table table)
        {
            AddTasksByTeacherRequest task = table.CreateInstance<AddTasksByTeacherRequest>();
            task.GroupId = _groupId;
            _taskId = _tasksClient.CreateTask(task, _teacherToken).Id;
        }

        [Given(@"Add new homework")]
        public void GivenAddNewHomework(Table table)
        {
            AddHomeworkRequest homework = table.CreateInstance<AddHomeworkRequest>();
            _homeworkId = _homeworksClient.AddHomework(homework, _groupId, _taskId,  _teacherToken).Id;
        }

        [Given(@"Authorize as student")]
        public void GivenAuthorizeAsStudent(Table table)
        {
            SwaggerSignInRequest authStudent = table.CreateInstance<SwaggerSignInRequest>();
            _studentToken = _authenticationClient.AuthorizeUser(authStudent);
        }

        [Given(@"Student send passed homework")]
        public void GivenStudentSendPassedHomework()
        {
            AddHomeworkByStudentRequest model = new AddHomeworkByStudentRequest()
            {
                Answer = "string",
                HomeworkId = _homeworkId
            };
            _studentHomeworkId = _studentHomeworksClient.AddHomework(model, _studentToken, HttpStatusCode.Created).Id;
        }

        [Given(@"Teacher decline student's homework")]
        public void GivenTeacherDeclineStudentsHomework()
        {
            _studentHomeworksClient.DeclineHomework(_studentHomeworkId, _teacherToken, HttpStatusCode.OK);
        }

        [Given(@"Student send homework from the second time")]
        public void GivenStudentSendHomeworkFromTheSecondTime()
        {
            AddHomeworkByStudentRequest model = new AddHomeworkByStudentRequest()
            {
                Answer = "string",
                HomeworkId = _studentHomeworkId
            };
            _studentHomeworksClient.UpdateHomework(model, _studentToken, HttpStatusCode.OK);
        }

        [When(@"Teacher approve it")]
        public void WhenTeacherApproveIt()
        {
            _studentHomeworksClient.Approve(_homeworkId, _teacherToken, HttpStatusCode.OK);
        }

        [Then(@"Homework passed")]
        public void ThenHomeworkPassed()
        {
            _homeworkStatus = _studentHomeworksClient.GetStudenthomeworkById(_homeworkId, _studentToken, HttpStatusCode.OK).Status;
            string expectedStstus = "Done";
            Assert.AreEqual(expectedStstus, _homeworkStatus);
        }
    }
}
