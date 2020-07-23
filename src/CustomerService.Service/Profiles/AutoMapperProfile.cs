using AutoMapper;
using CustomerService.Domain.Entities;
using CustomerService.Service.DTO;

namespace CustomerService.Service.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddCustomerRequest, Customer>();
            CreateMap<AddCustomerRequest, CustomerResponse>();
            CreateMap<Customer, CustomerResponse>();
        }
    }
}