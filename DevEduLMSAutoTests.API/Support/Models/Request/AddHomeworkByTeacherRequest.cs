using System.Text.Json.Serialization;

namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class AddHomeworkByTeacherRequest
    {
        [JsonPropertyName("groupId")]
        public int GroupId { get; set; }
        
        [JsonPropertyName("taskId")]
        public int TaskId { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }
    }
}
