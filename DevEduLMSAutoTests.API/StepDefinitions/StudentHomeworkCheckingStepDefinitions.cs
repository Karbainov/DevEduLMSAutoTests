using DevEduLMSAutoTests.API.Clients;
using DevEduLMSAutoTests.API.Support.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace DevEduLMSAutoTests.API.StepDefinitions
{
    [Binding]
    public class StudentHomeworkCheckingStepDefinitions
    {
        private AuthenticationClient _authenticationClient;
        public StudentHomeworkCheckingStepDefinitions()
        {
            _authenticationClient = new AuthenticationClient();
        }

        [Given(@"Register two users")]
        public void GivenRegisterTwoUsers(Table table)
        {
            List<RegistrationRequest> usersRegistartion = table.CreateSet<RegistrationRequest>().ToList();
            foreach(var user in usersRegistartion)
            {
                _authenticationClient.RegisterUser(user, HttpStatusCode.Created);
            }
        }
    }
}
