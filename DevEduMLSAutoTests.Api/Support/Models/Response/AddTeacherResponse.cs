namespace DevEduMLSAutoTests.Api.Support.Models.Response
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

        public override bool Equals(object? obj)
        {
            return obj is AddTeacherResponse response &&
                   IdTeacher == response.IdTeacher &&
                   FirstName == response.FirstName &&
                   LastName == response.LastName &&
                   Email == response.Email &&
                   Photo == response.Photo;
        }
    }
}
