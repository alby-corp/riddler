using Assessment.Console.Models;
using Assessment.Shared;
using System.Text.Json;
using System.Web;
using static System.Console;

namespace Assessment.Console.Retrievers
{
    public class Retriever
    {
        IEnumerable<Csv> Users { get; }
        string Origin { get; }

        public Retriever(IEnumerable<Csv> users, string origin) 
        { 
            Users = users;
            Origin = origin;
        }

        public List<User> Retrieve() 
        {
            var completeUsers = new List<User>();
            foreach (var user in Users)
            {
                var builder = HttpUtility.ParseQueryString(string.Empty);

                builder.Add("given-name", user.GivenName);
                builder.Add("family-name", user.FamilyName);

                var client = new HttpClient
                {
                    BaseAddress = new(Origin)
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
