using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;

namespace ServiceManagerApi.Controllers.Esms;

[Route("api/[controller]")]
[ApiController]
public class DownStatusesController : ControllerBase
{
  private readonly EnpDbContext _context;

  public DownStatusesController(EnpDbContext context)
  {
    _context = context;
  }

  // GET: api/DownStatuses/tenant/{tenantId}
  [HttpGet("tenant/{tenantId}")]
  public async Task<ActionResult<IEnumerable<DownStatus>>> GetDownStatuses(string tenantId)
  {
    if (_context.DownStatuses == null) return NotFound();
    return await _context.DownStatuses.Where(down => down.TenantId == tenantId).ToListAsync();
  }

  // GET: api/DownStatuses/5
  [HttpGet("{id}")]
  public async Task<ActionResult<DownStatus>> GetDownStatus(int id)
  {
    if (_context.DownStatuses == null) return NotFound();
    var downStatus = await _context.DownStatuses.FindAsync(id);

    if (downStatus == null) return NotFound();

    return downStatus;
  }

  // PUT: api/DownStatuses/5
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id}")]
  public async Task<IActionResult> PutDownStatus(int id, DownStatus downStatus)
  {
    if (id != downStatus.Id) return BadRequest();

    _context.Entry(downStatus).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!DownStatusExists(id))
        return NotFound();
      else
        throw;
    }

    return NoContent();
  }

  // POST: api/DownStatuses
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<DownStatus>> PostDownStatus(DownStatus downStatus)
  {
    if (_context.DownStatuses == null) return Problem("Entity set 'EnpDbContext.DownStatuses'  is null.");
    _context.DownStatuses.Add(downStatus);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetDownStatus", new { id = downStatus.Id }, downStatus);
  }

  // DELETE: api/DownStatuses/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteDownStatus(int id)
  {
    if (_context.DownStatuses == null) return NotFound();
    var downStatus = await _context.DownStatuses.FindAsync(id);
    if (downStatus == null) return NotFound();

    _context.DownStatuses.Remove(downStatus);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool DownStatusExists(int id)
  {
    return (_context.DownStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
  }
}