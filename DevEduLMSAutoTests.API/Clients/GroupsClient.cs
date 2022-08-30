﻿namespace DevEduLMSAutoTests.API.Clients
{
    public class GroupsClient
    {
        public GetAllGroupsResponse CreateNewGroup(CreateGroupRequest newGroup, string managerToken, HttpStatusCode expectedCode)
        {
            string json = JsonSerializer.Serialize(newGroup);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", managerToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(Urls.Groups),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);
            GetAllGroupsResponse response = JsonSerializer.Deserialize<GetAllGroupsResponse>
                (responseMessage.Content.ReadAsStringAsync().Result)!;
            return response;
        }

        public void AddUserToGroup(int groupId, int userId, string role, string managerToken, HttpStatusCode expectedCode)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", managerToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"Urls.Groups/{groupId}/user/{userId}/role/{role}"),
            };
            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);
        }
    }
}
