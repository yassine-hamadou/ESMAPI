using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.PlannedOutput;

namespace ServiceManagerApi.Controllers.Production
{
    public class PlannedOutputController : BaeApiController<PlannedOutputController>
    {
        private readonly EnpDBContext _context;

        public PlannedOutputController(EnpDBContext context)
        {
            _context = context;
        }

        // GET: api/PlannedOutput
        [HttpGet]
        [ProducesResponseType(typeof(PlannedOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<PlannedOutput>> Get()
        {
            return await _context.PlannedOutputs.ToListAsync();
        }

        // GET: api/PlannedOutput/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PlannedOutput), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var plannedOutput = await _context.PlannedOutputs.FindAsync(id);
            if (plannedOutput == null)
            {
                return NotFound();
            }

            return Ok(plannedOutput);
        }

        // PUT: api/PlannedOutput/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, PlannedOutput plannedOutput)
        {
            if (id != plannedOutput.Id)
            {
                return BadRequest();
            }
            
            _context.Entry(plannedOutput).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlannedOutputExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/PlannedOutput
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(PlannedOutput), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(PlannedOutputPostDto plannedOutputPostDto)
        {
            PlannedOutput plannedOutput = _mapper.Map<PlannedOutput>(plannedOutputPostDto);

            _context.PlannedOutputs.Add(plannedOutput);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlannedOutputExists(plannedOutput.Id))
                {
                    return Conflict();
                }

                throw;
            }

            return CreatedAtAction(nameof(GetById), new { id = plannedOutput.Id }, plannedOutput);
        }


        // DELETE: api/PlannedOutput/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var plannedOutput = await _context.PlannedOutputs.FindAsync(id);
            if (plannedOutput == null) return NotFound();
            _context.PlannedOutputs.Remove(plannedOutput);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlannedOutputExists(int id)
        {
            return _context.PlannedOutputs.Any(e => e.Id == id);
        }
    }
}