namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class AddTeacherResponse
    {
        [JsonPropertyName("id")]
        public int IdTeacher { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("photo")]
        public string Photo { get; set; }
    }
}
