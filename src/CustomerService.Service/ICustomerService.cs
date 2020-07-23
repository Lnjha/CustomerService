using CustomerService.Service.Contracts.Requests;
using CustomerService.Service.Contracts.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CustomerService.Service
{
    public interface ICustomerService
    {
        Task<CustomerResponse> AddAsync(AddCustomerRequest customerDTO);
        Task<IEnumerable<CustomerResponse>> GetAllAsync();
    }
}
