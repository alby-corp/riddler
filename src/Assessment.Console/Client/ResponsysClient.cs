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
    
    public async Task<User?> GetCompleteUser(Csv user)
    {
        var builder = HttpUtility.ParseQueryString(string.Empty);

        builder.Add("given-name", user.GivenName);
        builder.Add("family-name", user.FamilyName);

        var response = await Send(builder);

        using var stream = response.Content.ReadAsStream();
        var completeUser = JsonSerializer.Deserialize<User>(stream);

        return completeUser;
    }

    private async Task<HttpResponseMessage> Send(NameValueCollection builder)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"users?{builder}");
        var response = await _client.SendAsync(request) ?? throw new ResponseException("response is null");

        if (!response.IsSuccessStatusCode)
            throw new ResponseException(response.ReasonPhrase!);

        return response;
    }
}

