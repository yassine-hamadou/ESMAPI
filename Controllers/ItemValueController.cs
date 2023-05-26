using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.Groups;
using ServiceManagerApi.Dtos.Items;
using ServiceManagerApi.Dtos.ItemValue;

namespace ServiceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemValueController : BaeApiController<ItemValueController>
    {
        private readonly EnpDbContext _context;
        public ItemValueController(EnpDbContext context)
        {
            _context = context;
        }

        //get all items available
        [HttpGet]
        [ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<ItemValue>> Get()
        {
            return await _context.ItemValues.Include(item=>item.Item).ToListAsync();
            // return await _context.ItemValues.ToListAsync();
        }


        // gets items by id
        [HttpGet("id")]
        [ProducesResponseType(typeof(ItemValue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var itemValue = await _context.ItemValues.FindAsync(id);
            if (itemValue == null)
            {
                return NotFound();
            }

            return Ok(itemValue);
        }


        //post items
        [HttpPost]
        [ProducesResponseType(typeof(ItemValue), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(ItemValuePostDto itemValuePostDto)
        {

            ItemValue itemValue = _mapper.Map<ItemValue>(itemValuePostDto);

            _context.ItemValues.Add(itemValue);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItemValueExists(itemValue.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }   
            }
            return CreatedAtAction(nameof(GetById), new { id = itemValue.Id }, itemValue);
        }

        // updates groups
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, ItemValue itemValue)
        {

            if (id != itemValue.Id)
            {
                return BadRequest();
            }



            _context.Entry(itemValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemValueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // delete ItemValue by id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var itemValueToDelete = await _context.ItemValues.FindAsync(id);
            if (itemValueToDelete == null) return NotFound();
            _context.ItemValues.Remove(itemValueToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemValueExists(int id)
        {
            return _context.ItemValues.Any(e => e.Id == id);
        }
    }
}
