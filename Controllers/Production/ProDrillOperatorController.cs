using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Controllers.Esms;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProDrill;

namespace ServiceManagerApi.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProDrillOperatorController : BaeApiController<ProDrillOperator>
    {
        private readonly EnpDbContext _context;

        public ProDrillOperatorController(EnpDbContext context)
        {
            _context = context;
        }

        // GET: api/ProDrillOperator
        [HttpGet("tenant/{tenantId}")]
        public Task<List<ProDrillOperator>> GetProDrillOperators(string tenantId)
        {
            var proDrillOperators = _context.ProDrillOperators.Where(leav => leav.TenantId == tenantId).ToListAsync();
            return proDrillOperators;
        }

        // GET: api/ProDrillOperator/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProDrillOperator), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProDrillOperator>> GetProDrillOperator(int id)
        {
            var proDrillOperator = await _context.ProDrillOperators.FindAsync(id);
            if (proDrillOperator == null)
            {
                return NotFound();
            }

            return proDrillOperator;
        }

        // POST: api/ProDrillOperator
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(ProDrillOperator), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostProDrillOperator(ProDrillOperatorDto proDrillOperatorDto)
        {
            ProDrillOperator proDrillOperator = _mapper.Map<ProDrillOperator>(proDrillOperatorDto);
            if (ProDrillOperatorExists(proDrillOperator))
            {
                return Conflict();
            }

            _context.ProDrillOperators.Add(proDrillOperator);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProDrillOperator), new { id = proDrillOperator.Id }, proDrillOperator);
        }


        // PUT: api/ProDrillOperator/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProDrillOperator(int id, ProDrillOperator proDrillOperator)
        {
            if (id != proDrillOperator.Id)
            {
                return BadRequest();
            }

            _context.Entry(proDrillOperator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProDrillOperatorExists(proDrillOperator))
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


        // DELETE: api/ProDrillOperator/5
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteProDrillOperator(string code)
        {
            var proDrillOperator = await _context.ProDrillOperators.FindAsync(code);
            if (proDrillOperator == null)
            {
                return NotFound();
            }

            _context.ProDrillOperators.Remove(proDrillOperator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProDrillOperatorExists(ProDrillOperator proDrillOperator)
        {
            return (_context.ProDrillOperators?.Any(e => 
                    e.Code.ToLower().Trim() == proDrillOperator.Code.ToLower().Trim() &&
                    e.TenantId.ToLower().Trim() == proDrillOperator.TenantId.ToLower().Trim() &&
                    e.Name.ToLower().Trim() == proDrillOperator.Name.ToLower().Trim()
                ))
                .GetValueOrDefault();
        }
    }
}