using System.Text.Json.Serialization;

namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class AddGroupRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("courseId")]
        public int CourseId { get; set; }

        [JsonPropertyName("groupStatusId")]
        public string GroupStatusId { get; set; }

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
    }
}
