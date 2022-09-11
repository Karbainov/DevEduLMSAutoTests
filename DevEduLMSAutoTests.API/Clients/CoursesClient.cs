namespace DevEduLMSAutoTests.API.Clients
{
    public class CoursesClient
    {
        public HttpContent AddNewCourse(AddCourseRequest model, string token, HttpStatusCode expected)
        {
            string json = JsonSerializer.Serialize(model);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(UrlsSwagger.Courses),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actual = response.StatusCode;
            Assert.Equal(expected, actual);
            return response.Content;
        }
    }
}
