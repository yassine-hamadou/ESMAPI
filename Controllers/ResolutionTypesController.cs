using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.LubeBrands;
using ServiceManagerApi.Dtos.ResolutionTypes;

namespace ServiceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResolutionTypesController : BaeApiController<ResolutionTypesController>
    {
        private EnpDbContext _context;

        public ResolutionTypesController(EnpDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResolutionType), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<ResolutionType>> Get()
        {
            return await _context.ResolutionTypes.ToListAsync();
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(ResolutionType), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var resolutionType = await _context.ResolutionTypes.FindAsync(id);
            if (resolutionType == null)
            {
                return NotFound();
            }

            return Ok(resolutionType);
        }
        // post groups
        [HttpPost]
        [ProducesResponseType(typeof(ResolutionType), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(ResolutionTypePostDto resolutionTypePostDto)
        {

            ResolutionType resolutionType = _mapper.Map<ResolutionType>(resolutionTypePostDto);

            _context.ResolutionTypes.Add(resolutionType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResolutionTypeExists(resolutionType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = resolutionType.Id }, resolutionType);
        }

        // updates groups
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, ResolutionType resolutionType)
        {

            if (id != resolutionType.Id)
            {
                return BadRequest();
            }



            _context.Entry(resolutionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResolutionTypeExists(id))
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
            var resolutionTypeToDelete = await _context.ResolutionTypes.FindAsync(id);
            if (resolutionTypeToDelete == null) return NotFound();
            _context.ResolutionTypes.Remove(resolutionTypeToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResolutionTypeExists(int id)
        {
            return _context.ResolutionTypes.Any(e => e.Id == id);
        }
    }
}
