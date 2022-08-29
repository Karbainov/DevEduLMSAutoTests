namespace DevEduLMSAutoTests.API.StepDefinitions
{
    [Binding]
    public class TopicsStepDefinitions
    {
        private string _studentToken;
        private string _managerToken;
        private string _methodistToken;
        private int _methodistId;
        private AuthenticationClient _authenticationClient;
        private UsersClient _usersClient;

        [Given(@"register new user metodist")]
        public void GivenRegisterNewUsers(Table table)
        {
            List<RegisterRequest> registerRequests = table.CreateSet<RegisterRequest>().ToList();
            RegisterRequest methodistRegisterRequest = registerRequests[0];
            _authenticationClient = new AuthenticationClient();
            _methodistId = _authenticationClient.RegisterUser(methodistRegisterRequest).Id;

        }

        [Given(@"authorize user")]
        public void GivenAuthorizeUsers(Table table)
        {
            List<SignInRequest> signInRequests = table.CreateSet<SignInRequest>().ToList();
            SignInRequest managerSignInRequest = signInRequests[0];
            _managerToken = _authenticationClient.AuthorizeUser(managerSignInRequest);
        }

        [Given(@"manager add role metodist to user")]
        public void GivenManagerAddRolesToUsers()
        {
            _usersClient = new UsersClient();
            _usersClient.AddNewRoleToUser(_methodistId, Options.RoleMethodist, _managerToken, HttpStatusCode.NoContent);
        }

    }
}
