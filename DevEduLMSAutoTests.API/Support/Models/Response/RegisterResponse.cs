using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class RegisterResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("photo")]
        public string Photo { get; set; }

        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; }

        [JsonPropertyName("patronymic")]
        public string Patronymic { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("registrationDate")]
        public string RegistrationDate { get; set; }

        [JsonPropertyName("birthDate")]
        public string BirthDate { get; set; }

        [JsonPropertyName("gitHubAccount")]
        public string GitHubAccount { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("exileDate")]
        public string ExileDate { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("groups")]
        public List<GetAllGroupsResponse> Groups { get; set; }
    }
}
