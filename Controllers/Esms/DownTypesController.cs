using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;

namespace ServiceManagerApi.Controllers.Esms;

[Route("api/[controller]")]
[ApiController]
public class DownTypesController : ControllerBase
{
  private readonly EnpDbContext _context;

  public DownTypesController(EnpDbContext context)
  {
    _context = context;
  }

  // GET: api/DownTypes/tenant/{tenantId}
  [HttpGet("tenant/{tenantId}")]
  public async Task<ActionResult<IEnumerable<DownType>>> GetDownTypes(string tenantId)
  {
    if (_context.DownTypes == null) return NotFound();
    return await _context.DownTypes.Where(d => d.TenantId == tenantId).ToListAsync();
  }

  // GET: api/DownTypes/5
  [HttpGet("{id}")]
  public async Task<ActionResult<DownType>> GetDownType(int id)
  {
    if (_context.DownTypes == null) return NotFound();
    var downType = await _context.DownTypes.FindAsync(id);

    if (downType == null) return NotFound();

    return downType;
  }

  // PUT: api/DownTypes/5
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id}")]
  public async Task<IActionResult> PutDownType(int id, DownType downType)
  {
    if (id != downType.Id) return BadRequest();

    _context.Entry(downType).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!DownTypeExists(id))
        return NotFound();
      else
        throw;
    }

    return NoContent();
  }

  // POST: api/DownTypes
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<DownType>> PostDownType(DownType downType)
  {
    if (_context.DownTypes == null) return Problem("Entity set 'EnpDbContext.DownTypes'  is null.");
    _context.DownTypes.Add(downType);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetDownType", new { id = downType.Id }, downType);
  }

  // DELETE: api/DownTypes/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteDownType(int id)
  {
    if (_context.DownTypes == null) return NotFound();
    var downType = await _context.DownTypes.FindAsync(id);
    if (downType == null) return NotFound();

    _context.DownTypes.Remove(downType);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool DownTypeExists(int id)
  {
    return (_context.DownTypes?.Any(e => e.Id == id)).GetValueOrDefault();
  }
}