using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Controllers.Esms;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProHaulerUnits;

namespace ServiceManagerApi.Controllers.Production;

[Route("api/[controller]")]
[ApiController]
public class ProHaulerUnitController : BaeApiController<ProHaulerUnitController>
{
    private readonly EnpDbContext _context;

    public ProHaulerUnitController(EnpDbContext context)
    {
        _context = context;
    }


    [HttpGet("tenant/{tenantId}")]
    public Task<List<ProhaulerUnit>> GetProhaulerUnits(string tenantId)
    {
        var prohaulerUnits = _context.ProhaulerUnits
            .Where(leav => leav.TenantId == tenantId)
            /*.Include(e => e.Equipment)
            .Select(h => new ProhaulerUnit
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
        return prohaulerUnits;
    }

    // get by id
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProhaulerUnit), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProhaulerUnit>> GetById(int id)
    {
        var prohaulerUnit = await _context.ProhaulerUnits.FindAsync(id);
        if (prohaulerUnit == null)
        {
            return NotFound();
        }

        return prohaulerUnit;
    }

    // post groups
    [HttpPost]
    public async Task<ActionResult<ProhaulerUnit>> Create(ProHaulerUnitPostDto proHaulerUnitPostDto)
    {
        ProhaulerUnit prohaulerUnit = _mapper.Map<ProhaulerUnit>(proHaulerUnitPostDto);

        _context.ProhaulerUnits.Add(prohaulerUnit);
        if (ProhaulerUnitExists(prohaulerUnit.EquipmentId))
        {
            return Conflict();
        }

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = prohaulerUnit.Id }, prohaulerUnit);
    }

    // put groups
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, ProhaulerUnit prohaulerUnit)
    {
        if (id != prohaulerUnit.Id)
        {
            return BadRequest();
        }

        if (ProhaulerUnitExists(prohaulerUnit.EquipmentId))
        {
            return Problem("Entity already exist");
        }

        _context.Entry(prohaulerUnit).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProhaulerUnitExistsById(id))
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
        var prohaulerUnit = await _context.ProhaulerUnits.FindAsync(id);
        if (prohaulerUnit == null)
        {
            return NotFound();
        }

        _context.ProhaulerUnits.Remove(prohaulerUnit);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool ProhaulerUnitExists(string equipmentId)
    {
        return _context.ProhaulerUnits.Any(e => e.EquipmentId.ToLower().Trim() == equipmentId.ToLower().Trim());
    }

    private bool ProhaulerUnitExistsById(int id)
    {
        return (_context.ProhaulerUnits?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}