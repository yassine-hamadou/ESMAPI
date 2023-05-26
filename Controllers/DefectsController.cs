using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;

namespace ServiceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefectsController : ControllerBase
    {
        private readonly EnpDbContext _context;

        public DefectsController(EnpDbContext context)
        {
            _context = context;
        }

        [HttpGet("tenant/{tenantId}")]
        public Task<List<DefectEntry>> GetDefectEntries(string tenantId)
        {
            var defectEntries = _context.DefectEntries.Where(leav => leav.TenantId == tenantId).ToListAsync();
            return defectEntries;
        }

        // GET: api/Defects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DefectEntry>> GetDefectEntry(int id)
        {
          if (_context.DefectEntries == null)
          {
              return NotFound();
          }
            var defectEntry = await _context.DefectEntries.FindAsync(id);

            if (defectEntry == null)
            {
                return NotFound();
            }

            return defectEntry;
        }

        // PUT: api/Defects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDefectEntry(int id, DefectEntry defectEntry)
        {
            if (id != defectEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(defectEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DefectEntryExists(id))
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

        // POST: api/Defects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DefectEntry>> PostDefectEntry(DefectEntry defectEntry)
        {
          if (_context.DefectEntries == null)
          {
              return Problem("Entity set 'EnpDBContext.DefectEntries'  is null.");
          }
            _context.DefectEntries.Add(defectEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDefectEntry", new { id = defectEntry.Id }, defectEntry);
        }

        // DELETE: api/Defects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDefectEntry(int id)
        {
            if (_context.DefectEntries == null)
            {
                return NotFound();
            }
            var defectEntry = await _context.DefectEntries.FindAsync(id);
            if (defectEntry == null)
            {
                return NotFound();
            }

            _context.DefectEntries.Remove(defectEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DefectEntryExists(int id)
        {
            return (_context.DefectEntries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
