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

        public async IAsyncEnumerable<User> Retrieve(IEnumerable<Csv> users)
        {
            foreach (var user in users)
            {
                var completeUser = await _client.GetAsync(user);
                if (completeUser != null)
                    yield return completeUser;
            }

        }
    }
}