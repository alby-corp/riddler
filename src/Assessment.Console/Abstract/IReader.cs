using Assessment.Console.Models;

namespace Assessment.Console.Abstract
{
    public interface IReader
    {
        Task<IEnumerable<Csv>> Read(string path);
    }
}
