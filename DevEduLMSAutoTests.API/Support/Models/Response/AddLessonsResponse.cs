
namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class AddLessonsResponse
    {
        [JsonPropertyName("id")]
        public int IdLesson { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("additionalMaterials")]
        public string AdditionalMaterials { get; set; }

        [JsonPropertyName("linkToRecord")]
        public string LinkToRecord { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("teacher")]
        public AddTeacherResponse Teacher { get; set; }

        [JsonPropertyName("topics")]
        public List<AddTopicsResponse> Topics { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }
    }
}
