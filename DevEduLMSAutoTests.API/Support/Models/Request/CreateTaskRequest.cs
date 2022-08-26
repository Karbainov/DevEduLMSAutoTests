namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class CreateTaskRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("links")]
        public string Links { get; set; }

        [JsonPropertyName("isRequired")]
        public bool IsRequired { get; set; }

        [JsonPropertyName("courseIds")]
        public int[] courseIds { get; set; }
    }
}
