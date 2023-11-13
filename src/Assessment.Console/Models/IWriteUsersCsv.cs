namespace Assessment.Console.Models;

using Assessment.Shared;

public interface IWriteUsersCsv
{
    Task<string> WriteToFileAsync(string path,IEnumerable<User> completeUsers);
}

