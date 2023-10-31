namespace Assessment.Console.Abstract;

using Assessment.Console.Models;
using Assessment.Shared;

public interface IRetriever
{
    List<User> Retrieve(IEnumerable<Csv> users, Action<string>? console = default);
}
