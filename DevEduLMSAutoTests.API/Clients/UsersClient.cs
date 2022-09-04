using DevEduLMSAutoTests.API.Support;
using DevEduLMSAutoTests.API.Support.Models.Request;
using NUnit.Framework;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace DevEduLMSAutoTests.API.Clients
{
    public class UsersClient
    {
        public void AddRoleToUser(int id, string role, string token, HttpStatusCode expected = HttpStatusCode.NoContent)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{Urls.Users}/{id}/role/{role}"),
            };
            HttpResponseMessage response = client.Send(message);
            HttpStatusCode actual = response.StatusCode;
            Assert.AreEqual(expected, actual);
        }
    }
}
