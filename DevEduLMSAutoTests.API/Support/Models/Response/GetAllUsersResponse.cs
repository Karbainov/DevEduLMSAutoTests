namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class GetAllUsersResponse
    {
        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; }

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
    }
}
