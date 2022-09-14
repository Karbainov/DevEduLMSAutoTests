namespace AutoTestsSelenium.Support.Models.Request
{
    public class RegistrationRequest
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public string BirthDate { get; set; }

        public string Password { get; set; }

        public string RepeatPassword { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

    }
}
