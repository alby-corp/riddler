// See https://aka.ms/new-console-template for more information

using Assessment.Console;
using Assessment.Console.Abstract;
using Assessment.Console.Readers;
using Assessment.Console.Retrievers;
using Assessment.Console.Writers;
using Microsoft.Extensions.DependencyInjection;
using static System.Console;

const string origin = "http://localhost:5000/";
const string separator = ";";
const string extension = ".txt";

string? path;

while (true)
    try
    {
        var services = new ServiceCollection();

        services.AddSingleton<IReader, Reader>();
        services.AddSingleton<IRetriever, Retriever>();
        services.AddSingleton<IWriter, Writer>();
        services.AddSingleton<UnitOfWork>();

        do
        {
            WriteLine("Please enter a valid path, for txt template");
            path = ReadLine();
        } while (string.IsNullOrEmpty(path) || path.Length < 3);

        var unit = services.BuildServiceProvider().GetRequiredService<UnitOfWork>();
        unit.DoWork(path, separator, extension, origin);
    }
    catch (Exception e)
    {
        WriteLine("An error occurred: {0}", e.Message);
    }
