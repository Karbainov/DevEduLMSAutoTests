namespace DevEduMLSAutoTests.Api.Support.Models.Request
{
    public class AddHomeworkByStudentRequest
    {
        [JsonPropertyName("homeworkId")]
        public int HomeworkId { get; set; }

        [JsonPropertyName("answer")]
        public string Answer { get; set; }
    }
}
