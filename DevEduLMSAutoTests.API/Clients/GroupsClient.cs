namespace DevEduLMSAutoTests.API.Clients
{
    public class GroupsClient
    {
        public CreateGroupResponse CreateNewGroup(CreateGroupRequest newGroup, string managerToken, HttpStatusCode expectedCode = HttpStatusCode.Created)
        {
            string json = JsonSerializer.Serialize(newGroup);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", managerToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(UrlsSwagger.Groups),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.Equal(expectedCode, actualCode);
            CreateGroupResponse response = JsonSerializer.Deserialize<CreateGroupResponse>
                (responseMessage.Content.ReadAsStringAsync().Result)!;
            return response;
        }

        public GetGroupByIdResponse GetGroupById(int id, string managerToken, HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", managerToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{UrlsSwagger.Groups}/{id}"),
            };
            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.Equal(expectedCode, actualCode);
            GetGroupByIdResponse response = JsonSerializer.Deserialize<GetGroupByIdResponse>
                (responseMessage.Content.ReadAsStringAsync().Result)!;
            return response;
        }

        public void AddUserToGroup(int groupId, int userId, string role, string token, HttpStatusCode expectedCode = HttpStatusCode.NoContent)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"{UrlsSwagger.Groups}/{groupId}/user/{userId}/role/{role}"),
            };
            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.Equal(expectedCode, actualCode);
        }

        public List<GetAllGroupsResponse> GetAllGroups(string token, HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{UrlsSwagger.Groups}"),
            };
            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.Equal(expectedCode, actualCode);
            List<GetAllGroupsResponse> response = JsonSerializer.Deserialize<List<GetAllGroupsResponse>>
                (responseMessage.Content.ReadAsStringAsync().Result)!;
            return response;
        }
    }
}