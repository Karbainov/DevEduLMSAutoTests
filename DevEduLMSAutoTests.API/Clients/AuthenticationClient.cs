using DevEduLMSAutoTests.API.Support.Models.Response;
using DevEduLMSAutoTests.API.Support.Models.Request;

namespace DevEduLMSAutoTests.API.Clients
{
    public class AuthenticationClient
    {
        public RegisterResponse RegisterUser(RegisterRequest newUser)
        {
            string json = JsonSerializer.Serialize(newUser);
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(Urls.Register),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage responseMessage = client.Send(message);
            RegisterResponse response = JsonSerializer.Deserialize<RegisterResponse>
                (responseMessage.Content.ReadAsStringAsync().Result)!;
            return response;
        }

        public string AuthorizeUser(SignInRequest request)
        {
            string json = JsonSerializer.Serialize(request);
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new System.Uri(Urls.Sign_in),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage responseMessage = client.Send(message);
            string token = responseMessage.Content.ReadAsStringAsync().Result;
            return token;
        }
    }
}