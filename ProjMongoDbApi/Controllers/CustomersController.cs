using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjMongoDbApi.Models;
using ProjMongoDbApi.Services;

namespace ProjMongoDbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> Get() => _customerService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCustomerById")]
        public ActionResult<Customer> Get(string id)
        {
            var customer = _customerService.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }


    }
}
