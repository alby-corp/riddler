using Assessment.Shared;
using System.Text.Json;
using System.Web;

namespace Assessment.Console.Models
{
    internal class RetrieverUserCsv
    {        
        internal User? Retriever(Csv user)
        {
            var builder = HttpUtility.ParseQueryString(string.Empty);

            builder.Add("given-name", user.GivenName);
            builder.Add("family-name", user.FamilyName);

            var client = new HttpClient
            {
                BaseAddress = new(Constant.origin)
            };

            var request = new HttpRequestMessage(HttpMethod.Get, $"users?{builder}");
            var response = client.Send(request) ?? throw new ResponseException("response is null");

            if ( !response.IsSuccessStatusCode)
                throw new ResponseException(response.ReasonPhrase!);

            using var stream = response!.Content.ReadAsStream();
            var completeUser = JsonSerializer.Deserialize<User>(stream);

            return completeUser;
        }
    }
}
