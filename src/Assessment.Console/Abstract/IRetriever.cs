namespace Assessment.Console.Abstract;

using Assessment.Console.Models;
using Assessment.Shared;

public interface IRetriever
{
    IAsyncEnumerable<User> RetrieveAsync(IEnumerable<Csv> users, Action<string>? console = default);
}
