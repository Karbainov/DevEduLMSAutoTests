using System.Net.Sockets;

namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class GetStudentHomeworkByUserIdResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        [JsonPropertyName("completedDate")]
        public string CompletedDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("homework")]
        public GetHomeworkByGroupIdResponse Homework { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is GetStudentHomeworkByUserIdResponse))
            {
                return false;
            }

            GetHomeworkByGroupIdResponse homework = ((GetStudentHomeworkByUserIdResponse)obj).Homework;
            if (!homework.Equals(this.Homework))
            {
                return false;
            }

            return obj is GetStudentHomeworkByUserIdResponse model &&
                Id == model.Id &&
                Answer == model.Answer &&
                CompletedDate == model.CompletedDate &&
                Status == model.Status &&
                IsDeleted == model.IsDeleted;
        }
    }
}
