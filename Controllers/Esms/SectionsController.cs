using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.Sections;

namespace ServiceManagerApi.Controllers.Esms
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : BaeApiController<SectionsController>
    {
        private readonly EnpDbContext _context;

        public SectionsController(EnpDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Section), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Section>> Get()
        {
            return await _context.Sections
                .Include(sec=>sec.Groups)
                    .ThenInclude(grop=>grop.Items)
                .Include(ser=>ser.Service)
                .ToListAsync();
        }

        // gets sections by id
        [HttpGet("id")]
        [ProducesResponseType(typeof(Section), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var section = await _context.Sections.FindAsync(id);
            if (section == null)
            {
                return NotFound();
            }

            return Ok(section);
        }


        // post sections 
        [HttpPost]
        [ProducesResponseType(typeof(Group), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(SectionPostDto sectionPostDto)
        {

            Section section = _mapper.Map<Section>(sectionPostDto);

            _context.Sections.Add(section);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SectionExists(section.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = section.Id }, section);
        }

        // updates groups
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, Section section)
        {

            if (id != section.Id)
            {
                return BadRequest();
            }
            _context.Entry(section).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionExists(id))
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

        // delete Section by id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var sectionToDelete = await _context.Sections.FindAsync(id);
            if (sectionToDelete == null) return NotFound();
            _context.Sections.Remove(sectionToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SectionExists(int id)
        {
            return _context.Sections.Any(e => e.Id == id);
        }
    }
    
}
