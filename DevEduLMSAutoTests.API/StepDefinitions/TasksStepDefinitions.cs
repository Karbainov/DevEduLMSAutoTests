using System;
using TechTalk.SpecFlow;
using DevEduLMSAutoTests.API.Support.Models.Request;
using DevEduLMSAutoTests.API.Clients;

namespace DevEduLMSAutoTests.API.StepDefinitions
{
    [Binding]
    public class TasksStepDefinitions
    {
        private string _studentToken;
        private string _managerToken;
        private string _methodistToken;
        private string _teacherToken;
        private int _studentId;
        private int _methodistId;
        private int _teacherId;
        private int _groupId;
        private int _taskId;
        private AuthenticationClient _authenticationClient;

        [Given(@"register new users")]
        public void GivenRegisterNewUsers(Table table)
        {
            List<RegisterRequest> registerRequests = table.CreateSet<RegisterRequest>().ToList();
            RegisterRequest studentRegisterRequest = registerRequests[0];
            RegisterRequest methodistRegisterRequest = registerRequests[1];
            RegisterRequest teacherRegisterRequest = registerRequests[2];
            _authenticationClient = new AuthenticationClient();
            _studentId = _authenticationClient.RegisterUser(studentRegisterRequest).Id;
            _methodistId = _authenticationClient.RegisterUser(methodistRegisterRequest).Id;
            _studentId = _authenticationClient.RegisterUser(teacherRegisterRequest).Id;

        }

        [Given(@"authorize users")]
        public void GivenAuthorizeUsers(Table table)
        {
            List<SignInRequest> signInRequests = table.CreateSet<SignInRequest>().ToList();
            SignInRequest studentSignInRequest = signInRequests[0];
            SignInRequest methodistSignInRequest = signInRequests[1];
            SignInRequest teacherSignInRequest = signInRequests[2];
            SignInRequest managerSignInRequest = signInRequests[3];
            _studentToken = _authenticationClient.AuthorizeUser(studentSignInRequest);
            _methodistToken = _authenticationClient.AuthorizeUser(methodistSignInRequest);
            _teacherToken = _authenticationClient.AuthorizeUser(teacherSignInRequest);
            _managerToken = _authenticationClient.AuthorizeUser(managerSignInRequest);
        }

        [Given(@"manager add roles to users")]
        public void GivenManagerAddRolesToUsers()
        {
            throw new PendingStepException();
        }

        [Given(@"manager create new group")]
        public void GivenManagerCreateNewGroup(Table table)
        {
            throw new PendingStepException();
        }

        [Given(@"manager add users to group")]
        public void GivenManagerAddUsersToGroup()
        {
            throw new PendingStepException();
        }

        [Given(@"methodist create new task")]
        public void GivenMethodistCreateNewTask(Table table)
        {
            throw new PendingStepException();
        }

        [Given(@"methodist update task")]
        public void GivenMethodistUpdateTask(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"teacher see task")]
        public void WhenTeacherSeeTask()
        {
            throw new PendingStepException();
        }

        [When(@"teacher post task")]
        public void WhenTeacherPostTask(Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"student should sees task")]
        public void ThenStudentShouldSeesTask()
        {
            throw new PendingStepException();
        }
    }
}
