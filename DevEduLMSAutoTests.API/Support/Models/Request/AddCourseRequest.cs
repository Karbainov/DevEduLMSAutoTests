namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class AddCourseRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}