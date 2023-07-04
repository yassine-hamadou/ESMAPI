using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.BacklogDto;

namespace ServiceManagerApi.Controllers.Esms;

[Route("api/[controller]")]
[ApiController]
public class BacklogsController : BaeApiController<BacklogsController>
{
  private readonly IMemoryCache _cache;
  private readonly EnpDbContext _context;
  private readonly ILogger<BacklogsController> _logger;

  public BacklogsController(EnpDbContext context, ILogger<BacklogsController> logger, IMemoryCache cache)
  {
    _context = context;
    _logger = logger;
    _cache = cache;
  }

  // GET: api/Backlog/tenant/{tenantId}
  [HttpGet("tenant/{tenantId}")]
  public async Task<ActionResult<IEnumerable<BacklogDto>>> GetBacklog(string tenantId)
  {
    if (_cache.TryGetValue($"backlogs", out List<BacklogDto> backlogDtos))
    {
      _logger.LogInformation(
          $"BacklogController.GetBacklog: {backlogDtos.Count} backlog items found for all tenants from cache");
      var backlogDtosForSingleTenant = backlogDtos.FindAll(backlog => backlog.TenantId == tenantId);
      return Ok(backlogDtosForSingleTenant);
    }
    else
    {
      if (_context.Backlogs == null) return NotFound();
      //get all backlog items for all tenants
      var backlogDtosFromDb = _mapper.Map<List<BacklogDto>>(await _context.Backlogs
          .ToListAsync());

      //cache the backlog items for all tenants
      var cacheEntryOptions = new MemoryCacheEntryOptions()
          .SetSlidingExpiration(TimeSpan.FromDays(2))
          .SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
          .SetPriority(CacheItemPriority.Normal);

      _cache.Set($"backlogs", backlogDtosFromDb, cacheEntryOptions);

      _logger.LogInformation(
          $"BacklogController.GetBacklog: {backlogDtosFromDb.Count} backlog items found from DB");

      var backlogDtosFromDbSingleTenant = backlogDtosFromDb.FindAll(backlog => backlog.TenantId == tenantId);
      return Ok(backlogDtosFromDbSingleTenant);
    }
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
      _cache.Remove($"backlogs");
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

    //clear the cache
    _logger.LogInformation($"BacklogController.PostBacklog: Clearing cache for 'backlogs'");
    _cache.Remove($"backlogs");

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