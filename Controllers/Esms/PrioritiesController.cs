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
public class PrioritiesController : ControllerBase
{
  private readonly EnpDbContext _context;

  public PrioritiesController(EnpDbContext context)
  {
    _context = context;
  }

  // GET: api/Priorities/tentant/{tenantId}
  [HttpGet("tenant/{tenantId}")]
  public async Task<ActionResult<IEnumerable<PrioritySetup>>> GetPrioritySetups(string tenantId)
  {
    if (_context.PrioritySetups == null) return NotFound();
    return await _context.PrioritySetups.Where(p => p.TenantId == tenantId).ToListAsync();
  }

  // GET: api/Priorities/5
  [HttpGet("{id}")]
  public async Task<ActionResult<PrioritySetup>> GetPrioritySetup(int id)
  {
    if (_context.PrioritySetups == null) return NotFound();
    var prioritySetup = await _context.PrioritySetups.FindAsync(id);

    if (prioritySetup == null) return NotFound();

    return prioritySetup;
  }

  // PUT: api/Priorities/5
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id}")]
  public async Task<IActionResult> PutPrioritySetup(int id, PrioritySetup prioritySetup)
  {
    if (id != prioritySetup.PriorityId) return BadRequest();

    _context.Entry(prioritySetup).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!PrioritySetupExists(id))
        return NotFound();
      else
        throw;
    }

    return NoContent();
  }

  // POST: api/Priorities
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<PrioritySetup>> PostPrioritySetup(PrioritySetup prioritySetup)
  {
    if (_context.PrioritySetups == null) return Problem("Entity set 'EnpDbContext.PrioritySetups'  is null.");
    _context.PrioritySetups.Add(prioritySetup);
    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateException)
    {
      if (PrioritySetupExists(prioritySetup.PriorityId))
        return Conflict();
      else
        throw;
    }

    return CreatedAtAction("GetPrioritySetup", new { id = prioritySetup.PriorityId }, prioritySetup);
  }

  // DELETE: api/Priorities/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeletePrioritySetup(int id)
  {
    if (_context.PrioritySetups == null) return NotFound();
    var prioritySetup = await _context.PrioritySetups.FindAsync(id);
    if (prioritySetup == null) return NotFound();

    _context.PrioritySetups.Remove(prioritySetup);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool PrioritySetupExists(int id)
  {
    return (_context.PrioritySetups?.Any(e => e.PriorityId == id)).GetValueOrDefault();
  }
}