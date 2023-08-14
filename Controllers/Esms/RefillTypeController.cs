using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.RefillTypes;

namespace ServiceManagerApi.Controllers.Esms;

[Route("api/[controller]")]
[ApiController]
public class RefillTypeController : BaeApiController<RefillTypeController>
{
  private readonly EnpDbContext _context;

  public RefillTypeController(EnpDbContext context)
  {
    _context = context;
  }

  [HttpGet("tenant/{tenantId}")]
  [ProducesResponseType(typeof(RefillType), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IEnumerable<RefillType>> Get(string tenantId)
  {
    return await _context.RefillTypes
        // .Where(refillType => refillType.TenantId == tenantId)
        .ToListAsync();
  }

  [HttpGet("id")]
  [ProducesResponseType(typeof(RefillType), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetById(int id)
  {
    var refillType = await _context.RefillTypes.FindAsync(id);
    if (refillType == null) return NotFound();

    return Ok(refillType);
  }

  [HttpPost]
  public async Task<IActionResult> Create(RefillTypePostDto refillTypeDto)
  {
    var refillType = _mapper.Map<RefillType>(refillTypeDto);

    _context.RefillTypes.Add(refillType);
    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateException)
    {
      if (RefillTypeExists(refillType.Id))
        return Conflict();
      else
        throw;
    }

    return CreatedAtAction(nameof(GetById), new { id = refillType.Id }, refillType);
  }

  [HttpPut("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Put(int id, RefillType refillType)
  {
    if (id != refillType.Id) return BadRequest();


    _context.Entry(refillType).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!RefillTypeExists(id))
        return NotFound();
      else
        throw;
    }

    return NoContent();
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Delete(int id)
  {
    var refillTypeToDelete = await _context.RefillTypes.FindAsync(id);
    if (refillTypeToDelete == null) return NotFound();
    _context.RefillTypes.Remove(refillTypeToDelete);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool RefillTypeExists(int id)
  {
    return _context.RefillTypes.Any(e => e.Id == id);
  }
}