namespace Assessment.Console.Readers;

using Assessment.Console.Abstract;
using Assessment.Console.Models;
using Assessment.Console.Options;
using Microsoft.Extensions.Options;

public class Reader : IReader
{
    private readonly AppOptions _options;

    public Reader(IOptions<AppOptions> options) => _options = options.Value;

    public IEnumerable<Csv> Read(string path)
    {
        var lines = File.ReadAllLines(Path.Combine(path, $"input{_options.Extension}"));
        return lines
            .Where(line => !string.IsNullOrEmpty(line))
            .Select(line =>
            {
                var split = line.Split(_options.Separator);
                return new Csv(split[0].Trim(), split[1].Trim());
            });
    }
}
