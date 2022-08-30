using DevEduLMSAutoTests.API.Clients;
using DevEduLMSAutoTests.API.Support.Mappers;

namespace DevEduLMSAutoTests.API.StepDefinitions
{
    [Binding]
    public class ManagerCreatesAGroupAddsUsersStepDefinitions
    {
        private List<string> _usersToken;
        private string _managerToken;
        private List<int> _usersId;
        private List<int> _teachersId;
        private List<int> _tutorsId;
        private int _groupId;
        private AuthenticationClient _authenticationClient;
        private UsersClient _usersClient;
        private GroupsClient _groupsClient;
        private GroupMappers _groupMappers;

        ManagerCreatesAGroupAddsUsersStepDefinitions()
        {
            _usersToken = new List<string>();
            _usersId = new List<int>();
            _teachersId = new List<int>();
            _tutorsId = new List<int>();
            _authenticationClient = new AuthenticationClient();
            _usersClient = new UsersClient();
            _groupsClient = new GroupsClient();
            _groupMappers = new GroupMappers();
        }

        [Given(@"register new users in the service")]
        public void GivenRegisterNewUsersInTheService(Table table)
        {
            List<RegisterRequest> registerRequests = table.CreateSet<RegisterRequest>().ToList();
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            foreach (var registerUser in registerRequests)
            {
                var usertId = _authenticationClient.RegisterUser(registerUser, expectedRegistrationCode).Id;
                _usersId.Add(usertId);
            }
        }

        [Given(@"authorize manager in servise")]
        public void GivenAuthorizeManagerInServise(Table table)
        {
            SignInRequest managerSignInRequest = table.CreateInstance<SignInRequest>();
            HttpStatusCode expectedAuthorizationCode = HttpStatusCode.OK;
            _managerToken = _authenticationClient.AuthorizeUser(managerSignInRequest, expectedAuthorizationCode);
        }

        [Given(@"manager add roles to users in service")]
        public void GivenManagerAddRolesToUsersInService()
        {
            _teachersId.Add(_usersId[3]);
            _tutorsId.Add(_usersId[4]);
            HttpStatusCode expectedCode = HttpStatusCode.NoContent;
            foreach(var teacherId in _teachersId)
            {
                _usersClient.AddNewRoleToUser(teacherId, Options.RoleTeacher, _managerToken, expectedCode);
            }
            foreach (var tutorId in _tutorsId)
            {
                _usersClient.AddNewRoleToUser(tutorId, Options.RoleTutor, _managerToken, expectedCode);
            }
        }

        [When(@"manager create new group in service")]
        public void WhenManagerCreateNewGroupInService(Table table)
        {
            HttpStatusCode expectedRegistrationCode = HttpStatusCode.Created;
            CreateGroupRequest newGroup = table.CreateInstance<CreateGroupRequest>();
            _groupId = _groupsClient.CreateNewGroup(newGroup, _managerToken, expectedRegistrationCode).Id;
        }

        [When(@"manager add users to group in service")]
        public void WhenManagerAddUsersToGroupInService()
        {
            HttpStatusCode expectedCode = HttpStatusCode.NoContent;
            foreach(var teacherId in _teachersId)
            {
                _groupsClient.AddUserToGroup(_groupId, teacherId, Options.RoleTeacher, _managerToken, expectedCode);
                _usersId.Remove(teacherId);
            }
            foreach (var tutorId in _tutorsId)
            {
                _groupsClient.AddUserToGroup(_groupId, tutorId, Options.RoleTutor, _managerToken, expectedCode);
                _usersId.Remove(tutorId);
            }
            foreach (var id in _usersId)
            {
                _groupsClient.AddUserToGroup(_groupId, id, Options.RoleStudent, _managerToken, expectedCode);
            }
        }

        [Then(@"authorize users in service")]
        public void ThenAuthorizeUsersInService(Table table)
        {
            List<SignInRequest> signInRequests = table.CreateSet<SignInRequest>().ToList();
            HttpStatusCode expectedAuthorizationCode = HttpStatusCode.OK;
            foreach (var signInUser in signInRequests)
            {
                var userToken = _authenticationClient.AuthorizeUser(signInUser, expectedAuthorizationCode);
                _usersToken.Add(userToken);
            }
        }

        [Then(@"check the user's group in service")]
        public void ThenCheckTheUsersGroupInService()
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            GetGroupByIdResponse actualGroup = _groupsClient.GetGroupById(_groupId, _managerToken, expectedCode);
            GetAllGroupsResponse group = _groupMappers.MappGetGroupByIdResponseToGetAllGroupsResponse(actualGroup);
            foreach (var userToken in _usersToken)
            {
                RegisterResponse user = _usersClient.GetUserInfoByToken(userToken, expectedCode);
                Assert.AreEqual(group, user.Groups.Find(i => i.Id == group.Id));
            }
        }
    }
}
