using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduMLSAutoTests.Api.Support.Models.Response
{
    public class CoursesWithoutTopicsResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is CoursesResponse model &&
                Id == model.Id &&
                Name == model.Name &&
                IsDeleted == model.IsDeleted &&
                Description == model.Description;
        }
    }
}
