using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;

namespace ServiceManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FleetSchedulesApiController : ControllerBase
    {
        private readonly EnpDbContext _context;

        public FleetSchedulesApiController(EnpDbContext context)
        {
            _context = context;
        }

        // GET: api/FleetSchedulesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FleetSchedule>>> GetFleetSchedules()
        {
            return await _context.FleetSchedules.ToListAsync();
        }

        // GET: api/FleetSchedulesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FleetSchedule>> GetFleetSchedule(long id)
        {
            var fleetSchedule = await _context.FleetSchedules.FindAsync(id);

            var fleetSchedule1 = await _context.FleetSchedules.FindAsync(id);

            if (fleetSchedule == null)
            {
                return NotFound();
            }

            return fleetSchedule;
        }

        // PUT: api/FleetSchedulesApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFleetSchedule(long id, FleetSchedule fleetSchedule)
        {
            if (id != fleetSchedule.EntryId)
            {
                return BadRequest();
            }

            _context.Entry(fleetSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FleetScheduleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FleetSchedulesApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FleetSchedule>> PostFleetSchedule(FleetSchedule fleetSchedule)
        {
            _context.FleetSchedules.Add(fleetSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFleetSchedule", new { id = fleetSchedule.EntryId }, fleetSchedule);
        }

        // DELETE: api/FleetSchedulesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFleetSchedule(long id)
        {
            var fleetSchedule = await _context.FleetSchedules.FindAsync(id);
            if (fleetSchedule == null)
            {
                return NotFound();
            }

            _context.FleetSchedules.Remove(fleetSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FleetScheduleExists(long id)
        {
            return _context.FleetSchedules.Any(e => e.EntryId == id);
        }
    }
}
