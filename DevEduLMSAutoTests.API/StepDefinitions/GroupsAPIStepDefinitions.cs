using DevEduLMSAutoTests.API.Clients;

namespace DevEduLMSAutoTests.API.StepDefinitions
{
    [Binding]
    public class GroupsAPIStepDefinitions
    {
        private List<RegistationModelWithRole> _newUsers;
        private int _studentId;
        private int _teacherId;
        private int _tutorId;
        private int _groupId;
        private string _managerToken;
        private AuthenticationClient _authenticationClient;
        private UsersClient _usersClient;
        private GroupsClient _groupsClient;
        private GroupMappers _groupMappers;

        public GroupsAPIStepDefinitions()
        {
            _newUsers = new List<RegistationModelWithRole>();
            _authenticationClient = new AuthenticationClient();
            _usersClient = new UsersClient();
            _groupsClient = new GroupsClient();
            _groupMappers = new GroupMappers();
        }

        [Given(@"register new users with roles in service")]
        public void GivenRegisterNewUsersWithRolesInService(Table table)
        {
            _managerToken = _authenticationClient.AuthorizeUser(new SwaggerSignInRequest() { Email = OptionsSwagger.ManagersEmail, Password = OptionsSwagger.ManagersPassword });
            _newUsers = table.CreateSet<RegistationModelWithRole>().ToList();
            foreach (var user in _newUsers)
            {
                int id = _authenticationClient.RegisterUser(user.CreateRegisterRequest(user)).Id;
                switch (user.Role)
                {
                    case OptionsSwagger.RoleTeacher:
                        {
                            _teacherId = id;
                            _usersClient.AddNewRoleToUser(id, user.Role, _managerToken);
                        }
                        break;
                    case OptionsSwagger.RoleTutor:
                        {
                            _tutorId = id;
                            _usersClient.AddNewRoleToUser(id, user.Role, _managerToken);
                        }
                        break;
                    case OptionsSwagger.RoleStudent:
                        {
                            _studentId = id;
                        }
                        break;
                    default:
                        {
                            throw new ArgumentOutOfRangeException(nameof(user.Role));
                        }
                };
            }
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
            _groupsClient.AddUserToGroup(_groupId, _teacherId, OptionsSwagger.RoleTeacher, _managerToken);
            _groupsClient.AddUserToGroup(_groupId, _tutorId, OptionsSwagger.RoleTutor, _managerToken);
            _groupsClient.AddUserToGroup(_groupId, _studentId, OptionsSwagger.RoleStudent, _managerToken);
        }

        [Then(@"authorize users in service and check group")]
        public void ThenAuthorizeUsersInServiceAndCheckGroup()
        {
            GetGroupByIdResponse actualGroup = _groupsClient.GetGroupById(_groupId, _managerToken);
            GetAllGroupsResponse group = _groupMappers.MappGetGroupByIdResponseToGetAllGroupsResponse(actualGroup);
            foreach (var user in _newUsers)
            {
                var userToken = _authenticationClient.AuthorizeUser(new SwaggerSignInRequest { Email = user.Email, Password = user.Password});
                RegisterResponse actualUser = _usersClient.GetUserInfoByToken(userToken);
                Assert.Equal(group, actualUser.Groups.Find(i => i.Id == group.Id));
            }
        }
    }
}
