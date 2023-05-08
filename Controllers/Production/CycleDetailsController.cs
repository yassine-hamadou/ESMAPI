using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;

namespace ServiceManagerApi.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class CycleDetailsController : ControllerBase
    {
        private readonly EnpDbContext _context;

        public CycleDetailsController(EnpDbContext context)
        {
            _context = context;
        }

        

        [HttpGet("tenant/{tenantId}")]
        public Task<List<CycleDetail>> GetCycleDetails(string tenantId)
        {
            var cycleDetails = _context.CycleDetails.Where(leav => leav.TenantId == tenantId).ToListAsync();

            return cycleDetails;
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
        public async Task<IActionResult> PutCycleDetail(int id, CycleDetail cycleDetail)
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
                else
                {
                    throw;
                }
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
