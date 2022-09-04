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
                RequestUri = new System.Uri($"{Urls.Users}/{userId}/role/{role}")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actualCode = response.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);
        }
    }
}
