using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProductionActivity;

namespace ServiceManagerApi.Controllers.Production
{
    public class ProActivityDetailsController : BaeApiController<ProActivityDetailsController>
    {
        private readonly EnpDbContext _context;

        public ProActivityDetailsController(EnpDbContext context)
        {
            _context = context;
        }

        [HttpGet("tenant/{tenantId}")]
        public Task<List<ProActivityDetail>> GetProActivityDetails(string tenantId)
        {
            var proActivityDetails = _context.ProActivityDetails
                .Where(leav => leav.TenantId == tenantId)
                /*.Select(h => new ProActivityDetail
                {
                    Id = h.Id,
                    Name = h.Name,
                    Code = h.Code,
                    ActivityId = h.ActivityId,
                    TenantId = h.TenantId,
                    Activity = new ProductionActivity
                    {
                        Id = h.Activity.Id,
                        Name = h.Activity.Name,
                        Code = h.Activity.Code
                    }
                })*/
                .ToListAsync();
            return proActivityDetails;
        }

        // GET: api/ProActivityDetails/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProActivityDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var proActivityDetail = await _context.ProActivityDetails.FindAsync(id);
            if (proActivityDetail == null)
            {
                return NotFound();
            }

            return Ok(proActivityDetail);
        }

        // PUT: api/ProActivityDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutProActivityDetail(int id, ProActivityDetail proActivityDetail)
        {
            if (id != proActivityDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(proActivityDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProActivityDetailExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/ProActivityDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(ProActivityDetail), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(ProActivityDetailsPostDto proActivityDetailsPostDto)
        {
            ProActivityDetail proActivityDetail = _mapper.Map<ProActivityDetail>(proActivityDetailsPostDto);
            if (IsProActivityDetailExistsDto(proActivityDetailsPostDto))
            {
                return Conflict();
            }

            _context.ProActivityDetails.Add(proActivityDetail);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = proActivityDetail.Id }, proActivityDetail);
        }

        // DELETE: api/ProActivityDetails/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProActivityDetail(int id)
        {
            var proActivityDetail = await _context.ProActivityDetails.FindAsync(id);
            if (proActivityDetail == null)
            {
                return NotFound();
            }

            _context.ProActivityDetails.Remove(proActivityDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProActivityDetailExists(int id)
        {
            return _context.ProActivityDetails.Any(e => e.Id == id);
        }

        private bool IsProActivityDetailExistsDto(ProActivityDetailsPostDto detailsPostDto)
        {
            return _context.ProActivityDetails.Any(pa =>
                pa.Name.ToLower().Trim() == detailsPostDto.Name.ToLower().Trim() &&
                pa.TenantId.ToLower().Trim() == detailsPostDto.TenantId.ToLower().Trim() &&
                pa.Code.ToLower().Trim() == detailsPostDto.Code.ToLower().Trim() &&
                pa.ActivityId == detailsPostDto.ActivityId
            );
        }
    }
}