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
        public List<AddTopicResponse> Topics { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            bool flag = true;
            if (obj == null || !(obj is AddTopicToCourseResponse))
            {
                flag = false;
            }
            else
            {
                AddTopicToCourseResponse model = (AddTopicToCourseResponse)obj;
                if (model.Id != this.Id ||
                    model.Position != this.Position ||
                    model.Topics != this.Topics ||
                    model.Id != this.Id ||
                    model.IsDeleted != this.IsDeleted
                    )
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
