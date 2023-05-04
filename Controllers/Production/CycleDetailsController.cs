using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.CycleDetails;

namespace ServiceManagerApi.Controllers.Production
{
  
    public class CycleDetailsController : BaeApiController<CycleDetailsController>
    {
        private readonly EnpDBContext _context;

        public CycleDetailsController(EnpDBContext context)
        {
            _context = context;
        }

        // GET: api/CycleDetails
        [HttpGet]
        [ProducesResponseType(typeof(CycleDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<CycleDetail>> Get()
        {
            return await _context.CycleDetails.ToListAsync();
        }

        // GET: api/CycleDetails/5
        [HttpGet("id")]
        [ProducesResponseType(typeof(CycleDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var cycleDetail = await _context.CycleDetails.FindAsync(id);
            if (cycleDetail == null)
            {
                return NotFound();
            }

            return Ok(cycleDetail);
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(CycleDetail), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(CycleDetailPostDto cycleDetailPostDto)
        {
            CycleDetail cycleDetail = _mapper.Map<CycleDetail>(cycleDetailPostDto);

            _context.CycleDetails.Add(cycleDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CycleDetailExists(cycleDetail.Id))
                {
                    return Conflict();
                }

                throw;
            }
            return CreatedAtAction(nameof(GetById), new { id = cycleDetail.Id }, cycleDetail);
        }
        
        // PUT: api/CycleDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, CycleDetail cycleDetail)
        {
            
            if (id != cycleDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(cycleDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CycleDetailExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/CycleDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       

        // DELETE: api/CycleDetails/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var cycleDetail = await _context.CycleDetails.FindAsync(id);
            if (cycleDetail == null) return NotFound();
            _context.CycleDetails.Remove(cycleDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CycleDetailExists(int id)
        {
            return _context.CycleDetails.Any(e => e.Id == id);
        }
        
    }
}
