namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class AddLessonRequest
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("additionalMaterials")]
        public string AdditionalMaterials { get; set; }

        [JsonPropertyName("groupId")]
        public int GroupId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("linkToRecord")]
        public string LinkToRecord { get; set; }

        [JsonPropertyName("topicIds")]
        public List<int> TopicIds { get; set; }

        [JsonPropertyName("isPublished")]
        public bool IsPublished { get; set; }
    }
}
