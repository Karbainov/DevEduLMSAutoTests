namespace DevEduLMSAutoTests.API.StepDefinitions
{
    [Binding]
    public class ManagerCreatesAGroupAddsUsersStepDefinitions
    {
        private string _managerToken;
        private List<RegistationModelWithRole> _users;
        private int _studentId;
        private int _teacherId;
        private int _tutorId;
        private int _groupId;
        private AuthenticationClient _authenticationClient;
        private UsersClient _usersClient;
        private GroupsClient _groupsClient;
        private GroupMappers _groupMappers;

        public ManagerCreatesAGroupAddsUsersStepDefinitions()
        {
            _users = new List<RegistationModelWithRole>();
            _authenticationClient = new AuthenticationClient();
            _usersClient = new UsersClient();
            _groupsClient = new GroupsClient();
            _groupMappers = new GroupMappers();
        }

        [Given(@"register new users in service")]
        public void GivenRegisterNewUsersInService(Table table)
        {
            List<RegistationModelWithRole> registerRequests = table.CreateSet<RegistationModelWithRole>().ToList();
            foreach (var registerUser in registerRequests)
            {
                var id = _authenticationClient.RegisterUser(registerUser.CreateRegisterRequest(registerUser)).Id;
                _users.Add(registerUser);
                switch (registerUser.Role)
                {
                    case OptionsSwagger.RoleStudent:
                        {
                            _studentId = id;
                        }
                        break;
                    case OptionsSwagger.RoleTeacher:
                        {
                            _teacherId = id;
                        }
                        break;
                    case OptionsSwagger.RoleTutor:
                        {
                            _tutorId = id;
                        }
                        break;
                }
            }
        }

        [Given(@"authorize manager in service")]
        public void GivenAuthorizeManagerInService()
        {
            _managerToken = _authenticationClient.AuthorizeUser(new SignInRequest { Email = Options.ManagersEmail, Password = Options.ManagersPassword});
        }

        [Given(@"manager add roles to users in service")]
        public void GivenManagerAddRolesToUsersInService()
        {
            _usersClient.AddNewRoleToUser(_teacherId, Options.RoleTeacher, _managerToken);
            _usersClient.AddNewRoleToUser(_tutorId, Options.RoleTutor, _managerToken);
        }

        [When(@"manager create new group in service")]
        public void WhenManagerCreateNewGroupInService(Table table)
        {
            CreateGroupRequest newGroup = table.CreateInstance<CreateGroupRequest>();
            _groupId = _groupsClient.CreateNewGroup(newGroup, _managerToken).Id;
        }

        [When(@"manager add users to group in service")]
        public void WhenManagerAddUsersToGroupInService()
        {
            _groupsClient.AddUserToGroup(_groupId, _teacherId, Options.RoleTeacher, _managerToken);
            _groupsClient.AddUserToGroup(_groupId, _tutorId, Options.RoleTutor, _managerToken);
            _groupsClient.AddUserToGroup(_groupId, _studentId, Options.RoleStudent, _managerToken);
        }

        [Then(@"authorize users in service and check the user's group in service")]
        public void ThenAuthorizeUsersInServiceAndCheckTheUsersGroupInService()
        {
            GetGroupByIdResponse actualGroup = _groupsClient.GetGroupById(_groupId, _managerToken);
            GetAllGroupsResponse group = _groupMappers.MappGetGroupByIdResponseToGetAllGroupsResponse(actualGroup);
            foreach (var user in _users)
            {
                var userToken = _authenticationClient.AuthorizeUser(new SignInRequest { Email = user.Email, Password = user.Password});
                RegisterResponse actualUser = _usersClient.GetUserInfoByToken(userToken);
                Assert.AreEqual(group, actualUser.Groups.Find(i => i.Id == group.Id));
            }
        }
    }
}
