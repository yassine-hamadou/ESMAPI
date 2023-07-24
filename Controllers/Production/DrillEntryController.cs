using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;

namespace ServiceManagerApi.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillEntryController : ControllerBase
    {
        private readonly EnpDbContext _context;

        public DrillEntryController(EnpDbContext context)
        {
            _context = context;
        }

        // GET: api/DrillEntry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrillEntry>>> GetDrillEntries()
        {
          if (_context.DrillEntries == null)
          {
              return NotFound();
          }
            return await _context.DrillEntries.ToListAsync();
        }

        // GET: api/DrillEntry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DrillEntry>> GetDrillEntry(int id)
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

            return drillEntry;
        }

        // PUT: api/DrillEntry/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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
        public async Task<ActionResult<DrillEntry>> PostDrillEntry(DrillEntry drillEntry)
        {
          if (_context.DrillEntries == null)
          {
              return Problem("Entity set 'EnpDbContext.DrillEntries'  is null.");
          }
            _context.DrillEntries.Add(drillEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrillEntry", new { id = drillEntry.Id }, drillEntry);
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
