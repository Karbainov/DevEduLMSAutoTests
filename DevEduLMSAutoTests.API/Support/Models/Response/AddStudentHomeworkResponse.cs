namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class AddStudentHomeworkResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("completedDate")]
        public string CompletedDate { get; set; }

        [JsonPropertyName("user")]
        public StudentHomeworkUserResponse User { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("homework")]
        public AddHomeworkByTeacherResponse Homework { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null || !(obj is AddStudentHomeworkResponse))
            {
                return false;
            }

            StudentHomeworkUserResponse user = ((AddStudentHomeworkResponse)obj).User;
            if (!user.Equals(this.User))
            {
                return false;
            }

            AddHomeworkByTeacherResponse homework = ((AddStudentHomeworkResponse)obj).Homework;
            if (!homework.Equals(this.Homework))
            {
                return false;
            }

            return obj is AddStudentHomeworkResponse model &&
                Id == model.Id &&
                Answer == model.Answer &&
                Status == model.Status &&
                CompletedDate == model.CompletedDate &&
                IsDeleted == model.IsDeleted;
        }
    }
}