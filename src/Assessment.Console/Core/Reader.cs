using Assessment.Console.Abstract;
using Assessment.Console.Models;
using Assessment.Console.Options;
using Microsoft.Extensions.Options;

namespace Assessment.Console.Core
{
    internal class Reader : IReader
    {
        readonly AppOptions _options;
        public Reader(IOptions<AppOptions> options) => _options = options.Value;

        public IEnumerable<Csv> Read(string path)
        {
            var lines = File.ReadAllLines(Path.Combine(path, $"input{_options.Extension}"));
            var users = lines
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line =>
                {
                    var split = line.Split(_options.Separator);
                    var givenName = split[0].Trim();
                    var familyName = split[1].Trim();

                    return new Csv(givenName, familyName);
                });

            return users;
        }
    }
}