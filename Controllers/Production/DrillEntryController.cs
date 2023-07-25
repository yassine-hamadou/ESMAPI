using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Controllers.Esms;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProDrill;

namespace ServiceManagerApi.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillEntryController : BaeApiController<DrillEntryController>
    {
        private readonly EnpDbContext _context;

        public DrillEntryController(EnpDbContext context)
        {
            _context = context;
        }

        // GET: api/DrillEntry
        [HttpGet("tenant/{tenantId}")]
        public async Task<ActionResult<IEnumerable<DrillEntry>>> GetDrillEntries(string tenantId)
        {
            var drillEntries = await _context.DrillEntries
                .Where(leav => leav.TenantId == tenantId)
                .ToListAsync();

            return drillEntries;
        }

        // GET: api/DrillEntry/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDrillEntry(int id)
        {
            var drillEntry = await _context.DrillEntries.FindAsync(id);

            if (drillEntry == null)
            {
                return NotFound();
            }

            return Ok(drillEntry);
        }

        // PUT: api/DrillEntry/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutDrillEntry(int id, DrillEntry drillEntry)
        {
            if (id != drillEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(drillEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrillEntryExists(id))
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

        // POST: api/DrillEntry
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<DrillEntry>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> PostDrillEntry(IEnumerable<DrillEntryDto> drillEntryDto)
        {
            try
            {
                var drillEntry = _mapper.Map<IEnumerable<DrillEntry>>(drillEntryDto);

                var validationResults = new List<ValidationResult>();
                foreach (var entry in drillEntry)
                {
                    var context = new ValidationContext(entry);
                    var isValid = Validator.TryValidateObject(entry, context, validationResults, true);
                    if (!isValid)
                    {
                        return BadRequest(validationResults);
                    }
                }

                _context.DrillEntries.AddRange(drillEntry);
                await _context.SaveChangesAsync();

                var createdDrillEntry = drillEntry.Select(de => de.Id).ToList();
                return CreatedAtAction(nameof(GetDrillEntry), new { id = createdDrillEntry }, drillEntry);
            } catch (DbUpdateException ex)
            {
                throw new ApplicationException("Error saving drill entry", ex);
            }
        }

        // DELETE: api/DrillEntry/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteDrillEntry(int id)
            {
                if (_context.DrillEntries == null)
                {
                    return NotFound();
                }

                var drillEntry = await _context.DrillEntries.FindAsync(id);
                if (drillEntry == null)
                {
                    return NotFound();
                }

                _context.DrillEntries.Remove(drillEntry);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool DrillEntryExists(int id)
            {
                return (_context.DrillEntries?.Any(e => e.Id == id)).GetValueOrDefault();
            }
        }
    }