namespace Assessment.Console;

using Assessment.Console.Client;
using Assessment.Console.Models;
using Assessment.Console.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

public static class ConsoleBootstrapper
{
    private const string ConfigFile = "appsettings.json";

    private static IConfigurationRoot Configuration =>
       new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile(ConfigFile, false, false)
           .Build();

    public static void AddConsoleReference(this IServiceCollection services)
    {
        services.AddConstant();
        services.AddClients();
        services.AddClass();
    }

    private static void AddClass(this IServiceCollection services)
    {
        services.AddSingleton<IRetrieverUserCsv, RetrieverUserCsv>();
        services.AddSingleton<IWriteUsersCsv, WriteUsersCsv>();
        services.AddSingleton<IReaderUsersCsv, ReaderUsersCsv>();
    }

    private static void AddConstant(this IServiceCollection services)
    {
        services
            .AddOptions<ConsoleConstant>()         
            .Bind(Configuration.GetRequiredSection("ConsoleConstant"))
            .ValidateDataAnnotations();
    }

    private static void AddClients(this IServiceCollection services)
    {
        services.AddHttpClient<IResponsysClient,ResponsysClient>((provider, client) =>
        {
            var options = provider.GetRequiredService<IOptions<ConsoleConstant>>().Value;
            client.BaseAddress = new(options.origin);
        });        
    }
}

