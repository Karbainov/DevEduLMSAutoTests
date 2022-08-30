namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class GetHomeworkByGroupIdResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("task")]
        public CreateNewTaskResponse Task { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is GetHomeworkByGroupIdResponse response &&
                   Id == response.Id &&
                   StartDate == response.StartDate &&
                   EndDate == response.EndDate &&
                   Task == response.Task;
        }
    }
}
