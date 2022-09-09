namespace DevEduLMSAutoTests.API.StepDefinitions
{
    [Binding]
    public class ManagerCreatesAGroupAddsUsersStepDefinitions
    {
        private List<string> _usersToken;
        private string _managerToken;
        private List<RegisterResponse> _students;
        private List<RegisterResponse> _teachers;
        private List<RegisterResponse> _tutors;
        private int _groupId;
        private AuthenticationClient _authenticationClient;
        private UsersClient _usersClient;
        private GroupsClient _groupsClient;
        private GroupMappers _groupMappers;

        ManagerCreatesAGroupAddsUsersStepDefinitions()
        {
            _usersToken = new List<string>();
            _students = new List<RegisterResponse>();
            _teachers = new List<RegisterResponse>();
            _tutors = new List<RegisterResponse>();
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
                switch (registerUser.Role)
                {
                    case OptionsSwagger.RoleStudent:
                        {
                            var student = _authenticationClient.RegisterUser(registerUser.CreateRegisterRequest(registerUser));
                            _students.Add(student);
                        }
                        break;
                    case OptionsSwagger.RoleTeacher:
                        {
                            var teacher = _authenticationClient.RegisterUser(registerUser.CreateRegisterRequest(registerUser));
                            _teachers.Add(teacher);
                        }
                        break;
                    case OptionsSwagger.RoleTutor:
                        {
                            var tutor = _authenticationClient.RegisterUser(registerUser.CreateRegisterRequest(registerUser));
                            _tutors.Add(tutor);
                        }
                        break;
                }
            }
        }

        [Given(@"authorize manager in service")]
        public void GivenAuthorizeManagerInService(Table table)
        {
            SwaggerSignInRequest managerSignInRequest = table.CreateInstance<SwaggerSignInRequest>();
            _managerToken = _authenticationClient.AuthorizeUser(managerSignInRequest);
        }

        [Given(@"manager add roles to users in service")]
        public void GivenManagerAddRolesToUsersInService()
        {
            foreach(var teacher in _teachers)
            {
                _usersClient.AddNewRoleToUser(teacher.Id, OptionsSwagger.RoleTeacher, _managerToken);
            }
            foreach (var tutor in _tutors)
            {
                _usersClient.AddNewRoleToUser(tutor.Id, OptionsSwagger.RoleTutor, _managerToken);
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
            foreach(var teacher in _teachers)
            {
                _groupsClient.AddUserToGroup(_groupId, teacher.Id, OptionsSwagger.RoleTeacher, _managerToken);
            }
            foreach (var tutor in _tutors)
            {
                _groupsClient.AddUserToGroup(_groupId, tutor.Id, OptionsSwagger.RoleTutor, _managerToken);
            }
            foreach (var student in _students)
            {
                _groupsClient.AddUserToGroup(_groupId, student.Id, OptionsSwagger.RoleStudent, _managerToken);
            }
        }

        [Then(@"authorize users in service")]
        public void ThenAuthorizeUsersInService(Table table)
        {
            List<SwaggerSignInRequest> signInRequests = table.CreateSet<SwaggerSignInRequest>().ToList();
            foreach (var signInUser in signInRequests)
            {
                var userToken = _authenticationClient.AuthorizeUser(signInUser);
                _usersToken.Add(userToken);
            }
        }

        [Then(@"check the user's group in service")]
        public void ThenCheckTheUsersGroupInService()
        {
            GetGroupByIdResponse actualGroup = _groupsClient.GetGroupById(_groupId, _managerToken);
            GetAllGroupsResponse group = _groupMappers.MappGetGroupByIdResponseToGetAllGroupsResponse(actualGroup);
            foreach (var userToken in _usersToken)
            {
                RegisterResponse user = _usersClient.GetUserInfoByToken(userToken);
                Assert.Equal(group, user.Groups.Find(i => i.Id == group.Id));
            }
        }
    }
}
