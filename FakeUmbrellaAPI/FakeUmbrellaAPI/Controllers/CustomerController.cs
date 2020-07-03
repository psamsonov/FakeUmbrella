using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using FakeUmbrellaAPI.Exceptions;
using FakeUmbrellaAPI.Models;
using FakeUmbrellaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FakeUmbrellaAPI.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return Ok(CustomerService.GetCustomers());
        }

        [HttpGet("rain")]
        public ActionResult<IEnumerable<Customer>> GetCustomersForRain()
        {
            return Ok(CustomerService.GetCustomersForRain());
        }

        [HttpPost]
        public ActionResult CreateCustomer([FromBody] Customer customer)
        {
            CustomerService.CreateCustomer(customer);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer([FromRoute] Guid id, [FromBody] Customer customer)
        {
            try
            {
                CustomerService.UpdateCustomer(id, customer);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer([FromRoute] Guid id)
        {
            try
            {
                CustomerService.DeleteCustomer(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }


        [Route("rain")]
        public ActionResult<IEnumerable<Customer>> GetCustomersWithRain()
        {
            return Ok(CustomerService.GetCustomersWithRain());
        }

        [Route("top")]
        public ActionResult<IEnumerable<Customer>> GetTopCustomers()
        {
            return Ok(CustomerService.GetTopCustomers());
        }
    }
}
