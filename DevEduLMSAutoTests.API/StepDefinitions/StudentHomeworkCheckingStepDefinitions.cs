using DevEduLMSAutoTests.API.Clients;
using DevEduLMSAutoTests.API.Support.Models.Request;
using NUnit.Framework;
using System.Net;
using TechTalk.SpecFlow.Assist;

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
        private List<int> _userIds;
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
            _userIds = new List<int>();
        }

        [Given(@"Register two users")]
        public void GivenRegisterTwoUsers(Table table)
        {
            List<RegistrationRequest> usersRegistartion = table.CreateSet<RegistrationRequest>().ToList();
            foreach(var user in usersRegistartion)
            {
                int id = _authenticationClient.RegisterUser(user, HttpStatusCode.Created).Id;
                _userIds.Add(id);
            };
        }
        [Given(@"Authorize as manager")]
        public void GivenAuthorizeAsManager(Table table)
        {
            AuthorizationRequest authManager = table.CreateInstance<AuthorizationRequest>();
            _managerToken = _authenticationClient.Authorize(authManager, HttpStatusCode.OK);
        }
        [Given(@"Give teacher role to first user")]
        public void GivenGiveTeacherRoleToFirstUser()
        {
            AddRoleToUserRequest model = new AddRoleToUserRequest()
            {
                UserId = _userIds[0],
                Role = "Teacher"
            };
            _usersClient.AddRoleToUser(model, _managerToken, HttpStatusCode.NoContent);
        }
        [Given(@"Manager create new group")]
        public void GivenManagerCreateNewGroup(Table table)
        {
            AddGroupRequest group = table.CreateInstance<AddGroupRequest>();
            _groupId = _groupsClient.AddNewGroup(group, _managerToken, HttpStatusCode.Created).Id;
        }
        [Given(@"Manager add student to group")]
        public void GivenManagerAddStudentToGroup()
        {
            AddUserToGroupRequest model = new AddUserToGroupRequest()
            {
                GroupId = _groupId,
                RoleId = "Student",
                UserId = _userIds[1],
            };
            _groupsClient.AddUserToGroup(model, _managerToken, HttpStatusCode.NoContent);
        }
        [Given(@"Manager add teacher to group")]
        public void GivenManagerAddTeacherToGroup()
        {
            AddUserToGroupRequest model = new AddUserToGroupRequest()
            {
                GroupId = _groupId,
                RoleId = "Teacher",
                UserId = _userIds[0]
            };
            _groupsClient.AddUserToGroup(model, _managerToken, HttpStatusCode.NoContent);
        }
        [Given(@"Authorize as teacher")]
        public void GivenAuthorizeAsTeacher(Table table)
        {
            AuthorizationRequest authManager = table.CreateInstance<AuthorizationRequest>();
            _teacherToken = _authenticationClient.Authorize(authManager, HttpStatusCode.OK);
        }
        [Given(@"Teacher create new task")]
        public void GivenTeacherCreateNewTask()
        {
            AddTasksByTeacherRequest model = new AddTasksByTeacherRequest()
            {
                Name = "Apple",
                Description = "Lemon",
                GroupId = _groupId,
                Links = "string",
                IsRequired = true,
            };
            _taskId = _tasksClient.CreateTask(model, _teacherToken, HttpStatusCode.Created).Id;
        }
        [Given(@"Add new homework")]
        public void GivenAddNewHomework()
        {
            AddHomeworkByTeacherRequest model = new AddHomeworkByTeacherRequest()
            {
                TaskId = _taskId,
                GroupId = _groupId,
                StartDate = "15.09.2022",
                EndDate = "28.09.2022"
            };
            _homeworkId = _homeworksClient.AddHomework(model, _teacherToken, HttpStatusCode.Created).Id;
        }
        [Given(@"Authorize as student")]
        public void GivenAuthorizeAsStudent(Table table)
        {
            AuthorizationRequest authStudent = table.CreateInstance<AuthorizationRequest>();
            _studentToken = _authenticationClient.Authorize(authStudent, HttpStatusCode.OK);
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
            _studentHomeworksClient.AddHomework(model, _studentToken, HttpStatusCode.Created);
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
