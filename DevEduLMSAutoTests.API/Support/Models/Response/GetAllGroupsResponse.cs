
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

        public override bool Equals(object? obj)
        {
            return obj is GetAllGroupsResponse response &&
                   Id == response.Id &&
                   Name == response.Name &&
                   Course == response.Course &&
                   GroupStatus == response.GroupStatus &&
                   StartDate == response.StartDate &&
                   EndDate == response.EndDate &&
                   Timetable == response.Timetable &&
                   PaymentPerMonth == response.PaymentPerMonth &&
                   PaymentsCount == response.PaymentsCount;
        }
    }
}
