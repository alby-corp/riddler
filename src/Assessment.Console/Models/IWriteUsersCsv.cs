namespace Assessment.Console.Models;

using Assessment.Shared;

public interface IWriteUsersCsv
{
    string WriteToFile(string path,IEnumerable<User> completeUsers);
}

