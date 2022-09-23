namespace DevEduLMSAutoTests.API.StepDefinitions
{
    [Binding]
    public class TasksStepDefinitions
    {
        private List<string> _studentsTokens;
        private List<string> _teachersTokens;
        private List<string> _methodistsTokens;
        private List<string> _tutorsTokens;
        private string _studentMainToken;
        private string _teacherMainToken;
        private string _methodistMainToken;
        private string _tutorMainToken;
        private string _managerToken;
        private List<int> _studentsIds;
        private List<int> _teachersIds;
        private List<int> _methodistsIds;
        private List<int> _tutorsIds;
        private int _studentMainId;
        private int _teacherMainId;
        private int _methodistMainId;
        private int _tutorMainId;
        private int _groupId;
        private int _taskId;
        private AuthenticationClient _authenticationClient;
        private UsersClient _usersClient;
        private GroupsClient _groupsClient;
        private TasksClient _tasksClient;
        private HomeworksClient _homeworksClient;
        private TaskResponse _expectedTask;
        private GetHomeworkByGroupIdResponse _expectedHomework;
        private List<RegistationModelWithRole> _newUsers;

        public TasksStepDefinitions()
        {
            _studentsTokens = new List<string>();
            _teachersTokens = new List<string>();
            _methodistsTokens = new List<string>();
            _tutorsTokens = new List<string>();
            _studentsIds = new List<int>();
            _teachersIds = new List<int>();
            _methodistsIds = new List<int>();
            _tutorsIds = new List<int>();
            _authenticationClient = new AuthenticationClient();
            _usersClient = new UsersClient();
            _groupsClient = new GroupsClient();
            _tasksClient = new TasksClient();
            _homeworksClient = new HomeworksClient();
        }

        [Given(@"register new users with roles")]
        public void GivenRegisterNewUsersWithRoles(Table table)
        {
            _managerToken = _authenticationClient.AuthorizeUser(new SignInRequest() { Email = OptionsSwagger.ManagersEmail, Password = OptionsSwagger.ManagersPassword });
            _newUsers = table.CreateSet<RegistationModelWithRole>().ToList();
            foreach (var user in _newUsers)
            {
                RegisterRequest registerRequest = user.CreateRegisterRequest(user);
                int id = _authenticationClient.RegisterUser(registerRequest).Id;
                switch (user.Role)
                {
                    case OptionsSwagger.RoleTeacher:
                        {
                            _teachersIds.Add(id);
                            _usersClient.AddNewRoleToUser(id, user.Role, _managerToken, HttpStatusCode.NoContent);
                            _usersClient.DeleteUsersRole(id, OptionsSwagger.RoleStudent, _managerToken);
                            _teachersTokens.Add(_authenticationClient.AuthorizeUser(new SignInRequest()
                            { Email = user.Email, Password = user.Password }));
                        }
                        break;
                    case OptionsSwagger.RoleTutor:
                        {
                            _tutorsIds.Add(id);
                            _usersClient.AddNewRoleToUser(id, user.Role, _managerToken, HttpStatusCode.NoContent);
                            _usersClient.DeleteUsersRole(id, OptionsSwagger.RoleStudent, _managerToken);
                            _tutorsTokens.Add(_authenticationClient.AuthorizeUser(new SignInRequest()
                            { Email = user.Email, Password = user.Password }));
                        }
                        break;
                    case OptionsSwagger.RoleMethodist:
                        {
                            _methodistsIds.Add(id);
                            _usersClient.AddNewRoleToUser(id, user.Role, _managerToken, HttpStatusCode.NoContent);
                            _usersClient.DeleteUsersRole(id, OptionsSwagger.RoleStudent, _managerToken);
                            _methodistsTokens.Add(_authenticationClient.AuthorizeUser(new SignInRequest()
                            { Email = user.Email, Password = user.Password }));
                        }
                        break;
                    case OptionsSwagger.RoleManager:
                        {
                            _methodistsIds.Add(id);
                            _usersClient.AddNewRoleToUser(id, user.Role, _managerToken);
                            _usersClient.DeleteUsersRole(id, OptionsSwagger.RoleStudent, _managerToken);
                        }
                        break;
                    case OptionsSwagger.RoleStudent:
                        {
                            _studentsIds.Add(id);
                            _studentsTokens.Add(_authenticationClient.AuthorizeUser(new SignInRequest()
                            { Email = user.Email, Password = user.Password }));
                        }
                        break;
                }
            }
            _studentMainId = _studentsIds.FirstOrDefault();
            _studentMainToken = _studentsTokens.FirstOrDefault();
            _methodistMainId = _methodistsIds.FirstOrDefault();
            _methodistMainToken = _methodistsTokens.FirstOrDefault();
            _teacherMainId = _teachersIds.FirstOrDefault();
            _teacherMainToken = _teachersTokens.FirstOrDefault();
            _tutorMainId = _tutorsIds.FirstOrDefault();
            _tutorMainToken = _tutorsTokens.FirstOrDefault();
        }

        [Given(@"manager create new group")]
        public string GivenManagerCreateNewGroup(Table table)
        {
            CreateGroupRequest newGroup = table.CreateInstance<CreateGroupRequest>();
            _groupId = _groupsClient.CreateNewGroup(newGroup, _managerToken).Id;
            return newGroup.Name;
        }

        [Given(@"manager add users to group")]
        public void GivenManagerAddUsersToGroup()
        {
            foreach(var student in _studentsIds)
            {
                _groupsClient.AddUserToGroup(_groupId, student, OptionsSwagger.RoleStudent, _managerToken);
            }
            foreach(var techer in _teachersIds)
            {
                _groupsClient.AddUserToGroup(_groupId, techer, OptionsSwagger.RoleTeacher, _managerToken);
            }
            foreach(var tutor in _tutorsIds)
            {
                _groupsClient.AddUserToGroup(_groupId, tutor, OptionsSwagger.RoleTutor, _managerToken);
            }
        }

        [Given(@"methodist create new task")]
        public void GivenMethodistCreateNewTask(Table table)
        {
            CreateTaskByMethodistRequest newTask = table.CreateInstance<CreateTaskByMethodistRequest>();
            _taskId = _tasksClient.AddTaskByMethodist(newTask, _methodistMainToken).Id;
        }

        [Given(@"methodist update task")]
        public void GivenMethodistUpdateTask(Table table)
        {
            UpdateTaskRequest newTask = table.CreateInstance<UpdateTaskRequest>();
            TaskResponse task = _tasksClient.UpdateTask(newTask, _taskId, _methodistMainToken);
            _expectedTask = task;
        }

        [When(@"teacher see task by groupId")]
        public void WhenTeacherSeeTask()
        {
            List<TaskResponse> actualTasks = _tasksClient.GetTasksByGroupId(_groupId, _teacherMainToken);
            Assert.Contains(_expectedTask, actualTasks);
        }

        [When(@"teacher sees task by id")]
        public void WhenTeacherSeesTaskById()
        {
            TaskResponse actualTask = _tasksClient.GetTaskById(_taskId, _teacherMainToken);
            Assert.Equal(_expectedTask, actualTask);
        }

        [When(@"teacher post task")]
        public void WhenTeacherPostTask(Table table)
        {
            AddHomeworkRequest newHomework = table.CreateInstance<AddHomeworkRequest>();
            int homeworkId = _homeworksClient.AddHomework(newHomework, _groupId, _taskId, _teacherMainToken).Id;
            _expectedHomework = new GetHomeworkByGroupIdResponse()
            {
                TaskInHW = new TaskResponse()
                {
                    Id = _expectedTask.Id,
                    Name = _expectedTask.Name,
                    Description = _expectedTask.Description,
                    Links = _expectedTask.Links,
                    IsRequired = _expectedTask.IsRequired,
                    IsDeleted = _expectedTask.IsDeleted
                },
                StartDate = newHomework.StartDate,
                EndDate = newHomework.EndDate,
                Id = homeworkId
            };
        }

        [Then(@"student should sees task")]
        public void ThenStudentShouldSeesTask()
        {
            List<GetHomeworkByGroupIdResponse> actualHomeworks = _homeworksClient.
                GetAllHomeworksByGroupId(_groupId, _studentMainToken);
            Assert.Contains(_expectedHomework, actualHomeworks);
        }
    }
}
