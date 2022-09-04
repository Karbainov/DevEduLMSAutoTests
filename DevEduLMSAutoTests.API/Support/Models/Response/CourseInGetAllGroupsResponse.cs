namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class CourseInGetAllGroupsResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CourseInGetAllGroupsResponse response &&
                   Id == response.Id &&
                   Name == response.Name &&
                   IsDeleted == response.IsDeleted;
        }
    }
}
