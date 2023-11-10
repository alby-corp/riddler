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

        public async Task<User?> GetAsync(Csv user)
        {
            var builder = HttpUtility.ParseQueryString(string.Empty);

            builder.Add("given-name", user.GivenName);
            builder.Add("family-name", user.FamilyName);

            var request = new HttpRequestMessage(HttpMethod.Get, $"users?{builder}");
            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                WriteLine("An error occured: {0}", response.ReasonPhrase);
                return null;
            }
            else
            {
                using var stream = await response.Content.ReadAsStreamAsync();
                var completeUser = await JsonSerializer.DeserializeAsync<User>(stream);

                return completeUser;
            }
        }
    }
}
