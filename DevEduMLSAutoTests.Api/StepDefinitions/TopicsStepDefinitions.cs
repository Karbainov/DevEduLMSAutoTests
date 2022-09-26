namespace DevEduMLSAutoTests.Api.StepDefinitions
{
    [Binding]
    public class TopicsStepDefinitions
    {
        private string _studentToken;
        private string _managerToken;
        private string _methodistToken;
        private int _topicId;
        private int _methodistId;
        private int _coursesId = 2371;
        private AuthenticationClient _authenticationClient;
        private UsersClient _usersClient;
        private TopicsClient _topicsClient;
        private AddCourseResponse _actualCourse;
        private UpdateTopicResponse _actualTopic;
        private UpdateTopicResponse _expectedTopic;
        private AddTopicToCourseResponse _actualTopicPosition;
        private List<AddTopicToCourseResponse> _expectedTopicPosition;
        private AddTopicToCourseResponse _newTopic;


        [Given(@"register new user metodist")]
        public void GivenRegisterNewUsers(Table table)
        {
            List<RegisterRequest> registerRequests = table.CreateSet<RegisterRequest>().ToList();
            RegisterRequest methodistRegisterRequest = registerRequests[0];
            _authenticationClient = new AuthenticationClient();
            _methodistId = _authenticationClient.RegisterUser(methodistRegisterRequest).Id;

        }

        [Given(@"authorize user as manager")]
        public void GivenAuthorizeUsers(Table table)
        {
            List<SignInRequest> signInRequests = table.CreateSet<SignInRequest>().ToList();
            SignInRequest managerSignInRequest = signInRequests[0];
            _managerToken = _authenticationClient.AuthorizeUser(managerSignInRequest);
        }

        [Given(@"authorize user as methodist")]
        public void GivenAuthorizeUsersAsMethodist(Table table)
        {
            List<SignInRequest> signInRequests = table.CreateSet<SignInRequest>().ToList();
            SignInRequest methodistSignInRequest = signInRequests[0];
            _methodistToken = _authenticationClient.AuthorizeUser(methodistSignInRequest);
        }

        [Given(@"manager add role metodist to user")]
        public void GivenManagerAddRolesToUsers()
        {
            _usersClient = new UsersClient();
            _usersClient.AddNewRoleToUser(_methodistId, Options.RoleMethodist, _managerToken, HttpStatusCode.NoContent);
        }

        [Given(@"methodist create a topic")]
        public void GivenMethodistCreateNewTopic(Table table)
        {
            AddTopicRequest newTopic = table.CreateInstance<AddTopicRequest>();
            _topicsClient = new TopicsClient();
            _topicId = _topicsClient.AddTopicsByMethodist(newTopic, _methodistToken).IdTopic;
        }

        [Given(@"methodist add topic to course")]
        public void GivenAddTopicToCourse(Table table)
        {
            AddTopicToCourseRequest newTopic = table.CreateInstance<AddTopicToCourseRequest>();
            _topicsClient = new TopicsClient();
            _newTopic = _topicsClient.AddTopicToCourse(newTopic, _coursesId, _topicId, _methodistToken);
        }

        [Given(@"methodist can see the list of all topics in course with this topic")]
        public void GivenGetTopicsInCourseToCheckIfTopicContainsInTheCourse()
        {
            _topicsClient = new TopicsClient();
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            List<AddTopicToCourseResponse> listOfTopics = _topicsClient.GetAllTopicsInTheCourseById(_coursesId, _methodistToken, expectedCode);
            Assert.Contains(_newTopic, listOfTopics);
        }

        [Given(@"methodist update topic")]
        public void GivenUpdateTopics(Table table)
        {
            UpdateTopicRequest newTopic = table.CreateInstance<UpdateTopicRequest>();
            _topicsClient = new TopicsClient();
            _expectedTopic = _topicsClient.UpdateTopic(newTopic, _topicId, _methodistToken);
        }

        [Given(@"methodist can see updated topic")]
        public void GivenGetTopicById()
        {
            _topicsClient = new TopicsClient();
            _actualTopic = _topicsClient.GetTopicById(_topicId, _methodistToken);

            Assert.Equal(_expectedTopic, _actualTopic);
        }

        [Given(@"methodist change order of topics")]
        public void GivenAddNewPositionToTopic(Table table)
        {

            UpdateTopicPositionRequest newTopic = new UpdateTopicPositionRequest()
            {
                Position = table.CreateInstance<UpdateTopicPositionRequest>().Position,
                topicId = _topicId
            };
            List<UpdateTopicPositionRequest> inputTopics = new List<UpdateTopicPositionRequest>();
            inputTopics.Add(newTopic);
            _topicsClient = new TopicsClient();
            _expectedTopicPosition = _topicsClient.UpdateTopicPositionInCourse(inputTopics, _coursesId, _methodistToken);
        }

        [Given(@"methodist can see changed order")]
        public void GivenGetAllTopicsInCourseById()
        {
            _topicsClient = new TopicsClient();
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            List<AddTopicToCourseResponse> listOfTopics = _topicsClient.GetAllTopicsInTheCourseById(_coursesId, _methodistToken, expectedCode);
            AddTopicToCourseResponse updatedTopicPosition = _expectedTopicPosition[0];
            Assert.Contains(updatedTopicPosition, listOfTopics);
        }


    }
}
