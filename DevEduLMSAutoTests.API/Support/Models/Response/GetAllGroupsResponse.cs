
namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class GetAllGroupsResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("course")]
        public CourseInGetAllGroupsResponse Course { get; set; }

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
    }
}
