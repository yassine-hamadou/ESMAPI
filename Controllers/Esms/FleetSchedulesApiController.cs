using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.FleetSchedule;

namespace ServiceManagerApi.Controllers.Esms;

[Route("api/[controller]")]
[ApiController]
public class FleetSchedulesApiController : BaeApiController<FleetSchedulesApiController>
{
  private readonly EnpDbContext _context;

  public FleetSchedulesApiController(EnpDbContext context)
  {
    _context = context;
  }

  // GET: api/FleetSchedulesApi/tenant/tarkwa
  [HttpGet("tenant/{tenantId}")]
  public async Task<ActionResult<IEnumerable<FleetSchedule>>> GetFleetSchedules(string tenantId)
  {
    return await _context
        .FleetSchedules
        .Where(fleetSchedule => fleetSchedule.TenantId == tenantId)
        .Select(fleetSchedule => new FleetSchedule()
        {
            EntryId = fleetSchedule.EntryId,
            FleetId = fleetSchedule.FleetId,
            VmModel = fleetSchedule.VmModel,
            VmClass = fleetSchedule.VmClass,
            ServiceTypeId = fleetSchedule.ServiceTypeId,
            LocationId = fleetSchedule.LocationId,
            Description = fleetSchedule.Description,
            TimeStart = fleetSchedule.TimeStart,
            TimeEnd = fleetSchedule.TimeEnd,
            Responsible = fleetSchedule.Responsible,
            ReferenceId = fleetSchedule.ReferenceId,
            TenantId = fleetSchedule.TenantId,
            ServiceType = new Service()
            {
                Id = fleetSchedule.ServiceType.Id,
                Name = fleetSchedule.ServiceType.Name,
                Model = fleetSchedule.ServiceType.Model
            }
        })
        .ToListAsync();
  }

  // GET: api/FleetSchedulesApi/5
  [HttpGet("{id}")]
  public async Task<ActionResult<FleetSchedule>> GetFleetSchedule(long id)
  {
    var fleetSchedule = await _context.FleetSchedules.FindAsync(id);

    var fleetSchedule1 = await _context.FleetSchedules.FindAsync(id);

    if (fleetSchedule == null) return NotFound();

    return fleetSchedule;
  }

  // PUT: api/FleetSchedulesApi/5
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id}")]
  public async Task<IActionResult> PutFleetSchedule(long id, FleetSchedule fleetSchedule)
  {
    if (id != fleetSchedule.EntryId) return BadRequest();

    _context.Entry(fleetSchedule).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!FleetScheduleExists(id))
        return NotFound();
      else
        throw;
    }

    return NoContent();
  }

  // POST: api/FleetSchedulesApi
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<FleetSchedule>> PostFleetSchedule(FleetSchedulePostDto fleetSchedulePostDto)
  {
    if (_context.FleetSchedules == null) return Problem("Entity set 'EnpDBContext.FleetSchedule'  is null.");
    var fleetSchedule = _mapper.Map<FleetSchedule>(fleetSchedulePostDto);
    _context.FleetSchedules.Add(fleetSchedule);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetFleetSchedule", new { id = fleetSchedule.EntryId }, fleetSchedule);
  }

  // DELETE: api/FleetSchedulesApi/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteFleetSchedule(long id)
  {
    var fleetSchedule = await _context.FleetSchedules.FindAsync(id);
    if (fleetSchedule == null) return NotFound();

    _context.FleetSchedules.Remove(fleetSchedule);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool FleetScheduleExists(long id)
  {
    return _context.FleetSchedules.Any(e => e.EntryId == id);
  }
}