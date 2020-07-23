using AutoMapper;
using CustomerService.Domain.Entities;
using CustomerService.Infrastructure.Repository;
using CustomerService.Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerService.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;

        public CustomerService(IRepository<Customer> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<CustomerResponse> AddAsync(AddCustomerRequest addCustomer)
        {

            var customer = await _repository.AddAsync(_mapper.Map<Customer>(addCustomer));
            var response = _mapper.Map<CustomerResponse>(addCustomer);
            response.Id = customer.Id;
            return response;
        }

        public async Task<IEnumerable<CustomerResponse>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerResponse>>(result);
        }
    }
}
