namespace DevEduLMSAutoTests.API.StepDefinitions
{
    [Binding]
    public class TopicsStepDefinitions
    {
        private string _studentToken;
        private string _managerToken;
        private string _methodistToken;
        private int _topicId;
        private int _methodistId;
        private int _coursesId;
        private AuthenticationClient _authenticationClient;
        private UsersClient _usersClient;
        private CoursesClient _coursesClient;
        private TopicsClient _topicsClient;
        private AddCourseResponse _actualCourse;
        private UpdateTopicResponse _actualTopic;
        private UpdateTopicResponse _expectedTopic;
        private AddTopicToCourseResponse _actualTopicPosition;
        private AddTopicToCourseResponse _expectedTopicPosition;


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

        [Given(@"methodist create a course")]
        public void GivenMethodistCreateNewCourse(Table table)
        {
            AddCourseRequest newCourse = table.CreateInstance<AddCourseRequest>();
            _coursesClient = new CoursesClient();
            _coursesId = _coursesClient.AddCoursesByMethodist(newCourse, _methodistToken).Id;
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
            _topicsClient.AddTopicToCourse(newTopic, _coursesId, _topicId, _methodistToken);
        }

        [Given(@"methodist can see the course with topic")]
        public void GivenGetCourseWithTopicByCourseId()
        {
            _topicsClient = new TopicsClient();
            _actualCourse = _topicsClient.GetCourseWithTopicsById(_coursesId, _methodistToken);
            AddTopicResponse topic = new AddTopicResponse()
            {
                IdTopic = _topicId,
                Name = "functions13",
                Duration = 12
            };
            List<AddTopicResponse> listTopics = new List<AddTopicResponse>();
            listTopics.Add(topic);
            AddCourseResponse _expectedCourse = new AddCourseResponse()
            {
                Description = "New java course",
                Topics = listTopics,
                Id = _coursesId,
                Name = "Base Java13",
                IsDeleted = false

            };
            Assert.NotNull(_expectedCourse);
            Assert.AreEqual(_expectedCourse, _actualCourse);

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

            Assert.AreEqual(_expectedTopic, _actualTopic);
        }

        [Given(@"methodist change order of topics")]
        public void GivenAddNewPositionToTopic(Table table)
        {
            UpdateTopicPositionRequest newTopic = new UpdateTopicPositionRequest()
            {
                Position = table.CreateInstance<AddTopicToCourseRequest>().Position,
                topicId = _topicId
            };
            _topicsClient = new TopicsClient();
            _expectedTopicPosition = _topicsClient.UpdateTopicPositionInCourse(newTopic, _coursesId, _methodistToken);
        }

        [Given(@"methodist can see changed order")]
        public void GivenGetAllTopicsInCourseById()
        {
            _topicsClient = new TopicsClient();
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            List<AddTopicToCourseResponse> listOfTopics = _topicsClient.GetAllTopicsInTheCourseById(_coursesId, _methodistToken, expectedCode);
            CollectionAssert.Contains(listOfTopics, _expectedTopicPosition);
        }
           

        [Given(@"list of all courses should contains the course with topic")]
        public void GivenCoursesContainsANewCourse()
        {
            _coursesClient = new CoursesClient();
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            List<AddCourseResponse> allCourses = _coursesClient.GetAllCourses(_methodistToken, expectedCode);
            CollectionAssert.Contains(allCourses, _actualCourse);
            
        }

    }
}
