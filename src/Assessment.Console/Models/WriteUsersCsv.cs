namespace Assessment.Console.Models;

using Assessment.Console.Options;
using Assessment.Shared;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

internal class WriteUsersCsv : IWriteUsersCsv
{
    private readonly ConsoleConstant _constant;

    public WriteUsersCsv(IOptions<ConsoleConstant> constant) => _constant = constant.Value;

    public string WriteToFile(string path, IEnumerable<User> completeUsers)
    {        
        var users = completeUsers.ToList();
        return users.Any() ? Write(path, users) : "No users found!";
    }

    private string Write(string path, List<User> users)
    {     
        File.WriteAllLines(
            Path.Combine(path, $"output_{DateTime.Now:yyyy-MM-dd hh-mm-ss}{_constant.extension}"), 
            users.Select(user => $"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}")
            );

        return "Done!";
    }
}