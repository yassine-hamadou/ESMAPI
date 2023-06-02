using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;

namespace ServiceManagerApi.Controllers.Esms
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgreementsController : ControllerBase
    {
        private readonly EnpDbContext _context;

        public AgreementsController(EnpDbContext context)
        {
            _context = context;
        }

        // GET: api/Agreements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agreement>>> GetAgreements()
        {
            if (_context.Agreements == null)
            {
                return NotFound();
            }
            return await _context.Agreements.ToListAsync();
        }


        //[HttpGet("tenant/{tenantId}")]
        //public Task<List<Agreement>> GetAppraisals(string tenantId)
        //{
        //    var agreements = _context.Agreements.Where(leav => leav.TenantId == tenantId).ToListAsync();

        //    return agreements;
        //}

        // GET: api/Agreements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agreement>> GetAgreement(int id)
        {
          if (_context.Agreements == null)
          {
              return NotFound();
          }
            var agreement = await _context.Agreements.FindAsync(id);

            if (agreement == null)
            {
                return NotFound();
            }

            return agreement;
        }

        // PUT: api/Agreements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgreement(int id, Agreement agreement)
        {
            if (id != agreement.Id)
            {
                return BadRequest();
            }

            _context.Entry(agreement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgreementExists(id))
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

        // POST: api/Agreements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Agreement>> PostAgreement(Agreement agreement)
        {
          if (_context.Agreements == null)
          {
              return Problem("Entity set 'EnpDBContext.Agreements'  is null.");
          }
            _context.Agreements.Add(agreement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgreement", new { id = agreement.Id }, agreement);
        }

        // DELETE: api/Agreements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgreement(int id)
        {
            if (_context.Agreements == null)
            {
                return NotFound();
            }
            var agreement = await _context.Agreements.FindAsync(id);
            if (agreement == null)
            {
                return NotFound();
            }

            _context.Agreements.Remove(agreement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgreementExists(int id)
        {
            return (_context.Agreements?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
