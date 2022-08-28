namespace DevEduLMSAutoTests.API.Clients
{
    public class TopicsClient
    {
        public AddTopicResponse AddTopicsByMethodist (AddTopicRequest newTopic, string methodistToken)
        {
            string json = JsonSerializer.Serialize(newTopic);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", methodistToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(Urls.Topics),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = client.Send(message);
            AddTopicResponse responseTopic = JsonSerializer.Deserialize<AddTopicResponse>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseTopic;
        }
    }
}
