using Assessment.Console.Models;
using Assessment.Shared;

namespace Assessment.Console.Abstract
{
    public interface IRetriever
    {
        List<User> Retrieve(IEnumerable<Csv> users);
    }
}