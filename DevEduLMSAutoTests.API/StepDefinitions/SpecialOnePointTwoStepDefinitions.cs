using DevEduLMSAutoTests.API.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduLMSAutoTests.API.StepDefinitions
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
        private AuthenticationClient _authenticationClient;
        private UsersClient _usersClient;
        private GroupsClient _groupsClient;
        private TopicsClient _topicsClient;
        private LessonsClient _lessonsClient;
        private AddLessonResponse _expectedLesson;


       [Given(@"register new users")]
        public void GivenRegisterNewUsers(Table table)
        {
            List<RegisterRequest> registerRequests = table.CreateSet<RegisterRequest>().ToList();
            RegisterRequest methodistRegisterRequest = registerRequests[0];
            RegisterRequest teacherRegisterRequest = registerRequests[1];
            _authenticationClient = new AuthenticationClient();
            _methodistId = _authenticationClient.RegisterUser(methodistRegisterRequest).Id;
            _teacherId = _authenticationClient.RegisterUser(teacherRegisterRequest).Id;         
        }

        [Given(@"authorize users")]
        public void GivenAuthorizeUsers(Table table)
        {
            List<SignInRequest> signInRequests = table.CreateSet<SignInRequest>().ToList();
            SignInRequest methodistSignInRequest = signInRequests[0];
            SignInRequest teacherSignInRequest = signInRequests[1];
            SignInRequest managerSignInRequest = signInRequests[2];
            _methodistToken = _authenticationClient.AuthorizeUser(methodistSignInRequest);
            _teacherToken = _authenticationClient.AuthorizeUser(teacherSignInRequest);
            _managerToken = _authenticationClient.AuthorizeUser(managerSignInRequest);
        }

        [Given(@"manager add roles to users")]
        public void GivenManagerAddRolesToUsers()
        {
            _usersClient = new UsersClient();
            _usersClient.AddNewRoleToUser(_methodistId, Options.RoleMethodist, _managerToken, HttpStatusCode.NoContent);
            _usersClient.AddNewRoleToUser(_teacherId, Options.RoleTeacher, _managerToken, HttpStatusCode.NoContent);
        }

        [Given(@"manager create new group")]
        public void GivenManagerCreateNewGroup(Table table)
        {
            _groupsClient = new GroupsClient();
            CreateGroupRequest newGroup = table.CreateInstance<CreateGroupRequest>();
            _groupId = _groupsClient.CreateNewGroup(newGroup, _managerToken).Id;
        }

        [Given(@"methodist create topic")]
        public void GivenMethodistCreateTopic(Table table)
        {
            AddTopicRequest newTopic= table.CreateInstance<AddTopicRequest>();
            _topicsClient = new TopicsClient();
            _topicId = _topicsClient.AddTopicsByMethodist(newTopic, _methodistToken).IdTopic;
        }

        [Given(@"teacher create a lesson")]
        public void GiverTeacherCreateLesson(Table table)
        {
            AddLessonRequest newLesson=table.CreateInstance<AddLessonRequest>();
            _lessonsClient = new LessonsClient();
            _lessonId = _lessonsClient.AddLessonByTeacher(newLesson, _teacherToken).IdLesson;
        }


        [Given(@"teacher update lesson")]
        public void GivenTeacherUpdateLesson(Table table)
        {
            UpdateLessonRequest newLesson= table.CreateInstance<UpdateLessonRequest>();
            _lessonsClient = new LessonsClient();
            AddLessonResponse lesson = _lessonsClient.UpdateLesson(newLesson, _lessonId, _teacherToken);
            _expectedLesson = lesson;
        }

        [Then(@"teacher see lesson")]
        public void WhenTeacherGetIdLesson()
        {
            _lessonsClient = new LessonsClient();
            List <AddLessonResponse> actualLesson=_lessonsClient.GetAllLessonsByTeacherId(_teacherId, _methodistToken);
            CollectionAssert.Contains(actualLesson, _expectedLesson);
        }
    }

}
