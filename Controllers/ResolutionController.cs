using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.Resolution;

namespace ServiceManagerApi.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class ResolutionsController : BaeApiController<ResolutionsController>
    {
        private EnpDbContext _context;

        public ResolutionsController(EnpDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Resolution), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Resolution>> Get()
        {
            return await _context.Resolutions.ToListAsync();
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(Resolution), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var resolution = await _context.Resolutions.FindAsync(id);
            if (resolution == null)
            {
                return NotFound();
            }

            return Ok(resolution);
        }
        // post groups
        [HttpPost]
        [ProducesResponseType(typeof(Resolution), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(ResolutionPostDto resolutionPostDto)
        {

            Resolution resolution = _mapper.Map<Resolution>(resolutionPostDto);

            _context.Resolutions.Add(resolution);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResolutionExists(resolution.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = resolution.Id }, resolution);
        }

        // updates groups
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, Resolution resolution)
        {

            if (id != resolution.Id)
            {
                return BadRequest();
            }



            _context.Entry(resolution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResolutionExists(id))
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

        // delete groups
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var resolutionToDelete = await _context.Resolutions.FindAsync(id);
            if (resolutionToDelete == null) return NotFound();
            _context.Resolutions.Remove(resolutionToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResolutionExists(int id)
        {
            return _context.Resolutions.Any(e => e.Id == id);
        }
    }
}
