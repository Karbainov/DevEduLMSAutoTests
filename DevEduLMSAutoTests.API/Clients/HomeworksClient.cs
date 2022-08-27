﻿namespace DevEduLMSAutoTests.API.Clients
{
    public class HomeworksClient
    {
        public AddHomeworkResponse AddHomework(AddHomeworkRequest newHomework, int groupId, int taskId, string token)
        {
            string json = JsonSerializer.Serialize(newHomework);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"{Urls.Homeworks}/group/{groupId}/task/{taskId}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage responseMessage = client.Send(message);
            AddHomeworkResponse response = JsonSerializer.Deserialize<AddHomeworkResponse>
                (responseMessage.Content.ReadAsStringAsync().Result)!;
            return response;
        }

        public List<GetHomeworkByGroupIdResponse> GetAllHomeworksByGroupId(int groupId, string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{Urls.Homeworks}/by-group/{groupId}")
            };
            HttpResponseMessage responseMessage = client.Send(message);
            List<GetHomeworkByGroupIdResponse> response = JsonSerializer.Deserialize<List<GetHomeworkByGroupIdResponse>>
                (responseMessage.Content.ReadAsStringAsync().Result)!;
            return response;
        }
    }
}