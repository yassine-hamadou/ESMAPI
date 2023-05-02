using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProHaulerUnits;

namespace ServiceManagerApi.Controllers.Production
{
    public class ProHaulerUnitController : BaeApiController<ProHaulerUnitController>
    {
        private readonly EnpDBContext _context;
        public ProHaulerUnitController(EnpDBContext context)
        {
            _context = context;
        }
        //get list
        [HttpGet]
        [ProducesResponseType(typeof(ProhaulerUnit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<ProhaulerUnit>> Get()
        {
            return await _context.ProhaulerUnits.ToListAsync();
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
        public async Task<IActionResult> Create(ProHaulerUnitDto proHaulerUnitDto)
        {
            ProhaulerUnit prohaulerUnit = _mapper.Map<ProhaulerUnit>(proHaulerUnitDto);

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
                else
                {
                    throw;
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = prohaulerUnit.Id }, prohaulerUnit);
        }

        // put groups
        [HttpPut]
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
                if (!ProhaulerUnitExists(prohaulerUnit.Id))
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

        // delete groups
        [HttpDelete]
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
