namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class TopicsResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }
        public override bool Equals(object? obj)
        {
            return obj is TopicsResponse model &&
                Id == model.Id &&
                Name == model.Name &&
                Duration == model.Duration;
        }
    }
}