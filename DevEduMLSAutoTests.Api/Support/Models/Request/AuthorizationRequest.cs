namespace DevEduMLSAutoTests.Api.Support.Models.Request
{
    public class AuthorizationRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
