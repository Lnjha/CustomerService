using CustomerService.Common;
using CustomerService.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CustomerService.Infrastructure.Repository;

namespace CustomerService.Infrastructure.DIServices
{
    public class InfrastructureModule : IServiceModule
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AppDbContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("DBCS")));
            
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
