namespace DevEduLMSAutoTests.API.Clients
{
    public class AuthenticationClient
    {
        public RegisterResponse RegisterUser(RegisterRequest newUser, HttpStatusCode expextedCode = HttpStatusCode.Created)
        {
            string json = JsonSerializer.Serialize(newUser);
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(UrlsSwagger.Register),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.Equal(expextedCode, actualCode);
            RegisterResponse response = JsonSerializer.Deserialize<RegisterResponse>
                (responseMessage.Content.ReadAsStringAsync().Result)!;
            return response;
        }

        public string AuthorizeUser(SignInRequest request, HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            string json = JsonSerializer.Serialize(request);
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(UrlsSwagger.Sign_in),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.Equal(expectedCode, actualCode);
            string token = responseMessage.Content.ReadAsStringAsync().Result;
            return token;
        }
    }
}