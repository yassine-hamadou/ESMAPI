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
public class LocationsController : ControllerBase
{
  private readonly EnpDbContext _context;

  public LocationsController(EnpDbContext context)
  {
    _context = context;
  }

  // GET: api/Locations/tenant/{tenantId}
  [HttpGet("tenant/{tenantId}")]
  public async Task<ActionResult<IEnumerable<Location>>> GetLocations(string tenantId)
  {
    if (_context.Locations == null) return NotFound();
    return await _context.Locations.Where(loc => loc.TenantId == tenantId).ToListAsync();
  }

  // GET: api/Locations/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Location>> GetLocation(int id)
  {
    if (_context.Locations == null) return NotFound();
    var location = await _context.Locations.FindAsync(id);

    if (location == null) return NotFound();

    return location;
  }

  // PUT: api/Locations/5
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id}")]
  public async Task<IActionResult> PutLocation(int id, Location location)
  {
    if (id != location.Id) return BadRequest();

    _context.Entry(location).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!LocationExists(id))
        return NotFound();
      else
        throw;
    }

    return NoContent();
  }

  // POST: api/Locations
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<Location>> PostLocation(Location location)
  {
    if (_context.Locations == null) return Problem("Entity set 'EnpDbContext.Locations'  is null.");
    _context.Locations.Add(location);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetLocation", new { id = location.Id }, location);
  }

  // DELETE: api/Locations/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteLocation(int id)
  {
    if (_context.Locations == null) return NotFound();
    var location = await _context.Locations.FindAsync(id);
    if (location == null) return NotFound();

    _context.Locations.Remove(location);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool LocationExists(int id)
  {
    return (_context.Locations?.Any(e => e.Id == id)).GetValueOrDefault();
  }
}