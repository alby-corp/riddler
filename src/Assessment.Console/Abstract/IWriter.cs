using Assessment.Shared;

namespace Assessment.Console.Abstract
{
    public interface IWriter
    {
        void Write(List<User> completeUsers, string path);
    }
}