using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Controllers.Esms;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.proDrillEntry;

namespace ServiceManagerApi.Controllers.Production
{
    public class ProDrillEntryController : BaeApiController<ProDrillEntryController>
    {
        private readonly EnpDbContext _context;

        public ProDrillEntryController(EnpDbContext context)
        {
            _context = context;
        }

        // GET: api/ProDrillEntry
        [HttpGet("tenant/{tenantId}")]
        public Task<List<ProDrillEntry>> GetProDrillEntries(string tenantId)
        {
            var proDrillEntries = _context.ProDrillEntries
                .Where(leav => leav.TenantId == tenantId)
                .ToListAsync();
            
            return proDrillEntries;
        }

        // GET: api/ProDrillEntry/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProDrillEntry), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var proDrillEntry = await _context.ProDrillEntries.FindAsync(id);
            if (proDrillEntry == null)
            {
                return NotFound();
            }
            
            return Ok(proDrillEntry);
        }

        // PUT: api/ProDrillEntry/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutProDrillEntry(int id, ProDrillEntry proDrillEntry)
        {
            if (id != proDrillEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(proDrillEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProDrillEntryExistsById(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/ProDrillEntry
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(ProDrillEntry), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProDrillEntry>> Create(ProDrillEntryPostDto proDrillEntryPostDto)
        {
            ProDrillEntry proDrillEntry = _mapper.Map<ProDrillEntry>(proDrillEntryPostDto);
            if (ProDrillEntryExists(proDrillEntryPostDto))
            {
                return Conflict();
            }

            _context.ProDrillEntries.Add(proDrillEntry);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = proDrillEntry.Id }, proDrillEntry);
        }

        // DELETE: api/ProDrillEntry/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProDrillEntry(int id)
        {
            var proDrillEntry = await _context.ProDrillEntries.FindAsync(id);
            if (_context.ProDrillEntries == null)
            {
                return NotFound();
            }

            if (proDrillEntry == null)
            {
                return NotFound();
            }

            _context.ProDrillEntries.Remove(proDrillEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProDrillEntryExistsById(int id)
        {
            return (_context.ProDrillEntries?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private bool ProDrillEntryExists(ProDrillEntryPostDto proDrillEntry)
        {
            return (_context.ProDrillEntries?.Any(e =>
                proDrillEntry.DrillDate == e.DrillDate &&
                proDrillEntry.ShiftId == e.ShiftId &&
                proDrillEntry.RigId == e.RigId &&
                proDrillEntry.ActivityId == e.ActivityId &&
                proDrillEntry.ActivityDetailId == e.ActivityDetailId &&
                proDrillEntry.TenantId == e.TenantId
            )).GetValueOrDefault();
        }
    }
}