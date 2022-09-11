using System.Text.Json.Serialization;


namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class AuthorizationRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
