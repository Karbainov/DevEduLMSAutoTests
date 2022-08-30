using System;
using TechTalk.SpecFlow;
using DevEduLMSAutoTests.API.Support.Models.Request;
using DevEduLMSAutoTests.API.Clients;

namespace DevEduLMSAutoTests.API.StepDefinitions
{
    [Binding]
    public class TasksStepDefinitions
    {
        private string _studentToken;
        private string _adminToken;
        private string _methodistToken;
        private string _teacherToken;
        private int _studentId;
        private int _methodistId;
        private int _teacherId;
        private int _groupId;
        private int _taskId;
        private AuthenticationClient _authenticationClient;
        private UsersClient _usersClient;
        private GroupsClient _groupsClient;
        private TasksClient _tasksClient;
        private HomeworksClient _homeworksClient;
        private TaskResponse _expectedTask;
        private GetHomeworkByGroupIdResponse _expectedHomework;

        [Given(@"register new users")]
        public void GivenRegisterNewUsers(Table table)
        {
            List<RegisterRequest> registerRequests = table.CreateSet<RegisterRequest>().ToList();
            RegisterRequest studentRegisterRequest = registerRequests[0];
            RegisterRequest methodistRegisterRequest = registerRequests[1];
            RegisterRequest teacherRegisterRequest = registerRequests[2];
            _authenticationClient = new AuthenticationClient();
            _studentId = _authenticationClient.RegisterUser(studentRegisterRequest).Id;
            _methodistId = _authenticationClient.RegisterUser(methodistRegisterRequest).Id;
            _teacherId = _authenticationClient.RegisterUser(teacherRegisterRequest).Id;

        }

        [Given(@"authorize admin")]
        public void GivenAuthorizeAdmin()
        {
            SignInRequest adminSignInRequest = new SignInRequest()
            {
                Email = Options.AdminsEmail,
                Password = Options.AdminsPassword,
            };
            _adminToken = _authenticationClient.AuthorizeUser(adminSignInRequest);
        }

        [Given(@"authorize users")]
        public void GivenAuthorizeUsers(Table table)
        {
            List<SignInRequest> signInRequests = table.CreateSet<SignInRequest>().ToList();
            SignInRequest studentSignInRequest = signInRequests[0];
            SignInRequest methodistSignInRequest = signInRequests[1];
            SignInRequest teacherSignInRequest = signInRequests[2];
            _studentToken = _authenticationClient.AuthorizeUser(studentSignInRequest);
            _methodistToken = _authenticationClient.AuthorizeUser(methodistSignInRequest);
            _teacherToken = _authenticationClient.AuthorizeUser(teacherSignInRequest);
        }

        [Given(@"manager add roles to users")]
        public void GivenManagerAddRolesToUsers()
        {
            _usersClient = new UsersClient();
            _usersClient.AddNewRoleToUser(_methodistId, Options.RoleMethodist, _adminToken, HttpStatusCode.NoContent);
            _usersClient.AddNewRoleToUser(_teacherId, Options.RoleTeacher, _adminToken, HttpStatusCode.NoContent);
        }

        [Given(@"manager create new group")]
        public void GivenManagerCreateNewGroup(Table table)
        {
            _groupsClient = new GroupsClient();
            CreateGroupRequest newGroup = table.CreateInstance<CreateGroupRequest>();
            _groupId = _groupsClient.CreateNewGroup(newGroup, _adminToken).Id;
        }

        [Given(@"manager add users to group")]
        public void GivenManagerAddUsersToGroup()
        {
            _groupsClient = new GroupsClient();
            _groupsClient.AddUserToGroup(_groupId, _teacherId, Options.RoleTeacher, _adminToken);
            _groupsClient.AddUserToGroup(_groupId, _studentId, Options.RoleStudent, _adminToken);
        }

        [Given(@"methodist create new task")]
        public void GivenMethodistCreateNewTask(Table table)
        {
            CreateTaskByMethodistRequest newTask = table.CreateInstance<CreateTaskByMethodistRequest>();
            _tasksClient = new TasksClient();
            _taskId = _tasksClient.AddTaskByMethodist(newTask, _methodistToken).Id;
        }

        [Given(@"methodist update task")]
        public void GivenMethodistUpdateTask(Table table)
        {
            UpdateTaskRequest newTask = table.CreateInstance<UpdateTaskRequest>();
            _tasksClient = new TasksClient();
            TaskResponse task = _tasksClient.UpdateTask(newTask, _taskId, _methodistToken, HttpStatusCode.OK);
            _expectedTask = task;
        }

        [When(@"teacher see task")]
        public void WhenTeacherSeeTask()
        {
            _tasksClient = new TasksClient();
            List<TaskResponse> actualTasks = _tasksClient.GetTasksByGroupId(_groupId, _teacherToken);
            CollectionAssert.Contains(actualTasks, _expectedTask);
        }

        [When(@"teacher sees task by id")]
        public void WhenTeacherSeesTaskById()
        {
            _tasksClient = new TasksClient();
            TaskResponse actualTask = _tasksClient.GetTaskById(_taskId, _teacherToken);
            Assert.AreEqual(_expectedTask, actualTask);
        }

        [When(@"teacher post task")]
        public void WhenTeacherPostTask(Table table)
        {
            AddHomeworkRequest newHomework = table.CreateInstance<AddHomeworkRequest>();
            _homeworksClient = new HomeworksClient();
            int homeworkId = _homeworksClient.AddHomework(newHomework, _groupId, _taskId, _teacherToken).Id;
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
            _homeworksClient = new HomeworksClient();
            List<GetHomeworkByGroupIdResponse> actualHomeworks= _homeworksClient.GetAllHomeworksByGroupId(_groupId, _studentToken);

            CollectionAssert.Contains(actualHomeworks, _expectedHomework);
        }
    }
}
