namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class AddTasksByTeacherResponse
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

        [JsonPropertyName("groupId")]
        public int GroupId { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is AddTasksByTeacherResponse model &&
                Id == model.Id &&
                Name == model.Name &&
                Description == model.Description &&
                Links == model.Links &&
                IsDeleted == model.IsDeleted &&
                GroupId == model.GroupId &&
                IsDeleted == model.IsDeleted;
        }
    }
}