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
        public TaskResponse TaskInHW { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is GetHomeworkByGroupIdResponse response &&
                   Id == response.Id &&
                   StartDate == response.StartDate &&
                   EndDate == response.EndDate &&
                   TaskInHW.Equals(response.TaskInHW);
        }

        public override string ToString()
        {
            return $"ID {Id}, Start {StartDate}, End {EndDate}, Task: {TaskInHW}";
        }
    }
}
