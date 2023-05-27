using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.FuelIntake;

namespace ServiceManagerApi.Controllers.Production
{
    public class ProFuelIssueController : BaeApiController<ProFuelIssueController>
    {
        private readonly EnpDbContext _context;

        public ProFuelIssueController(EnpDbContext context)
        {
            _context = context;
        }

        [HttpGet("tenant/{tenantId}")]
        public Task<List<ProFuelIntake>> GetProFuelIntakes(string tenantId)
        {
            var proFuelIntakes = _context.ProFuelIntakes
                .Where(leav => leav.TenantId == tenantId && leav.TransactionType == "Fuel Issue")
                /*.Select(f => new ProFuelIntake
                {
                    Id = f.Id,
                    Quantity = f.Quantity,
                    TransactionType = f.TransactionType,
                    IntakeDate = f.IntakeDate,
                    BatchNumber = f.BatchNumber,
                    TenantId = f.TenantId,
                    PumpId = f.PumpId,
                    EquipmentId = f.EquipmentId,
                    Pump = new ProductionPump
                    {
                        Name = f.Pump.Name,
                        Id = f.Pump.Id,
                    },
                    Equipment = new Equipment
                    {
                        Id = f.Equipment.Id,
                        EquipmentId = f.Equipment.EquipmentId,
                        Description = f.Equipment.Description,
                    }
                })*/
                .ToListAsync();

            return proFuelIntakes;
        }


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
        
        
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<ProFuelIntake>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(IEnumerable<FuelIntakePostDto> fuelIntakePostDtos)
        {
            var proFuelIntake = _mapper.Map<IEnumerable<ProFuelIntake>>(fuelIntakePostDtos);
            _context.ProFuelIntakes.AddRange(proFuelIntake);

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateException)
            {
                if (true)
                {
                    throw new DbUpdateException("Error saving ProFuelIntake");
                }

                throw;
            }
            return CreatedAtAction(nameof(GetById), new { id = proFuelIntake.Select(cd => cd.Id) }, proFuelIntake);
        }

        // DELETE: api/ProFuelIntake/5
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
            return _context.ProFuelIntakes.Any(e => e.Id == id);
        }
    }
}