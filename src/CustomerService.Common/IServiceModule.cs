using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerService.Common
{
    public interface IServiceModule
    {
        void RegisterServices(IServiceCollection services, IConfiguration configuration);
    }
}
