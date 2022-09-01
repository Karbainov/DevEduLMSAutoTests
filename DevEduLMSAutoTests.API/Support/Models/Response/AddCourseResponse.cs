using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduLMSAutoTests.API.Support.Models.Response
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
            bool flag = true;
            if (obj == null || !(obj is AddCourseResponse))
            {
                flag = false;
            }
            else
            {
                AddCourseResponse model = (AddCourseResponse)obj;
                if (model.Description != this.Description ||
                    model.Topics != this.Topics ||
                    model.Id != this.Id ||
                    model.Name != this.Name ||
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
