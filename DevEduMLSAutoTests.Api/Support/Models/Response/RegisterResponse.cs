namespace DevEduMLSAutoTests.Api.Support.Models.Response
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

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is RegisterResponse))
            {
                return false;
            }
            List<string> roles = ((RegisterResponse)obj).Roles;
            if (roles.Count != this.Roles.Count)
            {
                return false;
            }
            for (int i = 0; i < roles.Count; i++)
            {
                if (!roles[i].Equals(this.Roles[i]))
                {
                    return false;
                }
            }
            List<GetAllGroupsResponse> groups = ((RegisterResponse)obj).Groups;
            if (groups.Count != this.Groups.Count)
            {
                return false;
            }
            for (int i = 0; i < groups.Count; i++)
            {
                if (!groups[i].Equals(this.Groups[i]))
                {
                    return false;
                }
            }
            return obj is RegisterResponse response &&
                   Id == response.Id &&
                   FirstName == response.FirstName &&
                   LastName == response.LastName &&
                   Email == response.Email &&
                   Photo == response.Photo &&
                   Patronymic == response.Patronymic &&
                   Username == response.Username &&
                   RegistrationDate == response.RegistrationDate &&
                   BirthDate == response.BirthDate &&
                   GitHubAccount == response.GitHubAccount &&
                   PhoneNumber == response.PhoneNumber &&
                   ExileDate == response.ExileDate &&
                   City == response.City;
        }
    }
}
