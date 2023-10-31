using Assessment.Console.Abstract;
using Assessment.Console.Readers;
using Assessment.Console.Retrievers;
using Assessment.Console.Writers;
using Microsoft.Extensions.DependencyInjection;

namespace Assessment.Console
{
    public static class Bootstrapper
    {
        public static void AddServices(this IServiceCollection services, string origin)
        {
            services.AddSingleton<IReader, Reader>();
            services.AddSingleton<IRetriever, Retriever>();
            services.AddSingleton<IWriter, Writer>();
            services.AddSingleton<UnitOfWork>();

            services.AddHttpClient<IRetriever, Retriever>(client => client.BaseAddress = new Uri(origin));
        }
    }
}
