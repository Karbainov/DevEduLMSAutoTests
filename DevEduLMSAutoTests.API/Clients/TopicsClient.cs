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

        public AddTopicToCourseResponse AddTopicToCourse(AddTopicToCourseRequest newTopic, int courseId, int topicId, string methodistToken)
        {
            string json = JsonSerializer.Serialize(newTopic);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", methodistToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"{Urls.Courses}/{courseId}/topic/{topicId}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            AddTopicToCourseResponse responseTopic = JsonSerializer.Deserialize<AddTopicToCourseResponse>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseTopic;
        }

        public AddCourseResponse GetCourseWithTopicsById(int courseId, string methodistToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", methodistToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{Urls.Courses}/{courseId}/simple")
            };
            HttpResponseMessage response = client.Send(message);
            AddCourseResponse responseCourse = JsonSerializer.Deserialize<AddCourseResponse>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseCourse;
        }
    }
}
