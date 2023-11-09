using Assessment.Console.Models;
using Assessment.Shared;
using System.Text.Json;
using System.Web;
using static System.Console;

namespace Assessment.Console.Clients
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient) => _httpClient = httpClient;

        public User? Get(Csv user)
        {
            var builder = HttpUtility.ParseQueryString(string.Empty);

            builder.Add("given-name", user.GivenName);
            builder.Add("family-name", user.FamilyName);

            var request = new HttpRequestMessage(HttpMethod.Get, $"users?{builder}");
            var response = _httpClient.Send(request);

            if (!response.IsSuccessStatusCode)
            {
                WriteLine("An error occured: {0}", response.ReasonPhrase);
                return null;
            }
            else
            {
                using var stream = response.Content.ReadAsStream();
                var completeUser = JsonSerializer.Deserialize<User>(stream);

                return completeUser;
            }
        }
    }
}
