namespace DevEduMLSAutoTests.Api.Support.Models.Response
{
    public class AddHomeworkResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is AddHomeworkResponse response &&
                   Id == response.Id &&
                   StartDate == response.StartDate &&
                   EndDate == response.EndDate;
        }
    }
}
