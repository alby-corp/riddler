// See https://aka.ms/new-console-template for more information

using Assessment.Console.Readers;
using Assessment.Console.Retrievers;
using Assessment.Console.Writers;
using static System.Console;

const string origin = "http://localhost:5000/";
const string separator = ";";
const string extension = ".txt";

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

    var reader = new Reader();
    var users = reader.Read(path, separator, extension);

    #endregion

    #region Retriever

    var retriever = new Retriever();
    var completeUsers = retriever.Retrieve(users, origin);

    #endregion

    #region Writer

    if (completeUsers.Count == 0)
    {
        WriteLine("No users found!");
        return;
    }

    var writer = new Writer();
    writer.Write(completeUsers, path, extension);

    #endregion
}