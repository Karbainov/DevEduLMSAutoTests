namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class AddTopicResponse
    {
        [JsonPropertyName("id")]
        public int IdTopic { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }
    }
}
