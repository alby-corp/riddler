// See https://aka.ms/new-console-template for more information

using Assessment.Console;
using Microsoft.Extensions.DependencyInjection;
using static System.Console;

const string origin = "http://localhost:5000/";
const string separator = ";";
const string extension = ".txt";

while (true)
    try
    {
        var services = new ServiceCollection();

        services.AddServices(origin);

        var unit = services.BuildServiceProvider().GetRequiredService<UnitOfWork>();
        unit.DoWork(separator, extension);
    }
    catch (Exception e)
    {
        WriteLine("An error occurred: {0}", e.Message);
    }
