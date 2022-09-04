namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class AddHomeworkRequest
    {
        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }
    }
}
