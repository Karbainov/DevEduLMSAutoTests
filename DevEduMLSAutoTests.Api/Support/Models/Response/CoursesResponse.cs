namespace DevEduMLSAutoTests.Api.Support.Models.Response
{
    public class CoursesResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("topics")]
        public List<TopicsResponse> Topics { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is CoursesResponse))
            {
                return false;
            }
            List<TopicsResponse> topics = ((CoursesResponse)obj).Topics;
            if (topics.Count != this.Topics.Count)
            {
                return false;
            }
            for (int i = 0; i < topics.Count; i++)
            {
                if (!topics[i].Equals(this.Topics[i]))
                {
                    return false;
                }
            }

            return obj is CoursesResponse model &&
                Id == model.Id &&
                Name == model.Name &&
                IsDeleted == model.IsDeleted &&
                Description == model.Description;
        }
    }
}
