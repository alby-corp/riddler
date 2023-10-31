namespace Assessment.Console.Writers;

using Assessment.Console.Abstract;
using Assessment.Console.Options;
using Assessment.Shared;
using Microsoft.Extensions.Options;

public class Writer : IWriter
{
    private readonly AppOptions _options;

    public Writer(IOptions<AppOptions> options) => _options = options.Value;

    public void Write(List<User> completeUsers, string path, Action<string>? console = default)
    {
        File.WriteAllLines(Path.Combine(path, $"output_{DateTime.Now.ToString(_options.DateFormat)}{_options.Extension}"), completeUsers.Select(user => $"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}"));
        console?.Invoke("Done!");
    }
}
