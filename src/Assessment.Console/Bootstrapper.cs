namespace Assessment.Console;

using Assessment.Console.Abstract;
using Assessment.Console.Readers;
using Assessment.Console.Retrievers;
using Assessment.Console.Writers;
using Assessment.Console.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

public static class Bootstrapper
{
    private const string OptionsFile = "appsettings.json";

    private static IConfigurationRoot Configuration =>
    new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(OptionsFile, false, false)
        .Build();

    public static void AddAppOptions(this IServiceCollection services)
    {
        services
            .AddOptions<AppOptions>()
            .Bind(Configuration.GetRequiredSection("AppOptions"))
            .ValidateDataAnnotations();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IReader, Reader>();
        services.AddSingleton<IRetriever, Retriever>();
        services.AddSingleton<IWriter, Writer>();
        services.AddSingleton<UnitOfWork>();

        services.AddHttpClient<IRetriever, Retriever>((provider, client) => {
            var options = provider.GetRequiredService<IOptions<AppOptions>>().Value;
            client.BaseAddress = new Uri(options.BaseUrl);
        });
    }
}
