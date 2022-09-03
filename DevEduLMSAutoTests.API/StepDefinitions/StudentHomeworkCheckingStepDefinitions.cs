using DevEduLMSAutoTests.API.Clients;
using DevEduLMSAutoTests.API.Support.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
        private List<int> _userIds;
        private string _managerToken;
        private string _teacherToken;
        private int _groupId;
        private int _taskId;
        public StudentHomeworkCheckingStepDefinitions()
        {
            _authenticationClient = new AuthenticationClient();
            _usersClient = new UsersClient();
            _groupsClient = new GroupsClient();
            _tasksClient = new TasksClient();
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
            _groupId = _groupsClient.AddNewGroup(group, _managerToken, HttpStatusCode.NoContent).Id;
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

    }
}
