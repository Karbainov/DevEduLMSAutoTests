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
        private string _managerToken;
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
        private CreateNewTaskResponse _expectedTask;
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

        [Given(@"authorize users")]
        public void GivenAuthorizeUsers(Table table)
        {
            List<SignInRequest> signInRequests = table.CreateSet<SignInRequest>().ToList();
            SignInRequest studentSignInRequest = signInRequests[0];
            SignInRequest methodistSignInRequest = signInRequests[1];
            SignInRequest teacherSignInRequest = signInRequests[2];
            SignInRequest managerSignInRequest = signInRequests[3];
            _studentToken = _authenticationClient.AuthorizeUser(studentSignInRequest);
            _methodistToken = _authenticationClient.AuthorizeUser(methodistSignInRequest);
            _teacherToken = _authenticationClient.AuthorizeUser(teacherSignInRequest);
            _managerToken = _authenticationClient.AuthorizeUser(managerSignInRequest);
        }

        [Given(@"manager add roles to users")]
        public void GivenManagerAddRolesToUsers()
        {
            _usersClient = new UsersClient();
            _usersClient.AddNewRoleToUser(_methodistId, Options.RoleMethodist, _managerToken, HttpStatusCode.NoContent);
            _usersClient.AddNewRoleToUser(_teacherId, Options.RoleTeacher, _managerToken, HttpStatusCode.NoContent);
        }

        [Given(@"manager create new group")]
        public void GivenManagerCreateNewGroup(Table table)
        {
            _groupsClient = new GroupsClient();
            CreateGroupRequest newGroup = table.CreateInstance<CreateGroupRequest>();
            _groupId = _groupsClient.CreateNewGroup(newGroup, _managerToken).Id;
        }

        [Given(@"manager add users to group")]
        public void GivenManagerAddUsersToGroup()
        {
            _groupsClient = new GroupsClient();
            _groupsClient.AddUserToGroup(_groupId, _teacherId, Options.RoleTeacher, _managerToken);
            _groupsClient.AddUserToGroup(_groupId, _studentId, Options.RoleStudent, _managerToken);
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
            CreateNewTaskResponse task = _tasksClient.UpdateTask(newTask, _taskId, _methodistToken);
            _expectedTask = task;

        }

        [When(@"teacher see task")]
        public void WhenTeacherSeeTask()
        {
            _tasksClient = new TasksClient();
            List<CreateNewTaskResponse> actualTasks = _tasksClient.GetTasksByGroupId(_groupId, _teacherToken);
            CollectionAssert.Contains(actualTasks, _expectedTask);
        }

        [When(@"teacher post task")]
        public void WhenTeacherPostTask(Table table)
        {
            AddHomeworkRequest newHomework = table.CreateInstance<AddHomeworkRequest>();
            _homeworksClient = new HomeworksClient();
            int homeworkId = _homeworksClient.AddHomework(newHomework, _groupId, _taskId, _teacherToken).Id;
            _expectedHomework = new GetHomeworkByGroupIdResponse()
            {
                Task = _expectedTask,
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
