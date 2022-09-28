namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class AddLessonResponse
    {
        [JsonPropertyName("id")]
        public int IdLesson { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

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
        public List<AddTopicResponse> Topics { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is AddLessonResponse response &&
                   IdLesson == response.IdLesson &&
                   Date == response.Date &&
                   Name == response.Name &&
                   AdditionalMaterials == response.AdditionalMaterials &&
                   LinkToRecord == response.LinkToRecord &&
                   Number == response.Number &&
                   //EqualityComparer<AddTeacherResponse>.Default.Equals(Teacher, response.Teacher) &&
                   //EqualityComparer<List<AddTopicResponse>>.Default.Equals(Topics, response.Topics) &&
                   Teacher.Equals(response.Teacher)&&
                   IsDeleted == response.IsDeleted;
        }
    }
}