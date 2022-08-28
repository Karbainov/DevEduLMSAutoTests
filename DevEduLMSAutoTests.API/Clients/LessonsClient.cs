namespace DevEduLMSAutoTests.API.Clients
{
    public class LessonsClient
    {
        public AddLessonResponse AddLessonByTeacher(AddLessonRequest newLesson, string tokenTeacher)
        {
            string json = JsonSerializer.Serialize(newLesson);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenTeacher);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(Urls.Lessons),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            AddLessonResponse responseLesson = JsonSerializer.Deserialize<AddLessonResponse>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseLesson;
        }

         
    
    }
}
