namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class AddHomeworkResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }
    }
}
