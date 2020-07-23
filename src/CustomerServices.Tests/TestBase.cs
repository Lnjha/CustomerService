using CustomerService.Main;
using CustomerService.Service.Contracts.Requests;
using CustomerService.Service.Contracts.Responses;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerService.Tests
{
    public abstract class TestBase
    {
        protected readonly HttpClient TestClient;
        protected TestBase()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            TestClient = appFactory.CreateClient();
        }

        protected async Task<CustomerResponse> AddCustomerAsync(AddCustomerRequest request)
        {
            var response = await TestClient.PostAsJsonAsync("/api/v1/customers", request);
            return await response.Content.ReadAsAsync<CustomerResponse>();
        }
    }
}
