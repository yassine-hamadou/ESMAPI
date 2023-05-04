using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;

namespace ServiceManagerApi.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class CycleDetailsController : ControllerBase
    {
        private readonly EnpDBContext _context;

        public CycleDetailsController(EnpDBContext context)
        {
            _context = context;
        }

        // GET: api/CycleDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CycleDetail>>> GetCycleDetails()
        {
          if (_context.CycleDetails == null)
          {
              return NotFound();
          }
            return await _context.CycleDetails.ToListAsync();
        }

        // GET: api/CycleDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CycleDetail>> GetCycleDetail(int id)
        {
          if (_context.CycleDetails == null)
          {
              return NotFound();
          }
            var cycleDetail = await _context.CycleDetails.FindAsync(id);

            if (cycleDetail == null)
            {
                return NotFound();
            }

            return cycleDetail;
        }

        // PUT: api/CycleDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CycleDetail cycleDetail)
        {
            if (id != cycleDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(cycleDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CycleDetailExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/CycleDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CycleDetail>> PostCycleDetail(CycleDetail cycleDetail)
        {
          if (_context.CycleDetails == null)
          {
              return Problem("Entity set 'EnpDBContext.CycleDetails'  is null.");
          }
            _context.CycleDetails.Add(cycleDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CycleDetailExists(cycleDetail.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetCycleDetail), new { id = cycleDetail.Id }, cycleDetail);
        }

        // DELETE: api/CycleDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCycleDetail(int id)
        {
            if (_context.CycleDetails == null)
            {
                return NotFound();
            }
            var cycleDetail = await _context.CycleDetails.FindAsync(id);
            if (cycleDetail == null)
            {
                return NotFound();
            }

            _context.CycleDetails.Remove(cycleDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CycleDetailExists(int id)
        {
            return (_context.CycleDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
