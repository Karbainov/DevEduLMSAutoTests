namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class AddUserResponse
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
        public List<GroupsResponse> Groups { get; set; }

        public override bool Equals(object? obj)
        {
            
            if(obj == null || !(obj is AddUserResponse))
            {
                return false;
            }
            List<GroupsResponse> groups = ((AddUserResponse)obj).Groups;
            if(groups.Count != this.Groups.Count)
            {
                return false;
            }
            for (int i = 0; i < groups.Count; i++)
            {
                if(!groups[i].Equals(this.Groups[i]))
                {
                    return false;
                }
            }

            return obj is AddUserResponse model &&
                Id == model.Id &&
                FirstName == model.FirstName &&
                LastName == model.LastName &&
                Email == model.Email &&
                Photo == model.Photo &&
                Roles == model.Roles &&
                Patronymic == model.Patronymic &&
                Username == model.Username &&
                RegistrationDate == model.RegistrationDate &&
                BirthDate == model.BirthDate &&
                GitHubAccount == model.GitHubAccount &&
                PhoneNumber == model.PhoneNumber &&
                ExileDate == model.ExileDate &&
                City == model.City;
        }
    }
}