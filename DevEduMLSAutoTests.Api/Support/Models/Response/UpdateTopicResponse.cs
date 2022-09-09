namespace DevEduMLSAutoTests.Api.Support.Models.Response
{
    public class UpdateTopicResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is UpdateTopicResponse response &&
                   Id == response.Id &&
                   Name == response.Name &&
                   Duration == response.Duration;
        }
    }
}
