namespace Assessment.Console.Models;

using Assessment.Console.Client;
using Assessment.Console.Exceptions;
using Assessment.Shared;
using System.Collections.Generic;
using static System.Console;

public class RetrieverUserCsv : IRetrieverUserCsv
{
    private readonly IResponsysClient _client;

    public RetrieverUserCsv(IResponsysClient client) => _client = client;

    public async Task<IEnumerable<User>> Retriever(IEnumerable<Csv> csvUsers)
    {
        var enumerable = RetrieverAsync(csvUsers);

        return await enumerable.ToListAsync();
    }

    private async IAsyncEnumerable<User> RetrieverAsync(IEnumerable<Csv> csvUsers)
    {
        var users = csvUsers.ToList();

        foreach (var csvUser in users)
        {
            var user = await RetrieveUsersAsync(csvUser);

            if (user != null)
            {
                yield return user;
            }
        }
    }

    private async Task<User?> RetrieveUsersAsync(Csv user)
    {
        try
        {
            return await _client.GetCompleteUser(user);
        }
        catch (ResponseException e)
        {
            WriteLine(e.Message);
            return null;
        }
    }
}