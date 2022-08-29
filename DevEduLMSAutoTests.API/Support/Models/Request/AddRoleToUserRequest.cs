using System.Text.Json.Serialization;

namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class AddRoleToUserRequest
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
}
