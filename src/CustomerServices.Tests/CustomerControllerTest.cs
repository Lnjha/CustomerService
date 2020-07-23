using CustomerService.Service.Contracts.Requests;
using CustomerService.Service.Contracts.Responses;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CustomerService.Tests
{
    public class CustomerControllerTest : TestBase
    {
        [Fact]
        public async Task GetAllCustomers_ReturnCustomers_WhenCustomersExistsInDatabase()
        {
            // Arrange
            var firstRequest = new AddCustomerRequest
            {
                Name = "R N Jha",
                ContactNumber = "0989898098",
                Email = "RN@Test.Com",
                Address = "Test Address"
            };
            var secondRequest = new AddCustomerRequest
            {
                Name = "M N Jha",
                ContactNumber = "0989898099",
                Email = "MN@Test.Com",
                Address = "Test Address2"
            };
            var firstAddedCustomer = await AddCustomerAsync(firstRequest);
            var secondAddedCustomer = await AddCustomerAsync(secondRequest);

            // Act
            var responses = await TestClient.GetAsync("/api/v1/customers");

            // Assert
            responses.StatusCode.Should().Be(HttpStatusCode.OK);
            var customers = await responses.Content.ReadAsAsync<List<CustomerResponse>>();
            customers.Count.Should().BeGreaterThan(1);
            var firstCustomer = customers.SingleOrDefault(c => c.Id == firstAddedCustomer.Id);
            firstCustomer.Should().NotBeNull();
            firstCustomer.Name.Should().Be(firstRequest.Name);
            firstCustomer.Email.Should().Be(firstRequest.Email);
            firstCustomer.ContactNumber.Should().Be(firstRequest.ContactNumber);
            firstCustomer.Address.Should().Be(firstRequest.Address);

            var secondCustomer = customers.SingleOrDefault(c => c.Id == secondAddedCustomer.Id);
            secondCustomer.Should().NotBeNull();
            secondCustomer.Name.Should().Be(secondRequest.Name);
            secondCustomer.Email.Should().Be(secondRequest.Email);
            secondCustomer.ContactNumber.Should().Be(secondRequest.ContactNumber);
            secondCustomer.Address.Should().Be(secondRequest.Address);


        }

        [Fact]
        public async Task AddCustomer_ShouldCreateCustomerInDatabase_AndReturnCustomerDetails()
        {
            // Arrange
            var request = new AddCustomerRequest
            {
                Name = "L N Jha",
                ContactNumber = "0989898098",
                Email = "LN@Test.Com",
                Address = "Test Address"
            };

            // Act
            var responses = await TestClient.PostAsJsonAsync("/api/v1/customers", request);

            // Assert
            responses.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedCustomer = await responses.Content.ReadAsAsync<CustomerResponse>();
            returnedCustomer.Name.Should().Be(request.Name);
            returnedCustomer.Email.Should().Be(request.Email);
            returnedCustomer.ContactNumber.Should().Be(request.ContactNumber);
            returnedCustomer.Address.Should().Be(request.Address);
        }
    }
}
