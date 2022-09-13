namespace DevEduLMSAutoTests.API.Clients
{
    public class UsersClient
    {
        public void AddNewRoleToUser(int userId, string role, string token, HttpStatusCode expectedCode = HttpStatusCode.NoContent)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"{UrlsSwagger.Users}/{userId}/role/{role}")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actualCode = response.StatusCode;
            Assert.Equal(expectedCode, actualCode);
        }

        public RegisterResponse GetUserInfoByToken(string token, HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{UrlsSwagger.Users}/self")
            };
            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.Equal(expectedCode, actualCode);
            RegisterResponse response = JsonSerializer.Deserialize<RegisterResponse>
                (responseMessage.Content.ReadAsStringAsync().Result)!;
            return response;
        }
    }
}
