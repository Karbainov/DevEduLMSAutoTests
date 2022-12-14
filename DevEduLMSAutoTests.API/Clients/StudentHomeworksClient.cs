namespace DevEduLMSAutoTests.API.Clients
{
    public class StudentHomeworksClient
    {
        public AddStudentHomeworkResponse AddHomework(AddHomeworkByStudentRequest model, string token, HttpStatusCode expected = HttpStatusCode.Created)
        {
            string json = JsonSerializer.Serialize(model);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{UrlsSwagger.StudentHomeworks}/{model.HomeworkId}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actual = response.StatusCode;
            Assert.Equal(expected, actual);
            AddStudentHomeworkResponse content = JsonSerializer.Deserialize<AddStudentHomeworkResponse>(response.Content.ReadAsStringAsync().Result)!;
            return content;
        }

        public AddStudentHomeworkResponse DeclineHomework(int id, string token, HttpStatusCode expected = HttpStatusCode.OK)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Patch,
                RequestUri = new Uri($"{UrlsSwagger.StudentHomeworks}/{id}/decline")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actual = response.StatusCode;
            Assert.Equal(expected, actual);
            AddStudentHomeworkResponse content = JsonSerializer.Deserialize<AddStudentHomeworkResponse>(response.Content.ReadAsStringAsync().Result)!;
            return content;
        }
        public AddStudentHomeworkResponse Approve(int id, string token, HttpStatusCode expected = HttpStatusCode.OK)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Patch,
                RequestUri = new Uri($"{UrlsSwagger.StudentHomeworks}/{id}/decline")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actual = response.StatusCode;
            Assert.Equal(expected, actual);
            AddStudentHomeworkResponse content = JsonSerializer.Deserialize<AddStudentHomeworkResponse>(response.Content.ReadAsStringAsync().Result)!;
            return content;
        }

        public AddStudentHomeworkResponse UpdateHomework(AddHomeworkByStudentRequest model, string token, HttpStatusCode expected)
        {
            string json = JsonSerializer.Serialize(model);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"{UrlsSwagger.StudentHomeworks}/{model.HomeworkId}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actual = response.StatusCode;
            Assert.Equal(expected, actual);
            AddStudentHomeworkResponse content = JsonSerializer.Deserialize<AddStudentHomeworkResponse>(response.Content.ReadAsStringAsync().Result)!;
            return content;
        }

        public AddStudentHomeworkResponse GetStudenthomeworkById(int id, string token, HttpStatusCode expected)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{UrlsSwagger.StudentHomeworks}/{id}"),
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actual = response.StatusCode;
            Assert.Equal(expected, actual);
            AddStudentHomeworkResponse content = JsonSerializer.Deserialize<AddStudentHomeworkResponse>(response.Content.ReadAsStringAsync().Result)!;
            return content;
        }

        public List<GetStudentHomeworkByUserIdResponse> GetStudentHomeworkByStudentId(int id, string token, HttpStatusCode expected = HttpStatusCode.OK)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{UrlsSwagger.StudentHomeworks}/by-user/{id}"),
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actual = response.StatusCode;
            Assert.Equal(expected, actual);
            List<GetStudentHomeworkByUserIdResponse> content = JsonSerializer.Deserialize<List<GetStudentHomeworkByUserIdResponse>>(response.Content.ReadAsStringAsync().Result)!;
            return content;
        }

    }
}