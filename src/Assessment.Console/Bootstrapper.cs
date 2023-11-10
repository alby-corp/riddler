using Assessment.Console.Abstract;
using Assessment.Console.Clients;
using Assessment.Console.Core;
using Assessment.Console.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Assessment.Console
{
    public static class Bootstrapper
    {
        private const string OptionsFile = "appsettings.json";

        private static IConfigurationRoot Configuration =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(OptionsFile, false, false)
            .Build();


        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IReader, Reader>();
            services.AddSingleton<IRetriever, Retriever>();
            services.AddSingleton<IWriter, Writer>();
        }

        public static void AddAppOptions(this IServiceCollection services)
        {
            services
                .AddOptions<AppOptions>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("AppOptions").Bind(settings);
                })
                .ValidateDataAnnotations();
        }

        public static void AddHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient<ApiClient>((provider, client) =>
            {
                var options = provider.GetRequiredService<IOptions<AppOptions>>().Value;
                client.BaseAddress = new(options.Url);
            });
        }
    }
}
