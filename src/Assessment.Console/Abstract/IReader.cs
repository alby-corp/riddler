namespace Assessment.Console.Abstract;

using Assessment.Console.Models;

public interface IReader
{
    IEnumerable<Csv> Read(string path);
}
