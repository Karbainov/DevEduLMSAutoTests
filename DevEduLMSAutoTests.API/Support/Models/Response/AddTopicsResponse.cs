namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class AddTopicsResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }
    }
}
