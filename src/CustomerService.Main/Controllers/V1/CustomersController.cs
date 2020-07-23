using CustomerService.Service;
using CustomerService.Service.Contracts.Requests;
using CustomerService.Service.Contracts.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerService.Main.Controllers.V1
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerService _customerService;

        public CustomersController(ILogger<CustomersController> logger, ICustomerService customerService)
        {

            this._logger = logger;
            this._customerService = customerService;
        }

        // GET api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponse>>> GetAllCustomers()
        {
            try
            {
                var customers = await _customerService.GetAllAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CustomersController->GetAllCustomers()");
                return StatusCode(StatusCodes.Status500InternalServerError, "There is some internal issue. Please try again later.");
            }
        }

        // POST api/customers
        [HttpPost]
        public async Task<ActionResult<CustomerResponse>> AddCustomer(AddCustomerRequest customer)
        {
            try
            {
                var result = await _customerService.AddAsync(customer);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CustomersController->AddCustomer()");
                return StatusCode(StatusCodes.Status500InternalServerError, "There is some internal issue. Please try again later.");
            }
        }

    }
}