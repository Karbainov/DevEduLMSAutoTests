namespace DevEduMLSAutoTests.Api.Support.Models.Response
{
    public class AddHomeworkByTeacherResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is AddHomeworkByTeacherResponse model &&
                Id == model.Id &&
                StartDate == model.StartDate &&
                EndDate == model.EndDate;
        }
    }
}
