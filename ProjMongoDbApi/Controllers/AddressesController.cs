using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjMongoDbApi.Models;
using ProjMongoDbApi.Services;

namespace ProjMongoDbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressesController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get()
        {
            return _addressService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<Address> Get(string id)
        {
            return _addressService.Get(id);
        }
        [HttpPost]
        public ActionResult<Address> Create(Address address)
        {
            _addressService.Create(address);
            return CreatedAtRoute("GetAddress", new { id = address.Id }, address);
        }
    }
}
