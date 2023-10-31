namespace Assessment.Console.Abstract;

using Assessment.Shared;

public interface IWriter
{
    void Write(List<User> completeUsers, string path, Action<string>? console = default);
}
