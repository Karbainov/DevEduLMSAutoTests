namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class UpdateTopicPositionRequest
    {
        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("topicId")]
        public int topicId { get; set; }
    }
}