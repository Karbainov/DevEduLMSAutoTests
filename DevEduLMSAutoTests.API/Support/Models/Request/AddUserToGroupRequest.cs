using System.Text.Json.Serialization;

namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class AddUserToGroupRequest
    {
        [JsonPropertyName("groupId")]
        public int GroupId { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("roleId")]
        public string RoleId { get; set; }
    }
}
