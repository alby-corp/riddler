namespace Assessment.Console.Writers;

using Assessment.Console.Abstract;
using Assessment.Console.Options;
using Assessment.Shared;
using Microsoft.Extensions.Options;

public class Writer : IWriter
{
    private readonly AppOptions _options;

    public Writer(IOptions<AppOptions> options) => _options = options.Value;

    public async Task WriteAsync(IAsyncEnumerable<User> completeUsers, string path, Action<string>? console = default)
    {
        var lines = new List<string>();

        await foreach (var user in completeUsers)
        {
            lines.Add($"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}");
        }

        if (lines.Count > 0)
        {
            await File.WriteAllLinesAsync(Path.Combine(path, $"output_{DateTime.Now.ToString(_options.DateFormat)}{_options.Extension}"), lines);
            console?.Invoke("Done!");
        }
        else
        {
            console?.Invoke("No users found!");
        }
    }
}
