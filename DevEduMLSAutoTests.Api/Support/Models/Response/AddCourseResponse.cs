using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduMLSAutoTests.Api.Support.Models.Response
{
    public class AddCourseResponse
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("topics")]
        public List<AddTopicResponse> Topics { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is AddCourseResponse))
            {
                return false;
            }
            List<AddTopicResponse> topics = ((AddCourseResponse)obj).Topics;
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
            return obj is AddCourseResponse response &&
                   Description == response.Description &&
                   Id == response.Id &&
                   Name == response.Name &&
                   IsDeleted == response.IsDeleted;
        }
    }
}
