namespace Assessment.Console.Abstract;

using Assessment.Shared;

public interface IWriter
{
    Task WriteAsync(List<User> completeUsers, string path, Action<string>? console = default);
}
