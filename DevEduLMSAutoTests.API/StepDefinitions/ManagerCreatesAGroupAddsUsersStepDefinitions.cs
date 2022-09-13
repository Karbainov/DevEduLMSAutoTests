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

        [Given(@"register new students in service")]
        public void GivenRegisterNewStudentsInService(Table table)
        {
            List<RegisterRequest> registerRequests = table.CreateSet<RegisterRequest>().ToList();
            foreach (var registerUser in registerRequests)
            {
                var student = _authenticationClient.RegisterUser(registerUser);
                _students.Add(student);
            }
        }

        [Given(@"register new teachers in service")]
        public void GivenRegisterNewTeachersInService(Table table)
        {
            List<RegisterRequest> registerRequests = table.CreateSet<RegisterRequest>().ToList();
            foreach (var registerUser in registerRequests)
            {
                var teacher = _authenticationClient.RegisterUser(registerUser);
                _teachers.Add(teacher);
            }
        }

        [Given(@"register new tutors in service")]
        public void GivenRegisterNewTutorsInService(Table table)
        {
            List<RegisterRequest> registerRequests = table.CreateSet<RegisterRequest>().ToList();
            foreach (var registerUser in registerRequests)
            {
                var tutor = _authenticationClient.RegisterUser(registerUser);
                _tutors.Add(tutor);
            }
        }

        [Given(@"authorize manager in servise")]
        public void GivenAuthorizeManagerInServise(Table table)
        {
            SignInRequest managerSignInRequest = table.CreateInstance<SignInRequest>();
            _managerToken = _authenticationClient.AuthorizeUser(managerSignInRequest);
        }

        [Given(@"manager add roles to users in service")]
        public void GivenManagerAddRolesToUsersInService()
        {
            foreach(var teacher in _teachers)
            {
                _usersClient.AddNewRoleToUser(teacher.Id, Options.RoleTeacher, _managerToken);
            }
            foreach (var tutor in _tutors)
            {
                _usersClient.AddNewRoleToUser(tutor.Id, Options.RoleTutor, _managerToken);
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
                _groupsClient.AddUserToGroup(_groupId, teacher.Id, Options.RoleTeacher, _managerToken);
            }
            foreach (var tutor in _tutors)
            {
                _groupsClient.AddUserToGroup(_groupId, tutor.Id, Options.RoleTutor, _managerToken);
            }
            foreach (var student in _students)
            {
                _groupsClient.AddUserToGroup(_groupId, student.Id, Options.RoleStudent, _managerToken);
            }
        }

        [Then(@"authorize users in service")]
        public void ThenAuthorizeUsersInService(Table table)
        {
            List<SignInRequest> signInRequests = table.CreateSet<SignInRequest>().ToList();
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
