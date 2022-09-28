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

        public void DeleteUsersRole(int userId, string role, string token, HttpStatusCode expectedCode = HttpStatusCode.NoContent)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new System.Uri($"{UrlsSwagger.Users}/{userId}/role/{role}")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actualCode = response.StatusCode;
            Assert.Equal(expectedCode, actualCode);
        }

        public List<GetAllUsersResponse> GetAllUsers(string token, HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{UrlsSwagger.Users}")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actualCode = response.StatusCode;
            Assert.Equal(expectedCode, actualCode);
            List<GetAllUsersResponse> users = JsonSerializer.Deserialize<List<GetAllUsersResponse>>
                (response.Content.ReadAsStringAsync().Result)!;
            return users;
        }

        public async void AddPhotoForUser(string token, string filePath, HttpStatusCode expectedCode = HttpStatusCode.Created)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var requestContent = new MultipartFormDataContent();
            byte[] imageData = File.ReadAllBytes(filePath);
            var imageContent = new ByteArrayContent(imageData);
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
            requestContent.Add(imageContent);
            var response = await client.PostAsync($"{UrlsSwagger.Users}/photo", requestContent);
            var actualCode = response.StatusCode;
            string linkToPhoto = response.Content.ReadAsStringAsync().Result;
            Assert.Equal(actualCode, expectedCode);
            Assert.Contains(@"/media/userPhoto/", linkToPhoto);
        }
    }
}