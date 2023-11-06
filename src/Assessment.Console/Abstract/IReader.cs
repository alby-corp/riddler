namespace Assessment.Console.Abstract;

using Assessment.Console.Models;

public interface IReader
{
    Task<IEnumerable<Csv>> ReadAsync(string path);
}
