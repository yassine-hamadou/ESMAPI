using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.LoaderOperator;

namespace ServiceManagerApi.Controllers.Production
{
    public class LoaderOperatorController : BaeApiController<LoaderOperatorController>
    {
        private readonly EnpDbContext _context;

        public LoaderOperatorController(EnpDbContext context)
        {
            _context = context;
        }


        [HttpGet("tenant/{tenantId}")]
        public Task<List<LoaderOperator>> GetPlannedOutputs(string tenantId)
        {
            var loaderOperators = _context.LoaderOperators.Where(leav => leav.TenantId == tenantId).ToListAsync();

            return loaderOperators;
        }

        // get by id
        [HttpGet("id")]
        [ProducesResponseType(typeof(LoaderOperator), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var loaderOperator = await _context.LoaderOperators.FindAsync(id);
            if (loaderOperator == null)
            {
                return NotFound();
            }

            return Ok(loaderOperator);
        }

        // post groups
        [HttpPost]
        [ProducesResponseType(typeof(LoaderOperator), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(LoaderOperatorPostDto loaderOperatorPostDto)
        {
            LoaderOperator loaderOperator = _mapper.Map<LoaderOperator>(loaderOperatorPostDto);
            if (LoaderOperatorExists(loaderOperator.EmpCode))
            {
                return Conflict();
            }

            _context.LoaderOperators.Add(loaderOperator);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = loaderOperator.Id }, loaderOperator);
        }

        // put groups
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, LoaderOperator loaderOperator)
        {
            if (id != loaderOperator.Id)
            {
                return BadRequest();
            }

            _context.Entry(loaderOperator).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaderOperatorExists(loaderOperator.EmpCode))
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var loaderOperator = await _context.LoaderOperators.FindAsync(id);
            if (loaderOperator == null)
            {
                return NotFound();
            }

            _context.LoaderOperators.Remove(loaderOperator);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool LoaderOperatorExists(string empCode)
        {
            return _context.LoaderOperators.Any(e => e.EmpCode.ToLower().Trim() == empCode.ToLower().Trim());
        }
    }
}