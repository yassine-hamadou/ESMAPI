using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.FaultEntry;

namespace ServiceManagerApi.Controllers.Esms
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaultEntriesApiController : BaeApiController<FaultEntryPostDto>
    {
        private readonly EnpDbContext _context;

        public FaultEntriesApiController(EnpDbContext context)
        {
            _context = context;
        }

        // GET: api/FaultEntriesApi
        [HttpGet("tenant/{tenantId}")]
        public async Task<ActionResult<IEnumerable<FaultEntry>>> GetFaultEntries(string tenantId)
        {
            return await _context.FaultEntries.Where(fault => fault.TenantId == tenantId).ToListAsync();
        }

        // GET: api/FaultEntriesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FaultEntry>> GetFaultEntry(Guid id)
        {
            var faultEntry = await _context.FaultEntries.FindAsync(id);

            if (faultEntry == null)
            {
                return NotFound();
            }

            return faultEntry;
        }

        // PUT: api/FaultEntriesApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaultEntry(Guid id, FaultEntry faultEntry)
        {
            if (id != faultEntry.EntryId)
            {
                return BadRequest();
            }

            _context.Entry(faultEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaultEntryExists(id))
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

        // POST: api/FaultEntriesApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FaultEntry>> PostFaultEntry(FaultEntryPostDto faultEntryPostDto)
        {
            var faultEntry = _mapper.Map<FaultEntry>(faultEntryPostDto);
            _context.FaultEntries.Add(faultEntry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FaultEntryExists(faultEntry.EntryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFaultEntry", new { id = faultEntry.EntryId }, faultEntry);
        }

        // patch groups
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<FaultEntry> patchFaultEntry)
        {

            var fualts = await _context.FaultEntries.FindAsync(id);

            if (fualts == null)
            {
                return BadRequest();
            }
            
            patchFaultEntry.ApplyTo(fualts, ModelState);

            await _context.SaveChangesAsync();

            return Ok(fualts);
        }

        // DELETE: api/FaultEntriesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaultEntry(Guid id)
        {
            var faultEntry = await _context.FaultEntries.FindAsync(id);
            if (faultEntry == null)
            {
                return NotFound();
            }

            _context.FaultEntries.Remove(faultEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FaultEntryExists(Guid id)
        {
            return _context.FaultEntries.Any(e => e.EntryId == id);
        }
    }
}
