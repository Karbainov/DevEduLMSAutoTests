namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class CoursesWithoutTopicsResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CoursesResponse model &&
                Id == model.Id &&
                Name == model.Name &&
                IsDeleted == model.IsDeleted &&
                Description == model.Description;
        }
    }
}