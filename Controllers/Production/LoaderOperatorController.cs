using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.LoaderOperator;

namespace ServiceManagerApi.Controllers.Production
{
    public class LoaderOperatorController : BaeApiController<LoaderOperatorController>
    {
        private readonly EnpDBContext _context;
        public LoaderOperatorController(EnpDBContext context)
        {
            _context = context;
        }
        //get list
        [HttpGet]
        [ProducesResponseType(typeof(LoaderOperator), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<LoaderOperator>> Get()
        {
            return await _context.LoaderOperators.ToListAsync();
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
            _context.LoaderOperators.Add(loaderOperator);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoaderOperatorExists(loaderOperator.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
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
                if (!LoaderOperatorExists(id))
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

        private bool LoaderOperatorExists(int id)
        {
            return _context.LoaderOperators.Any(e => e.Id == id);
        }

    }
}
