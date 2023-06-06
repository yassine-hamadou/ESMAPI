using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Controllers.Esms;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.HaulerOperator;

namespace ServiceManagerApi.Controllers.Production
{
    public class HaulerOperatorController : BaeApiController<HaulerOperatorController>
    {
        private readonly EnpDbContext _context;

        public HaulerOperatorController(EnpDbContext context)
        {
            _context = context;
        }


        [HttpGet("tenant/{tenantId}")]
        public Task<List<HaulerOperator>> GetHaulerOperators(string tenantId)
        {
            var haulerOperators = _context.HaulerOperators.Where(leav => leav.TenantId == tenantId).ToListAsync();

            return haulerOperators;
        }


        // get by id
        [HttpGet("id")]
        [ProducesResponseType(typeof(HaulerOperator), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HaulerOperator>> GetById(int id)
        {
            var haulerOperator = await _context.HaulerOperators.FindAsync(id);
            if (haulerOperator == null)
            {
                return NotFound();
            }

            return haulerOperator;
        }

        // post groups
        [HttpPost]
        [ProducesResponseType(typeof(HaulerOperator), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(HaulerOperatorPostDto haulerOperatorPostDto)
        {
            HaulerOperator haulerOperator = _mapper.Map<HaulerOperator>(haulerOperatorPostDto);
            if (HaulerOperatorExists(haulerOperator.EmpCode))
            {
                return Conflict();
            }

            _context.HaulerOperators.Add(haulerOperator);
            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(GetById), new { id = haulerOperator.Id }, haulerOperator);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, HaulerOperator haulerOperator)
        {
            if (id != haulerOperator.Id)
            {
                return BadRequest();
            }


            _context.Entry(haulerOperator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HaulerOperatorExists(haulerOperator.EmpCode))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{empCode}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string empCode)
        {
            var haulerOperator = await _context.HaulerOperators.FindAsync(empCode);
            if (haulerOperator == null)
            {
                return NotFound();
            }

            _context.HaulerOperators.Remove(haulerOperator);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool HaulerOperatorExists(string empCode)
        {
            return _context.HaulerOperators.Any(e => e.EmpCode.ToLower().Trim() == empCode.ToLower().Trim());
        }
    }
}