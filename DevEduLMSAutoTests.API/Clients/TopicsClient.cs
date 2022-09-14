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
                RequestUri = new System.Uri(UrlsSwagger.Topics),
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
                RequestUri = new System.Uri($"{UrlsSwagger.Courses}/{courseId}/topic/{topicId}"),
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
                RequestUri = new System.Uri($"{UrlsSwagger.Courses}/{courseId}/simple")
            };
            HttpResponseMessage response = client.Send(message);
            AddCourseResponse responseCourse = JsonSerializer.Deserialize<AddCourseResponse>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseCourse;
        }

        public UpdateTopicResponse UpdateTopic(UpdateTopicRequest updateTopic, int topicId, string tokenMethodist)
        {
            string json = JsonSerializer.Serialize(updateTopic);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenMethodist);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new System.Uri($"{UrlsSwagger.Topics}/{topicId}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            UpdateTopicResponse responseTopic = JsonSerializer.Deserialize<UpdateTopicResponse>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseTopic;
        }

        public List<AddTopicToCourseResponse> UpdateTopicPositionInCourse(List<UpdateTopicPositionRequest> newTopic, int courseId, string methodistToken)
        {
            string json = JsonSerializer.Serialize(newTopic);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", methodistToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new System.Uri($"{UrlsSwagger.Courses}/{courseId}/program"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            List<AddTopicToCourseResponse> responseTopic = JsonSerializer.Deserialize<List<AddTopicToCourseResponse>>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseTopic;
        }

        public UpdateTopicResponse GetTopicById(int topicId, string methodistToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", methodistToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{UrlsSwagger.Topics}/{topicId}")
            };
            HttpResponseMessage response = client.Send(message);
            UpdateTopicResponse responseTopic = JsonSerializer.Deserialize<UpdateTopicResponse>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseTopic;
        }

        public List<AddTopicToCourseResponse> GetAllTopicsInTheCourseById(int courseId, string token, HttpStatusCode expectedCode)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{UrlsSwagger.Courses}/{courseId}/topics")
            };
            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.Equal(expectedCode, actualCode);
            List<AddTopicToCourseResponse> response = JsonSerializer.Deserialize<List<AddTopicToCourseResponse>>
                (responseMessage.Content.ReadAsStringAsync().Result)!;
            return response;
        }
    }
}
