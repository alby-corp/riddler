// See https://aka.ms/new-console-template for more information

using Assessment.Console;
using Assessment.Console.Abstract;
using Assessment.Console.Core;
using Assessment.Console.Helpers;
using Microsoft.Extensions.DependencyInjection;
using static System.Console;

string path;

var services = new ServiceCollection();

services.AddHttpClients();
services.AddSingleton<IReader, Reader>();
services.AddSingleton<IRetriever, Retriever>();
services.AddSingleton<IWriter, Writer>();
services.AddSingleton<Worker>();

var unit = services.BuildServiceProvider().GetRequiredService<Worker>();



while (true)
    try 
    {
        path = InputPath.GetValidPath();
        unit.Work(path);
    }
    catch (Exception e)
    {
        WriteLine("An error occurred: {0}", e.Message);
    }