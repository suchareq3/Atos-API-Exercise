using atos_api_exercise.Models;
using atos_api_exercise.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace atos_api_exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerService> _logger;
        public CustomerController(ICustomerService customerService, ILogger<CustomerService> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all customers.");
            return Ok(_customerService.GetAllCustomers());
        }

        [HttpPost]
        public IActionResult Post(NewCustomer customerObj)
        {
            var customer = _customerService.AddCustomer(customerObj);
            if (customer == null)
            {
                _logger.LogWarning("Bad request while attempting to add customer!");
                return BadRequest();
            }


            _logger.LogInformation($"New customer created!");
            return Ok(new
            {
                message = "New customer created!",
                id = customer!.Id,
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!_customerService.RemoveCustomer(id)) {
                _logger.LogWarning($"Attempted to remove non-existing customer with id:{id}");
                return NotFound();
            }

            _logger.LogInformation($"Customer #{id} deleted!");
            return Ok(new
            {
                message = "Customer deleted!",
                id
            });
        }
    }
}
