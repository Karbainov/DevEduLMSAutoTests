namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class AddTopicsRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }
    }
}
