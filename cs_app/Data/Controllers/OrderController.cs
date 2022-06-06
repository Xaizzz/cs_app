using Microsoft.AspNetCore.Mvc;
using cs_app.Data.Models;
using cs_app.Data.Services;
using cs_app.Data.DTOs;

namespace cs_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _context;

        public OrderController(OrderService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            return await _context.GetOrders();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<Order>> GetOrdersById(int id)
        {
            var orders = await _context.GetOrder(id);

            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> PutOrders(int id, [FromBody] OrderDTO orders)
        {
            var result = await _context.UpdateOrder(id, orders);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrders([FromBody] OrderDTO orders)
        {
            var result = await _context.AddOrder(orders);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            var orders = await _context.DeleteOrder(id);
            if (orders)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("incomplete")]
        public async Task<ActionResult<IEnumerable<IncompleteOrderDTO>>> GetAuthorIncomplete()
        {
            return await _context.GetOrdersIncomplete();
        }
    }
}