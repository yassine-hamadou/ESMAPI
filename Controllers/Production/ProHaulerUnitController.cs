using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProHaulerUnits;

namespace ServiceManagerApi.Controllers.Production
{
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
                .ToListAsync();
            return prohaulerUnits;
        }

        // get by id
        [HttpGet("id")]
        [ProducesResponseType(typeof(ProhaulerUnit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var prohaulerUnit = await _context.ProhaulerUnits.FindAsync(id);
            if (prohaulerUnit == null)
            {
                return NotFound();
            }
            return Ok(prohaulerUnit);
        }

        // post groups
        [HttpPost]
        [ProducesResponseType(typeof(ProhaulerUnit), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(ProHaulerUnitPostDto proHaulerUnitPostDto)
        {
            ProhaulerUnit prohaulerUnit = _mapper.Map<ProhaulerUnit>(proHaulerUnitPostDto);

            _context.ProhaulerUnits.Add(prohaulerUnit);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProhaulerUnitExists(prohaulerUnit.Id))
                {
                    return Conflict();
                }

                throw;
            }
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

            _context.Entry(prohaulerUnit).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProhaulerUnitExists(id))
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

        private bool ProhaulerUnitExists(int id)
        {
            return _context.ProhaulerUnits.Any(e => e.Id == id);
        }
    }
}
