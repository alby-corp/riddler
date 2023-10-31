using Assessment.Console.Abstract;
using Assessment.Console.Models;

namespace Assessment.Console.Readers
{
    public class Reader : IReader
    {
        public IEnumerable<Csv> Read(string path, string separator, string extension) 
        {
            var lines = File.ReadAllLines(Path.Combine(path, $"input{extension}"));
            return lines
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line =>
                {
                    var split = line.Split(separator);
                    return new Csv(split[0].Trim(), split[1].Trim());
                });
        }
    }
}
