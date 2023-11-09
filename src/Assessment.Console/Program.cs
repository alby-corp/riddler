// See https://aka.ms/new-console-template for more information

using Assessment.Console.Models;
using Assessment.Shared;
using static System.Console;


string? path;

while (true)
    try
    {
        Work();
    }
    catch (Exception e)
    {
        WriteLine("An error occurred: {0}", e.Message);
    }

void Work()
{
    do
    {
        WriteLine("Please enter a valid path, for txt template");
        path = ReadLine();
    } while (string.IsNullOrEmpty(path) || path.Length < 3);

    #region Reader
    var users = new ReaderUsersCsv(path).ReaderFromFile();
    #endregion

    #region Retriever
    var retrieverUserCsv = new RetrieverUserCsv();

    var completeUsers = new List<User>();
    foreach (var user in users)
    {
        try
        {
            var completeUser = retrieverUserCsv.Retriever(user);

            if (completeUser is not null) 
                completeUsers.Add(completeUser);
        }
        catch (ResponseException e)
        {
            WriteLine(e.Message);
        }
    }

    #endregion

    #region Writer

    if (completeUsers.Count == 0)
    {
        WriteLine("No users found!");
        return;
    }

    var write = new WriteUsersCsv(path);
    write.WriteToFile(completeUsers);
    WriteLine("Done!");

    #endregion
}