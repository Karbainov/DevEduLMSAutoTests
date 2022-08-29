
namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class UpdateLessonRequest
    {

        [JsonPropertyName("additionalMaterials")]
        public string AdditionalMaterials { get; set; }

        [JsonPropertyName("linkToRecord")]
        public string LinkToRecord { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("topicIds")]
        public List<int> TopicIds { get; set; }
    }
}
