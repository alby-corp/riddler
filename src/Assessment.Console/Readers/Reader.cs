using Assessment.Console.Models;

namespace Assessment.Console.Readers
{
    internal class Reader
    {
        const string separator = ";";
        const string extension = ".txt";

        readonly string _path;

        public Reader(string path) => _path = path; 

        public IEnumerable<Csv> Read() 
        {
            var lines = File.ReadAllLines(Path.Combine(_path, $"input{extension}"));
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