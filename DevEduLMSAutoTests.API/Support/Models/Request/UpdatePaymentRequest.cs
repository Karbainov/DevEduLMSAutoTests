namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class UpdatePaymentRequest
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("sum")]
        public int Sum { get; set; }

        [JsonPropertyName("isPaid")]
        public bool IsPaid { get; set; }
    }
}