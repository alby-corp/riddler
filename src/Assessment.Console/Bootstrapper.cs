using Assessment.Console.Abstract;
using Assessment.Console.Core;
using Microsoft.Extensions.DependencyInjection;
namespace Assessment.Console
{
    public static class Bootstrapper
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IReader, Reader>();
            services.AddSingleton<IRetriever, Retriever>();
            services.AddSingleton<IWriter, Writer>();          
        }
    }
}
