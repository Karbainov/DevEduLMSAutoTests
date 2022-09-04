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

        public override bool Equals(object? obj)
        {
            return obj is AddTopicResponse response &&
                   IdTopic == response.IdTopic &&
                   Name == response.Name &&
                   Duration == response.Duration;
        }
    }
}
