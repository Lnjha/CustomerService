using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CustomerService.Common
{
    public static class ServicesExtension
    {
        public static void RegisterModules<T>(this IServiceCollection services, IConfiguration configuration)
        {
            var modules = typeof(T).Assembly.ExportedTypes.Where(x =>
              typeof(IServiceModule).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
              .Select(Activator.CreateInstance).Cast<IServiceModule>().ToList();

            modules.ForEach(module => module.RegisterServices(services, configuration));
        }
    }
}
