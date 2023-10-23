// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using System.Web;
using Riddler.Puzzle1.Models;
using Riddler.Shared.Users;
using static System.Console;

const string origin = "http://localhost:5000/";
const string separator = ";";
const string extension = ".txt";

while (true)
    try
    {
        Work();
    }
    catch (Exception e)
    {
        WriteLine("An error occurred: {0}", e.Message);
    }

void Work()
{
    string? path;
    string? filename;

    do
    {
        WriteLine("Please enter a valid path");
        path = ReadLine();
        WriteLine("Please enter a valid filename");
        filename = ReadLine();
    } while (string.IsNullOrEmpty(path) || path.Length < 3);

    #region Reader

    var lines = File.ReadAllLines(Path.Combine(path, $"{filename}{extension}"));
    var users = lines
        .Where(line => !string.IsNullOrEmpty(line))
        .Select(line =>
        {
            var split = line.Split(separator);
            return new Csv
            {
                GivenName = split[0].Trim(),
                FamilyName = split[1].Trim()
            };
        });

    #endregion

    #region Retriever

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
            WriteLine("User {0} {1}: {2}", user.GivenName, user.FamilyName, response.ReasonPhrase);
            continue;
        }

        using var stream = response.Content.ReadAsStream();
        var completeUser = JsonSerializer.Deserialize<User>(stream);

        if (completeUser is null) continue;

        completeUsers.Add(completeUser);
    }

    #endregion

    #region Writer

    if (completeUsers.Count == 0)
    {
        WriteLine("No users found!");
        return;
    }

    File.WriteAllLines(Path.Combine(path, $"output_{DateTime.Now:yyyy-MM-dd hh-mm-ss}{extension}"), completeUsers.Select(user => $"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}"));
    WriteLine("Done!");

    #endregion
}