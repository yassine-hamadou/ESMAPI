using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.Compartments;

namespace ServiceManagerApi.Controllers.Esms;

[Route("api/[controller]")]
[ApiController]
public class CompartmentController : BaeApiController<CompartmentController>
{
  private readonly EnpDbContext _context;

  public CompartmentController(EnpDbContext context)
  {
    _context = context;
  }


  //get list
  [HttpGet("tenant/{tenantId}")]
  [ProducesResponseType(typeof(Compartment), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IEnumerable<Compartment>> Get(string tenantId)
  {
    return await _context.Compartments.Where(compartment => compartment.TenantId == tenantId)
        .ToListAsync();
  }


  // get by id
  [HttpGet("id")]
  [ProducesResponseType(typeof(Compartment), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetById(int id)
  {
    var group = await _context.Compartments.FindAsync(id);
    if (group == null) return NotFound();

    return Ok(group);
  }

  // post groups
  [HttpPost]
  [ProducesResponseType(typeof(Compartment), StatusCodes.Status201Created)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> Create(CompartmentPostDto compartmentPostDto)
  {
    var compartment = _mapper.Map<Compartment>(compartmentPostDto);


    _context.Compartments.Add(compartment);
    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateException)
    {
      if (CompartmentExists(compartment.Id))
        return Conflict();
      else
        throw;
    }

    return CreatedAtAction(nameof(GetById), new { id = compartment.Id }, compartment);
  }

  // updates groups
  [HttpPut("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Put(int id, Compartment compartment)
  {
    if (id != compartment.Id) return BadRequest();


    _context.Entry(compartment).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!CompartmentExists(id))
        return NotFound();
      else
        throw;
    }

    return NoContent();
  }

  // delete compartment
  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Delete(int id)
  {
    var groupToDelete = await _context.Compartments.FindAsync(id);
    if (groupToDelete == null) return NotFound();
    _context.Compartments.Remove(groupToDelete);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool CompartmentExists(int id)
  {
    return _context.Compartments.Any(e => e.Id == id);
  }
}