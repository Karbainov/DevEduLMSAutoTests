using System.Text.Json.Serialization;

namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class GroupsResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("course")]
        public CoursesWithoutTopicsResponse Course { get; set; }

        [JsonPropertyName("groupStatus")]
        public string GroupStatus { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("timetable")]
        public string Timetable { get; set; }

        [JsonPropertyName("paymentPerMonth")]
        public int PaymentPerMonth { get; set; }

        [JsonPropertyName("paymentsCount")]
        public int PaymentsCount { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj== null || !(obj is GroupsResponse))
            {
                return false;
            }
            CoursesWithoutTopicsResponse course = ((GroupsResponse)obj).Course;
            if (!course.Equals(this.Course))
            {
                return false;
            }

            return obj is GroupsResponse model &&
                Id == model.Id &&
                Name == model.Name &&
                GroupStatus == model.GroupStatus &&
                StartDate == model.StartDate &&
                EndDate == model.EndDate &&
                Timetable == model.Timetable &&
                PaymentPerMonth == model.PaymentPerMonth &&
                PaymentsCount == model.PaymentsCount;
        }
    }
}
