using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Controllers.Esms;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProLoaderUnits;

namespace ServiceManagerApi.Controllers.Production;
[Route("api/[controller]")]
[ApiController]
    public class ProLoaderUnitController : BaeApiController<ProLoaderUnitController>
    {
        private readonly EnpDbContext _context;

        public ProLoaderUnitController(EnpDbContext context)
        {
            _context = context;
        }

        [HttpGet("tenant/{tenantId}")]
        public Task<List<ProloaderUnit>> GetProloaderUnits(string tenantId)
        {
            var proloaderUnits = _context.ProloaderUnits
                .Where(leav => leav.TenantId == tenantId)
                /*.Select(h => new ProloaderUnit
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
                })*/
                .ToListAsync();

            return proloaderUnits;
        }

        // get by id
        [HttpGet("id")]
        [ProducesResponseType(typeof(ProloaderUnit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProloaderUnit>> GetById(int id)
        {
            var ProloaderUnit = await _context.ProloaderUnits.FindAsync(id);
            if (ProloaderUnit == null)
            {
                return NotFound();
            }

            return ProloaderUnit;
        }

        // post groups
        [HttpPost]
        [ProducesResponseType(typeof(ProloaderUnit), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProloaderUnit>> Create(ProLoaderUnitPostDto proLoaderUnitPostDto)
        {
            ProloaderUnit proloaderUnit = _mapper.Map<ProloaderUnit>(proLoaderUnitPostDto);

            if (ProloaderUnitExists(proloaderUnit.EquipmentId))
            {
                return Conflict();
            }

            _context.ProloaderUnits.Add(proloaderUnit);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = proloaderUnit.Id }, proloaderUnit);
        }

        // put groups
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, ProloaderUnit proloaderUnit)
        {
            if (id != proloaderUnit.Id)
            {
                return BadRequest();
            }

            _context.Entry(proloaderUnit).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProloaderUnitExistsById(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // delete groups
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var proloaderUnit = await _context.ProloaderUnits.FindAsync(id);
            if (proloaderUnit == null)
            {
                return NotFound();
            }

            _context.ProloaderUnits.Remove(proloaderUnit);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ProloaderUnitExists(string equipmentId)
        {
            return _context.ProloaderUnits.Any(e => e.EquipmentId.ToLower().Trim() == equipmentId.ToLower().Trim());
        }

        private bool ProloaderUnitExistsById(int id)
        {
            return (_context.ProloaderUnits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
