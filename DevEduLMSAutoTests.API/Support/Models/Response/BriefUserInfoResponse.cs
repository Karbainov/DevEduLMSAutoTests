namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class BriefUserInfoResponse
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

        public override bool Equals(object? obj)
        {
            return obj is BriefUserInfoResponse response &&
                   Id == response.Id &&
                   FirstName == response.FirstName &&
                   LastName == response.LastName &&
                   Email == response.Email &&
                   Photo == response.Photo;
        }
    }
}
