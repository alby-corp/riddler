using Assessment.Console.Abstract;
using Assessment.Console.Models;
using Assessment.Shared;
using System.Text.Json;
using System.Web;
using static System.Console;

namespace Assessment.Console.Retrievers
{
    public class Retriever : IRetriever
    {
        public List<User> Retrieve(IEnumerable<Csv> users, string origin, Action<string>? console = default) 
        {
            var completeUsers = new List<User>();
            foreach (var user in users)
            {
                var builder = HttpUtility.ParseQueryString(string.Empty);

                builder.Add("given-name", user.GivenName);
                builder.Add("family-name", user.FamilyName);

                var client = new HttpClient
                {
                    BaseAddress = new(origin)
                };

                var request = new HttpRequestMessage(HttpMethod.Get, $"users?{builder}");
                var response = client.Send(request);

                if (!response.IsSuccessStatusCode)
                {
                    console?.Invoke($"An error occured: {response.ReasonPhrase}");
                    continue;
                }

                using var stream = response.Content.ReadAsStream();
                var completeUser = JsonSerializer.Deserialize<User>(stream);

                if (completeUser is null) continue;

                completeUsers.Add(completeUser);
            }

            return completeUsers;
        }
    }
}
