namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class AddPaymentToUserRequest
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("sum")]
        public int Sum { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("isPaid")]
        public bool IsPaid { get; set; }
    }
}
