namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class StudentHomeworkUserResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("photo")]
        public string Photo { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is StudentHomeworkUserResponse model &&
                Id == model.Id &&
                FirstName == model.FirstName &&
                LastName == model.LastName &&
                Email == model.Email &&
                Photo == model.Photo;
        }
    }
}
