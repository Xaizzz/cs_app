using cs_app.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using cs_app.Data.Models;
using cs_app.Data.Services;

namespace cs_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _context;

        public ItemController(ItemService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _context.GetItems();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.GetItem(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Item>> PutItem(int id, [FromBody] ItemDTO item)
        {
            var result = await _context.UpdateItem(id, item);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Item>> PostItem([FromBody] ItemDTO item)
        {
            var result = await _context.AddItem(item);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.DeleteItem(id);
            if (item)
            {
                return Ok();
            }

            return BadRequest();
            
        }
        [HttpGet("incomplete")]
        public async Task<ActionResult<IEnumerable<IncompleteItemDTO>>> GetItemsIncomplete()
        {
            return await _context.GetItemsIncomplete();
        }
    }
}