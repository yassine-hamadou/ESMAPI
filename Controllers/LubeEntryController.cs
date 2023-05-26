using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.LubeEntry;
namespace ServiceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LubeEntryController : BaeApiController<LubeEntryController>
    {
        private EnpDbContext _context;

        public LubeEntryController(EnpDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [ProducesResponseType(typeof(LubeEntry), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<LubeEntry>> Get()
        {
            return await _context.LubeEntries
                .ToListAsync();
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(LubeEntry), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var lubeEntry = await _context.LubeEntries.FindAsync(id);
            if (lubeEntry == null)
            {
                return NotFound();
            }

            return Ok(lubeEntry);
        }
        // post lubeConfigs
        [HttpPost]
        [ProducesResponseType(typeof(LubeEntry), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(LubeEntryPostDto lubeEntryPostDto)
        {

            LubeEntry lubeEntry = _mapper.Map<LubeEntry>(lubeEntryPostDto);

            _context.LubeEntries.Add(lubeEntry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LubeEntryExists(lubeEntry.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = lubeEntry.Id }, lubeEntry);
        }

        // updates LubeConfigs
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, LubeEntry lubeEntry)
        {

            if (id != lubeEntry.Id)
            {
                return BadRequest();
            }


            _context.Entry(lubeEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LubeEntryExists(id))
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

        // delete LubeEntry
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var lubeEntryToDelete = await _context.LubeEntries.FindAsync(id);
            if (lubeEntryToDelete == null) return NotFound();
            _context.LubeEntries.Remove(lubeEntryToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LubeEntryExists(int id)
        {
            return _context.LubeEntries.Any(e => e.Id == id);
        }
    }
}
