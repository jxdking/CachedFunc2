using Microsoft.Extensions.DependencyInjection;

namespace MagicEastern.CachedFunc2
{
    public static class ServiceExt
    {
        public static IServiceCollection AddCachedFunc(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<CachedFuncSvc>();

            return serviceCollection;
        }
    }
}
