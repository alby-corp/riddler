using Assessment.Shared;

namespace Assessment.Console.Abstract
{
    public interface IWriter
    {
        Task Write(List<User> completeUsers, string path);
    }
}