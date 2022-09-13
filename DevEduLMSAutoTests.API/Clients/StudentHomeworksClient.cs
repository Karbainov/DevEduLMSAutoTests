namespace DevEduLMSAutoTests.API.Clients
{
    public class StudentHomeworksClient
    {
        public AddStudentHomeworkResponse AddHomework(AddHomeworkByStudentRequest model, string token, HttpStatusCode expected)
        {
            string json = JsonSerializer.Serialize(model);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{Urls.StudentHomeworks}/{model.HomeworkId}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actual = response.StatusCode;
            Assert.Equal(expected, actual);
            AddStudentHomeworkResponse content = JsonSerializer.Deserialize<AddStudentHomeworkResponse>(response.Content.ReadAsStringAsync().Result)!;
            return content;
        }

        public AddStudentHomeworkResponse DeclineHomework(int id, string token, HttpStatusCode expected)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Patch,
                RequestUri = new Uri($"{Urls.StudentHomeworks}/{id}/decline")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actual = response.StatusCode;
            Assert.Equal(expected, actual);
            AddStudentHomeworkResponse content = JsonSerializer.Deserialize<AddStudentHomeworkResponse>(response.Content.ReadAsStringAsync().Result)!;
            return content;
        }
        public AddStudentHomeworkResponse Approve(int id, string token, HttpStatusCode expected)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Patch,
                RequestUri = new Uri($"{Urls.StudentHomeworks}/{id}/decline")
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
                RequestUri = new Uri($"{Urls.StudentHomeworks}/{model.HomeworkId}"),
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
                RequestUri = new Uri($"{Urls.StudentHomeworks}/{id}"),
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actual = response.StatusCode;
            Assert.Equal(expected, actual);
            AddStudentHomeworkResponse content = JsonSerializer.Deserialize<AddStudentHomeworkResponse>(response.Content.ReadAsStringAsync().Result)!;
            return content;
        }

    }
}
