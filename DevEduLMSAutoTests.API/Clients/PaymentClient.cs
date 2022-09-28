namespace DevEduLMSAutoTests.API.Clients
{
    public class PaymentClient
    {
        public AddPaymentToUserResponse AddPaymentByManager(AddPaymentToUserRequest newPayment, string managerToken)
        {
            string json = JsonSerializer.Serialize(newPayment);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", managerToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(UrlsSwagger.Payments),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            AddPaymentToUserResponse responsePayment = JsonSerializer.Deserialize<AddPaymentToUserResponse>
                (response.Content.ReadAsStringAsync().Result)!;
            return responsePayment;
        }

        public List<AddPaymentToUserResponse> GetPaymentsByUserId(int userId, string managerToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", managerToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{UrlsSwagger.Payments}/user/{userId}")
            };
            HttpResponseMessage response = client.Send(message);
            List<AddPaymentToUserResponse> responsePayment = JsonSerializer.Deserialize<List<AddPaymentToUserResponse>>
                (response.Content.ReadAsStringAsync().Result)!;
            return responsePayment;
        }

        public AddPaymentToUserResponse UpdatePayment(UpdatePaymentRequest updatePayment, int paymentId, string tokenManager)
        {
            string json = JsonSerializer.Serialize(updatePayment);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenManager);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new System.Uri($"{UrlsSwagger.Payments}/{paymentId}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            AddPaymentToUserResponse responseTopic = JsonSerializer.Deserialize<AddPaymentToUserResponse>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseTopic;
        }

        public void DeletePaymentById(int id, string token, HttpStatusCode expectedCode)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new System.Uri($"{UrlsSwagger.Payments}/{id}"),
            };
            HttpResponseMessage httpResponsec = client.Send(message);
            HttpStatusCode actualCode = httpResponsec.StatusCode;
            Assert.Equal(expectedCode, actualCode);
        }
    }
}