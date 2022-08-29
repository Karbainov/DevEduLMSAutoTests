namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class UpdateTaskRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("links")]
        public string Links { get; set; }
        
        [JsonPropertyName("lastName")]
        public string IsRequired { get; set; }
    }
}