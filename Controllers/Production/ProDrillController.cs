using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProDrill;

namespace ServiceManagerApi.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProDrillController : BaeApiController<ProDrill>
    {
        private readonly EnpDbContext _context;

        public ProDrillController(EnpDbContext context)
        {
            _context = context;
        }

        // GET: api/ProDrill
        [HttpGet("tenant/{tenantId}")]
        public Task<List<ProDrill>> GetProDrill(string tenantId)
        {
            var proDrills = _context.ProDrills
                .Where(leav => leav.TenantId == tenantId)
                .Select(h => new ProDrill
                {
                    Id = h.Id,
                    EquipmentId = h.EquipmentId,
                    ModelName = h.ModelName,
                    Description = h.Description,
                    TenantId = h.TenantId,
                    Equipment = new Equipment
                    {
                        Id = h.Equipment.Id,
                        EquipmentId = h.Equipment.EquipmentId,
                        Description = h.Equipment.Description,
                        Model = new Model
                        {
                            ModelId = h.Equipment.Model.ModelId,
                            Name = h.Equipment.Model.Name,
                        }
                    }
                })
                .ToListAsync();
            return proDrills;
        }

        // GET: api/ProDrill/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProDrill), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            if (_context.ProDrills == null)
            {
                return NotFound();
            }

            var proDrill = await _context.ProDrills.FindAsync(id);
            if (proDrill == null)
            {
                return NotFound();
            }

            return Ok(proDrill);
        }

        // PUT: api/ProDrill/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutProDrill(int id, ProDrill proDrill)
        {
            if (id != proDrill.Id)
            {
                return BadRequest();
            }

            _context.Entry(proDrill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProDrillExists(proDrill.EquipmentId))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/ProDrill
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(ProDrill), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(ProDrillPostDto proDrillPostDto)
        {
            ProDrill proDrill = _mapper.Map<ProDrill>(proDrillPostDto);
            if (ProDrillExists(proDrill.EquipmentId))
            {
                return Conflict();
            }

            _context.ProDrills.Add(proDrill);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = proDrill.Id }, proDrill);
        }

        // DELETE: api/ProDrill/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProDrill(int id)
        {
            var proDrill = await _context.ProDrills.FindAsync(id);
            if (proDrill == null)
            {
                return NotFound();
            }

            _context.ProDrills.Remove(proDrill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProDrillExists(string equipmentId)
        {
            return _context.ProDrills.Any(e => e.EquipmentId.ToLower().Trim() == equipmentId.ToLower().Trim());
        }
    }
}