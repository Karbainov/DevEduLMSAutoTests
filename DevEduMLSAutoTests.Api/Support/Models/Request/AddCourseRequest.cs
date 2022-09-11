namespace DevEduMLSAutoTests.Api.Support.Models.Request
{
    public class AddCourseRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
