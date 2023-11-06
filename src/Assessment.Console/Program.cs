// See https://aka.ms/new-console-template for more information

using Assessment.Console;
using Microsoft.Extensions.DependencyInjection;
using static System.Console;

while (true)
    try
    {
        var services = new ServiceCollection();

        services.AddAppOptions();
        services.AddServices();

        var unit = services.BuildServiceProvider().GetRequiredService<UnitOfWork>();
        await unit.DoWork();
    }
    catch (Exception e)
    {
        WriteLine("An error occurred: {0}", e.Message);
    }
