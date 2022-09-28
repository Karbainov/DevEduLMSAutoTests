namespace DevEduLMSAutoTests.API.Support.Models.Response
{
    public class AddPaymentToUserResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("sum")]
        public int Sum { get; set; }

        [JsonPropertyName("user")]
        public UserShortResponse User { get; set; }

        [JsonPropertyName("isPaid")]
        public bool IsPaid { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is AddPaymentToUserResponse response &&
                   Id == response.Id &&
                   Date == response.Date &&
                   Sum == response.Sum &&
                   EqualityComparer<UserShortResponse>.Default.Equals(User, response.User) &&
                   IsPaid == response.IsPaid;
        }
    }
}