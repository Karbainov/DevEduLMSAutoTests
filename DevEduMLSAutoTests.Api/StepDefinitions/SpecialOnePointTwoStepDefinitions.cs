namespace DevEduMLSAutoTests.Api.StepDefinitions
{
    [Binding]
    public class SpecialOnePointTwoStepDefinitions
    {
        private string _managerToken;
        private string _methodistToken;
        private string _teacherToken;
        private int _methodistId;
        private int _teacherId;
        private int _groupId;
        private int _topicId;
        private int _lessonId;
        private string _adminToken;
        private AuthenticationClient _authenticationClient;
        private UsersClient _usersClient;
        private GroupsClient _groupsClient;
        private TopicsClient _topicsClient;
        private LessonsClient _lessonsClient;
        private List<AddLessonResponse> _expectedLesson;
        private AddLessonResponse _expectedLessonUp;

        [Given(@"register new user")]
        public void GivenRegisterNewUser(Table table)
        {
            List<RegisterRequest> registerRequests = table.CreateSet<RegisterRequest>().ToList();
            RegisterRequest methodistRegisterRequest = registerRequests[0];
            RegisterRequest teacherRegisterRequest = registerRequests[1];
            _authenticationClient = new AuthenticationClient();
            _methodistId = _authenticationClient.RegisterUser(methodistRegisterRequest).Id;
            _teacherId = _authenticationClient.RegisterUser(teacherRegisterRequest).Id;
        }

        [Given(@"authorize admina")]
        public void GivenAuthorizeAdmin()
        {
            SignInRequest adminSignInRequest = new SignInRequest()
            {
                Email = Options.AdminsEmail,
                Password = Options.AdminsPassword,
            };
            _adminToken = _authenticationClient.AuthorizeUser(adminSignInRequest);
        }

        [Given(@"authorize user")]
        public void GivenAuthorizeUser(Table table)
        {
            List<SignInRequest> signInRequests = table.CreateSet<SignInRequest>().ToList();
            SignInRequest methodistSignInRequest = signInRequests[0];
            SignInRequest teacherSignInRequest = signInRequests[1];
            SignInRequest managerSignInRequest = signInRequests[2];
            _methodistToken = _authenticationClient.AuthorizeUser(methodistSignInRequest);
            _teacherToken = _authenticationClient.AuthorizeUser(teacherSignInRequest);
            _managerToken = _authenticationClient.AuthorizeUser(managerSignInRequest);
        }

        [Given(@"manager add roles to user")]
        public void GivenManagerAddRolesToUser()
        {
            _usersClient = new UsersClient();
            _usersClient.AddNewRoleToUser(_methodistId, Options.RoleMethodist, _adminToken, HttpStatusCode.NoContent);
            _usersClient.AddNewRoleToUser(_teacherId, Options.RoleTeacher, _adminToken, HttpStatusCode.NoContent);
        }

        [Given(@"manager create new groups")]
        public void GivenManagerCreateNewGroups(Table table)
        {
            _groupsClient = new GroupsClient();
            CreateGroupRequest newGroup = table.CreateInstance<CreateGroupRequest>();
            _groupId = _groupsClient.CreateNewGroup(newGroup, _managerToken).Id;
        }


        [Given(@"methodist create topic")]
        public void GivenMethodistCreateTopic(Table table)
        {
            AddTopicRequest newTopic = table.CreateInstance<AddTopicRequest>();
            _topicsClient = new TopicsClient();
            _topicId = _topicsClient.AddTopicsByMethodist(newTopic, _methodistToken).IdTopic;
        }

        [Given(@"teacher create a lesson a draft")]
        public void GivenTeacherCreateALesson(Table table)
        {
            AddLessonRequest newLesson = table.CreateInstance<AddLessonRequest>();
            newLesson.TopicIds = new List<int>() { _topicId };
            _lessonsClient = new LessonsClient();
            _lessonId = _lessonsClient.AddLessonByTeacher(newLesson, _teacherToken).IdLesson;
        }

        [Given(@"admin add teacher group")]
        public void GivenAdminAddTeacherGroup()
        {
            _groupsClient = new GroupsClient();
            _groupsClient.AddUserToGroup(_groupId, _teacherId, Options.RoleTeacher, _adminToken);
        }


        [Given(@"teacher sees a draft lesson")]
        public void GivenTeacherSeesADraftLesson()
        {
            _lessonsClient = new LessonsClient();
            List<AddLessonResponse> actualLesson = _lessonsClient.GetAllLessonsUnpublishedByGroupId(_groupId, _teacherToken);
            Assert.Equal(_expectedLesson, actualLesson);
        }

        [When(@"teacher update lesson")]
        public void WhenTeacherUpdateLesson(Table table)
        {
            UpdateLessonRequest newLesson = table.CreateInstance<UpdateLessonRequest>();
            _lessonsClient = new LessonsClient();
            newLesson.TopicIds = new List<int>() { _topicId };
            AddLessonResponse lesson = _lessonsClient.UpdateLesson(newLesson, _lessonId, _teacherToken);
            _expectedLessonUp = lesson;
        }

        [Then(@"teacher can see published a lesson")]
        public void ThenTeacherPublishesALesson()
        {
            _lessonsClient = new LessonsClient();
            List<AddLessonResponse> actualLesson = _lessonsClient.GetAllLessonsGroupId(_groupId, _teacherToken);
            Assert.Equal(actualLesson, _expectedLesson);
        }
    }
}
