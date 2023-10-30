using Assessment.Console.Models;
using Assessment.Shared;
using System.Text.Json;
using System.Web;
using static System.Console;

namespace Assessment.Console.Retrievers
{
    public class Retriever
    {
        public List<User> Retrieve(IEnumerable<Csv> users, string origin) 
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
                    WriteLine("An error occured: {0}", response.ReasonPhrase);
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
