using cs_app.Data.DTOs;
using cs_app.Data.Models;
using cs_app.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cs_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _context;

        public CustomerController(CustomerService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.GetCustomers();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<Customer>> GetCustomersById(int id)
        {
            var customers = await _context.GetCustomers(id);

            if (customers == null)
            {
                return NotFound();
            }

            return customers;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> PutCustomers(int id, [FromBody] CustomerDTO customers)
        {
            var result = await _context.UpdateCustomer(id, customers);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomers([FromBody] CustomerDTO customers)
        {
            var result = await _context.AddCustomer(customers);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomers(int id)
        {
            var customers = await _context.DeleteCustomer(id);
            if (customers)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("incomplete")]
        public async Task<ActionResult<IEnumerable<IncompleteCustomerDTO>>> GetItemIncomplete()
        {
            return await _context.GetCustomersIncomplete();
        }
    }
}