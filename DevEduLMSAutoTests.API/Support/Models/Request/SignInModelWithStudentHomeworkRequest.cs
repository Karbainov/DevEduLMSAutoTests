namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class SignInModelWithStudentHomeworkRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("homeworkId")]
        public int HomeworkId { get; set; }

        [JsonPropertyName("answer")]
        public string Answer { get; set; }

        public SignInRequest CreateSignInRequest(SignInModelWithStudentHomeworkRequest model)
        {
            SignInRequest signInRequest = new SignInRequest()
            {
                Email = model.Email,
                Password = model.Password
            };
            return signInRequest;
        }

        public AddHomeworkByStudentRequest CreateAddHomeworkByStudentRequest(SignInModelWithStudentHomeworkRequest model)
        {
            AddHomeworkByStudentRequest addHomeworkByStudentRequest = new AddHomeworkByStudentRequest()
            {
                HomeworkId = model.HomeworkId,
                Answer = model.Answer,
            };
            return addHomeworkByStudentRequest;
        }
    }
}
