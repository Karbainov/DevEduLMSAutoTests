namespace DevEduLMSAutoTests.API.Clients
{
    public class TasksClient
    {
        public TaskResponse AddTaskByMethodist(CreateTaskByMethodistRequest newTask, string methodistToken, HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            string json = JsonSerializer.Serialize(newTask);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", methodistToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"{Urls.Tasks}/methodist"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            TaskResponse responseTask = JsonSerializer.Deserialize<TaskResponse>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseTask;
        }

        public TaskResponse UpdateTask(UpdateTaskRequest newTask, int taskId, string token, HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            string json = JsonSerializer.Serialize(newTask);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new System.Uri($"{Urls.Tasks}/{taskId}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actualCode = response.StatusCode;
            Assert.Equal(expectedCode, actualCode);
            TaskResponse responseTask = JsonSerializer.Deserialize<TaskResponse>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseTask;
        }

        public List<TaskResponse> GetTasksByGroupId(int groupId, string teacherToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", teacherToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{Urls.Tasks}/by-group/{groupId}")
            };
            HttpResponseMessage response = client.Send(message);
            List<TaskResponse> responseTasks = JsonSerializer.Deserialize<List<TaskResponse>>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseTasks;
        }
        public TaskResponse GetTaskById(int taskId, string teacherToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", teacherToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{Urls.Tasks}/{taskId}")
            };
            HttpResponseMessage response = client.Send(message);
            TaskResponse responseTask = JsonSerializer.Deserialize<TaskResponse>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseTask;
        }
        public AddTasksByTeacherResponse CreateTask(AddTasksByTeacherRequest model, string token, HttpStatusCode expected = HttpStatusCode.Created)
        {
            string json = JsonSerializer.Serialize(model);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                RequestUri = new Uri($"{Urls.Tasks}/teacher"),
                Method = HttpMethod.Post,
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actual = response.StatusCode;
            Assert.Equal(expected, actual);
            AddTasksByTeacherResponse content = JsonSerializer.Deserialize<AddTasksByTeacherResponse>(response.Content.ReadAsStringAsync().Result)!;
            return content;
        }
    }
}