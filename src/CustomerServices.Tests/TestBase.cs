using CustomerService.Infrastructure.Data;
using CustomerService.Main;
using CustomerService.Service.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerService.Tests
{
    public abstract class TestBase
    {
        protected readonly HttpClient TestClient;
        protected TestBase()
        {
            var appFactory = new WebApplicationFactory<Startup>()
               .WithWebHostBuilder(builder =>
               {
                   builder.ConfigureServices(services =>
                   {
                       services.RemoveAll(typeof(AppDbContext));
                       services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("TestDb"));
                   });
               });
            TestClient = appFactory.CreateClient();
        }

        protected async Task<CustomerResponse> AddCustomerAsync(AddCustomerRequest request)
        {
            var response = await TestClient.PostAsJsonAsync("/api/v1/customers", request);
            return await response.Content.ReadAsAsync<CustomerResponse>();
        }
    }
}
