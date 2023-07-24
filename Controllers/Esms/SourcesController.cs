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
public class SourcesController : ControllerBase
{
  private readonly EnpDbContext _context;

  public SourcesController(EnpDbContext context)
  {
    _context = context;
  }

  // GET: api/Sources/tenant/{tenantId}
  [HttpGet("tenant/{tenantId}")]
  public async Task<ActionResult<IEnumerable<Source>>> GetSources(string tenantId)
  {
    if (_context.Sources == null) return NotFound();
    return await _context.Sources.Where(s => s.TenantId == tenantId).ToListAsync();
  }

  // GET: api/Sources/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Source>> GetSource(int id)
  {
    if (_context.Sources == null) return NotFound();
    var source = await _context.Sources.FindAsync(id);

    if (source == null) return NotFound();

    return source;
  }

  // PUT: api/Sources/5
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id}")]
  public async Task<IActionResult> PutSource(int id, Source source)
  {
    if (id != source.Id) return BadRequest();

    _context.Entry(source).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!SourceExists(id))
        return NotFound();
      else
        throw;
    }

    return NoContent();
  }

  // POST: api/Sources
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<Source>> PostSource(Source source)
  {
    if (_context.Sources == null) return Problem("Entity set 'EnpDbContext.Sources'  is null.");
    _context.Sources.Add(source);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetSource", new { id = source.Id }, source);
  }

  // DELETE: api/Sources/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteSource(int id)
  {
    if (_context.Sources == null) return NotFound();
    var source = await _context.Sources.FindAsync(id);
    if (source == null) return NotFound();

    _context.Sources.Remove(source);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool SourceExists(int id)
  {
    return (_context.Sources?.Any(e => e.Id == id)).GetValueOrDefault();
  }
}