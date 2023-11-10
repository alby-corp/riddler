using Assessment.Console.Abstract;
using Assessment.Console.Clients;
using Assessment.Console.Models;
using Assessment.Shared;

namespace Assessment.Console.Core
{
    internal class Retriever : IRetriever
    {
        readonly ApiClient _client;
        public Retriever(ApiClient client) => _client = client;

        public async Task<List<User>> Retrieve(IEnumerable<Csv> users)
        {
            var completeUsers = new List<User>();

            foreach (var user in users)
            {
                var completeUser = await _client.GetAsync(user);
                if (completeUser != null)
                    completeUsers.Add(completeUser);
            }

            return completeUsers;
        }
    }
}