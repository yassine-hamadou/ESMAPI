using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.BacklogDto;

namespace ServiceManagerApi.Controllers.Esms;

[Route("api/[controller]")]
[ApiController]
public class BacklogsController : BaeApiController<BacklogsController>
{
  private readonly EnpDbContext _context;

  public BacklogsController(EnpDbContext context)
  {
    _context = context;
  }

  // GET: api/Backlog/tenant/{tenantId}
  [HttpGet("tenant/{tenantId}")]
  public async Task<ActionResult<IEnumerable<BacklogDto>>> GetBacklog(string tenantId)
  {
    if (_context.Backlogs == null) return NotFound();
    //get all backlog items for a tenant
    var backlogDtos = _mapper.Map<List<BacklogDto>>(await _context.Backlogs
        .Where(backlog => backlog.TenantId == tenantId)
        .ToListAsync());
    return Ok(backlogDtos);
  }

  // GET: api/Backlog/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Backlog>> GetBacklog(int id)
  {
    if (_context.Backlogs == null) return NotFound();
    var backlog = await _context.Backlogs.FindAsync(id);

    if (backlog == null) return NotFound();

    return backlog;
  }

  // PUT: api/Backlogs/5
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id}")]
  public async Task<IActionResult> PutBacklog(int id, BacklogPutDto backlogPutDto)
  {
    if (id != backlogPutDto.Id) return BadRequest();

    var backlog = _mapper.Map<Backlog>(backlogPutDto);
    _context.Entry(backlog).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!BacklogExists(id))
        return NotFound();
      else
        throw;
    }

    return NoContent();
  }

  // POST: api/Backlog
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<Backlog>> PostBacklog(BacklogPostDto backlogPostDto)
  {
    if (_context.Backlogs == null) return Problem("Entity set 'EnpDbContext.Backlogs'  is null.");

    var backlog = _mapper.Map<Backlog>(backlogPostDto);
    _context.Backlogs.Add(backlog);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetBacklog", new { id = backlog.Id }, backlog);
  }

  // DELETE: api/Backlogs/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteBacklogs(int id)
  {
    if (_context.Backlogs == null) return NotFound();
    var backlog = await _context.Backlogs.FindAsync(id);
    if (backlog == null) return NotFound();

    _context.Backlogs.Remove(backlog);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool BacklogExists(int id)
  {
    return (_context.Backlogs?.Any(e => e.Id == id)).GetValueOrDefault();
  }
}