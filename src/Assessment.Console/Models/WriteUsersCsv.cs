namespace Assessment.Console.Models;

using Assessment.Console.Options;
using Assessment.Shared;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

internal class WriteUsersCsv : IWriteUsersCsv
{
    private readonly ConsoleConstant _constant;

    public WriteUsersCsv(IOptions<ConsoleConstant> constant) => _constant = constant.Value;

    public async Task<string> WriteToFileAsync(string path, IEnumerable<User> completeUsers)
    {
        var users = completeUsers.ToList();
        return users.Any() ? await Write(path, users) : "No users found!";
    }

    private async Task<string> Write(string path, List<User> users)
    {
        await File.WriteAllLinesAsync(
            Path.Combine(path, $"output_{DateTime.Now:yyyy-MM-dd hh-mm-ss}{_constant.extension}"),
            users.Select(user => $"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}")
            );

        return "Done!";
    }
}