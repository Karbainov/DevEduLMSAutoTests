using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class UpdateTopicPositionRequest
    {
        [JsonPropertyName("position")]
        public int Position { get; set; }
        [JsonPropertyName("topicId")]
        public int topicId { get; set; }
    }
}
