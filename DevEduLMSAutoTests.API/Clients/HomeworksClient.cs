using DevEduLMSAutoTests.API.Support;
using DevEduLMSAutoTests.API.Support.Models.Request;
using DevEduLMSAutoTests.API.Support.Models.Response;
using NUnit.Framework;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace DevEduLMSAutoTests.API.Clients
{
    public class HomeworksClient
    {
        public AddHomeworkByTeacherResponse AddHomework(AddHomeworkByTeacherRequest model, string token, HttpStatusCode expected)
        {
            string json = JsonSerializer.Serialize(model);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{Urls.Homeworks}/group/{model.GroupId}/task/{model.TaskId}"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
            AddHomeworkByTeacherResponse content = JsonSerializer.Deserialize<AddHomeworkByTeacherResponse>(response.Content.ReadAsStringAsync().Result);
            return content;
        }
    }
}
