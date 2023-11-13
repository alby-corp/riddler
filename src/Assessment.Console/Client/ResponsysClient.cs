namespace Assessment.Console.Client;

using Assessment.Console.Exceptions;
using Assessment.Console.Models;
using Assessment.Shared;
using System.Collections.Specialized;
using System.Text.Json;
using System.Web;

public class ResponsysClient : IResponsysClient
{
    private readonly HttpClient _client;

    public ResponsysClient(HttpClient client) => _client = client;
    
    public User? GetCompleteUser(Csv user)
    {
        var builder = HttpUtility.ParseQueryString(string.Empty);

        builder.Add("given-name", user.GivenName);
        builder.Add("family-name", user.FamilyName);

        var response = Send(builder);

        using var stream = response.Content.ReadAsStream();
        var completeUser = JsonSerializer.Deserialize<User>(stream);

        return completeUser;
    }

    private HttpResponseMessage Send(NameValueCollection builder)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"users?{builder}");
        var response = _client.Send(request) ?? throw new ResponseException("response is null");

        if (!response.IsSuccessStatusCode)
            throw new ResponseException(response.ReasonPhrase!);

        return response;
    }
}

