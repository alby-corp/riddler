namespace Assessment.Console.Models;

using Assessment.Console.Options;
using Microsoft.Extensions.Options;

public class ReaderUsersCsv : IReaderUsersCsv
{
    private readonly ConsoleConstant _constant;

    public ReaderUsersCsv(IOptions<ConsoleConstant> constant) => _constant = constant.Value;

    public async Task<IEnumerable<Csv>> ReaderFromFile(string path)
    {             
        var lines = await File.ReadAllLinesAsync(Path.Combine(path, $"input{_constant.extension}")) ?? Array.Empty<string>();
        var users = lines
            .Where(line => !string.IsNullOrEmpty(line))
            .Select(line =>
            {
                var split = line.Split(_constant.separator);
                return new Csv
                (
                    GivenName: split[0].Trim(),
                    FamilyName: split[1].Trim()
                );
            });

        return users;
    }
}