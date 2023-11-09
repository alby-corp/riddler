using Assessment.Console.Abstract;
using Assessment.Console.Models;

namespace Assessment.Console.Core
{
    internal class Reader : IReader
    {
        const string separator = ";";
        const string extension = ".txt";

        public IEnumerable<Csv> Read(string path)
        {
            var lines = File.ReadAllLines(Path.Combine(path, $"input{extension}"));
            var users = lines
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line =>
                {
                    var split = line.Split(separator);
                    var givenName = split[0].Trim();
                    var familyName = split[1].Trim();

                    return new Csv(givenName, familyName);
                });

            return users;
        }
    }
}