using Assessment.Console.Abstract;
using Assessment.Console.Options;
using Assessment.Shared;
using Microsoft.Extensions.Options;
using static System.Console;

namespace Assessment.Console.Core
{
    internal class Writer : IWriter
    {
        readonly AppOptions _options;
        public Writer(IOptions<AppOptions> options) => _options = options.Value;

        public async Task Write(IAsyncEnumerable<User> completeUsers, string path)
        {
            var userLines = new List<string>();

            await foreach (var user in completeUsers)
            {
                userLines.Add($"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}");
            }

            if (userLines.Count == 0)
            {
                WriteLine("No users found!");
                return;
            }

            await File.WriteAllLinesAsync(Path.Combine(path, $"output_{DateTime.Now:yyyy-MM-dd hh-mm-ss}{_options.Extension}"), userLines);
        }
    }
}