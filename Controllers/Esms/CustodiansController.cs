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
public class CustodiansController : ControllerBase
{
  private readonly EnpDbContext _context;

  public CustodiansController(EnpDbContext context)
  {
    _context = context;
  }

  // GET: api/Custodians/tenant/{tenantId}
  [HttpGet("tenant/{tenantId}")]
  public async Task<ActionResult<IEnumerable<Custodian>>> GetCustodians(string tenantId)
  {
    if (_context.Custodians == null) return NotFound();
    return await _context.Custodians.Where(cust => cust.TenantId == tenantId).ToListAsync();
  }

  // GET: api/Custodians/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Custodian>> GetCustodian(int id)
  {
    if (_context.Custodians == null) return NotFound();
    var custodian = await _context.Custodians.FindAsync(id);

    if (custodian == null) return NotFound();

    return custodian;
  }

  // PUT: api/Custodians/5
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id}")]
  public async Task<IActionResult> PutCustodian(int id, Custodian custodian)
  {
    if (id != custodian.Id) return BadRequest();

    _context.Entry(custodian).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!CustodianExists(id))
        return NotFound();
      else
        throw;
    }

    return NoContent();
  }

  // POST: api/Custodians
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<Custodian>> PostCustodian(Custodian custodian)
  {
    if (_context.Custodians == null) return Problem("Entity set 'EnpDbContext.Custodians'  is null.");
    _context.Custodians.Add(custodian);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetCustodian", new { id = custodian.Id }, custodian);
  }

  // DELETE: api/Custodians/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteCustodian(int id)
  {
    if (_context.Custodians == null) return NotFound();
    var custodian = await _context.Custodians.FindAsync(id);
    if (custodian == null) return NotFound();

    _context.Custodians.Remove(custodian);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool CustodianExists(int id)
  {
    return (_context.Custodians?.Any(e => e.Id == id)).GetValueOrDefault();
  }
}