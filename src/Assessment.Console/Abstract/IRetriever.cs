using Assessment.Console.Models;
using Assessment.Shared;

namespace Assessment.Console.Abstract
{
    public interface IRetriever
    {
        IAsyncEnumerable<User> Retrieve(IEnumerable<Csv> users);
    }
}