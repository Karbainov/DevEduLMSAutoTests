using System.Text.Json.Serialization;

namespace AutoTestsSelenium.Support.Models.Request
{
    public  class AuthModel
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}

