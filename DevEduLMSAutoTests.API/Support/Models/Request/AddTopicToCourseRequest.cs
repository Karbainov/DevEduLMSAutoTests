namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class AddTopicToCourseRequest
    {
        [JsonPropertyName("position")]
        public int Position { get; set; }
    }
}