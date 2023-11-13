using Assessment.Shared;

namespace Assessment.Console.Abstract
{
    public interface IWriter
    {
        Task Write(IAsyncEnumerable<User> completeUsers, string path);
    }
}