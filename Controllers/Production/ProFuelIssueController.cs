using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.FuelIntake;

namespace ServiceManagerApi.Controllers.Production
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProFuelIssueController : BaeApiController<ProFuelIssueController>
    {
        private readonly EnpDbContext _context;

        public ProFuelIssueController(EnpDbContext context)
        {
            _context = context;
        }

        // GET: api/ProFuelIssue
        [HttpGet("tenant/{tenantId}")]
        public Task<List<ProFuelIntake>> GetProFuelIntakes(string tenantId)
        {
            var proFuelIntakes = _context.ProFuelIntakes
                .Where(leav => leav.TenantId == tenantId && leav.TransactionType == "Fuel Issue")
                .ToListAsync();
          
            return proFuelIntakes;
        }

        // GET: api/ProFuelIssue/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProFuelIntake), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var proFuelIntake = await _context.ProFuelIntakes.FindAsync(id);
          
            if (proFuelIntake == null)
            {
                return NotFound();
            }

            return Ok(proFuelIntake);
        }

        // PUT: api/ProFuelIssue/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, ProFuelIntake proFuelIntake)
        {
            if (id != proFuelIntake.Id)
            {
                return BadRequest();
            }

            _context.Entry(proFuelIntake).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProFuelIntakeExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/ProFuelIssue
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(ProFuelIntake), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(IEnumerable<ProFuelIssuePostDto> proFuelIssuePostDtos)
        {
            try
            {
                var proFuelIntake = _mapper.Map<IEnumerable<ProFuelIntake>>(proFuelIssuePostDtos);
                _context.ProFuelIntakes.AddRange(proFuelIntake);

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                throw new ApplicationException("Error saving cycle details", ex);
            }
        }

        // DELETE: api/ProFuelIssue/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProFuelIntake(int id)
        {
            var proFuelIntake = await _context.ProFuelIntakes.FindAsync(id);
            
            if (proFuelIntake == null)
            {
                return NotFound();
            }
            _context.ProFuelIntakes.Remove(proFuelIntake);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProFuelIntakeExists(int id)
        {
            return (_context.ProFuelIntakes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private bool IsProFuelIssuePostDtoExist(ProFuelIssuePostDto proFuelIssuePostDto)
        {
            // Perform a database query to check if a matching ProductionActivity exists based on the properties in the ProductionActivityPostDto
            return _context.ProFuelIntakes.Any(e => 
                e.PumpId == proFuelIssuePostDto.PumpId &&
                e.TenantId == proFuelIssuePostDto.TenantId &&
                e.TransactionType == proFuelIssuePostDto.TransactionType &&
                e.IntakeDate == proFuelIssuePostDto.IntakeDate &&
                e.EquipmentId == proFuelIssuePostDto.EquipmentId 
            );
        }
    }
}
