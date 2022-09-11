using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class AddTopicToCourseResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("position")]
        public int Position { get; set; }
        [JsonPropertyName("topics")]
        public AddTopicResponse Topics { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is AddTopicToCourseResponse))
            {
                return false;
            }
            AddTopicResponse topics = ((AddTopicToCourseResponse)obj).Topics;
            return obj is AddTopicToCourseResponse response &&
                   Id == response.Id &&
                   Position == response.Position &&
                   IsDeleted == response.IsDeleted;
        }
    }
}
