using CustomerService.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using CustomerService.Service.Profiles;
using CustomerService.Infrastructure.DIServices;

namespace CustomerService.Service.DIServices
{
    public class ServiceModule : IServiceModule
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //Register Infrastructure Module
            services.RegisterModules<InfrastructureModule>(configuration);

            //Register services required in service module
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddTransient<ICustomerService, CustomerService>();
        }
    }
}
