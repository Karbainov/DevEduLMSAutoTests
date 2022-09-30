namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class CreateNewTaskResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("links")]
        public string Links { get; set; }

        [JsonPropertyName("isRequired")]
        public bool IsRequired { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CreateNewTaskResponse response &&
                   Id == response.Id &&
                   Name == response.Name &&
                   Description == response.Description &&
                   Links == response.Links &&
                   IsRequired == response.IsRequired &&
                   IsDeleted == response.IsDeleted;
        }
    }
}