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

         public AddLessonResponse UpdateLesson(UpdateLessonRequest updateLesson, int lessonId, string tokenTeacher)
        {
            string json= JsonSerializer.Serialize(updateLesson);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenTeacher);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new System.Uri($"{Urls.Lessons}/{lessonId}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            AddLessonResponse responseLesson = JsonSerializer.Deserialize<AddLessonResponse>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseLesson;
        }

        public List <AddLessonResponse> GetAllLessonsByTeacherId( int teacherId, string teacherToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", teacherToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{Urls.Lessons}/by-teacherId/{teacherId}")
            };
            HttpResponseMessage response = client.Send(message);
            List<AddLessonResponse> responseLessons = JsonSerializer.Deserialize<List<AddLessonResponse>>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseLessons;
        }


    }
}
