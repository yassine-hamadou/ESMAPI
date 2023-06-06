using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;

namespace ServiceManagerApi.Controllers.Esms
{
    [Route("api/[controller]")]
    [ApiController]
    public class HourliesApiController : ControllerBase
    {
        private readonly EnpDbContext _context;

        public HourliesApiController(EnpDbContext context)
        {
            _context = context;
        }

        // GET: api/HourliesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hourly>>> GetHourlies()
        {
            return await _context.Hourlies.ToListAsync();
        }

        // GET: api/HourliesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hourly>> GetHourly(long id)
        {
            var hourly = await _context.Hourlies.FindAsync(id);

            if (hourly == null)
            {
                return NotFound();
            }

            return hourly;
        }

        // PUT: api/HourliesApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHourly(long id, Hourly hourly)
        {
            if (id != hourly.EntryId)
            {
                return BadRequest();
            }

            _context.Entry(hourly).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HourlyExists(id))
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

        // POST: api/HourliesApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hourly>> PostHourly(Hourly hourly)
        {
            _context.Hourlies.Add(hourly);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHourly", new { id = hourly.EntryId }, hourly);
        }

        // DELETE: api/HourliesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHourly(long id)
        {
            var hourly = await _context.Hourlies.FindAsync(id);
            if (hourly == null)
            {
                return NotFound();
            }

            _context.Hourlies.Remove(hourly);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HourlyExists(long id)
        {
            return _context.Hourlies.Any(e => e.EntryId == id);
        }
    }
}
