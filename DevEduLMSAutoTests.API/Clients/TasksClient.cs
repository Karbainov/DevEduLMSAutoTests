namespace DevEduLMSAutoTests.API.Clients
{
    public class TasksClient
    {
        public CreateNewTaskResponse AddTaskByMethodist(CreateTaskByMethodistRequest newTask, string methodistToken)
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
            CreateNewTaskResponse responseTask = JsonSerializer.Deserialize<CreateNewTaskResponse>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseTask;
        }

        public CreateNewTaskResponse UpdateTask(UpdateTaskRequest newTask, int taskId, string token)
        {
            string json = JsonSerializer.Serialize(newTask);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri($"{Urls.Tasks}/{taskId}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            CreateNewTaskResponse responseTask = JsonSerializer.Deserialize<CreateNewTaskResponse>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseTask;
        }

        public List<CreateNewTaskResponse> GetTasksByGroupId(int groupId, string teacherToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", teacherToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{Urls.Tasks}/by-group/{groupId}")
            };
            HttpResponseMessage response = client.Send(message);
            List<CreateNewTaskResponse> responseTasks = JsonSerializer.Deserialize<List<CreateNewTaskResponse>>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseTasks;
        }
    }
}