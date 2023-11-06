namespace Assessment.Console.Abstract;

using Assessment.Console.Models;
using Assessment.Shared;

public interface IRetriever
{
    Task<List<User>> RetrieveAsync(IEnumerable<Csv> users, Action<string>? console = default);
}
