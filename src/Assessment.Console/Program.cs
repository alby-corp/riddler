// See https://aka.ms/new-console-template for more information

using Assessment.Console.Readers;
using Assessment.Console.Retrievers;
using Assessment.Console.Writers;
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

    var reader = new Reader(path);
    var users = reader.Read();

    var retriever = new Retriever(users);
    var completeUsers = retriever.Retrieve();

    var writer = new Writer(completeUsers, path);
    writer.Write();

    WriteLine("Done!");
}