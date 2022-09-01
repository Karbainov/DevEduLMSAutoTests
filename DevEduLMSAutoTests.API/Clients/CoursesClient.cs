using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduLMSAutoTests.API.Clients
{
    public class CoursesClient
    {
        public AddCourseResponse AddCoursesByMethodist(AddCourseRequest newCourse, string methodistToken)
        {
            string json = JsonSerializer.Serialize(newCourse);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", methodistToken);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(Urls.Courses),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            AddCourseResponse responseCourse = JsonSerializer.Deserialize<AddCourseResponse>
                (response.Content.ReadAsStringAsync().Result)!;
            return responseCourse;
        }

        public List<AddCourseResponse> GetAllCourses(string token, HttpStatusCode expectedCode)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{Urls.Courses}")
            };
            HttpResponseMessage responseMessage = client.Send(message);
            HttpStatusCode actualCode = responseMessage.StatusCode;
            Assert.AreEqual(expectedCode, actualCode);
            List<AddCourseResponse> response = JsonSerializer.Deserialize<List<AddCourseResponse>>
                (responseMessage.Content.ReadAsStringAsync().Result)!;
            return response;
        }
    }
}
