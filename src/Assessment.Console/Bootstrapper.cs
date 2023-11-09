using Assessment.Console.Abstract;
using Assessment.Console.Clients;
using Assessment.Console.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Assessment.Console
{
    public static class Bootstrapper
    {
        const string origin = "http://localhost:5000/";

        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IReader, Reader>();
            services.AddSingleton<IRetriever, Retriever>();
            services.AddSingleton<IWriter, Writer>();          
        }

        public static void AddHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient<ApiClient>(client =>
            {
                client.BaseAddress = new Uri(origin);
            });
        }
    }
}
