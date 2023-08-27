using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Controllers.Esms;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProDailyOverview;

namespace ServiceManagerApi.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProDailyOverviewController : BaeApiController<ProDailyOverviewController>
    {
        private readonly EnpDbContext _context;

        public ProDailyOverviewController(EnpDbContext context)
        {
            _context = context;
        }

        // GET: api/ProDailyOverview
        [HttpGet("tenant/{tenantId}")]
        public async Task<List<ProDailyOverview>> GetProDailyOverviews(string tenantId)
        {
            var proDailyOverview = await _context.ProDailyOverviews
                .Where(leav => leav.TenantId == tenantId)
                .ToListAsync();

            return proDailyOverview;
        }


        // GET: api/ProDailyOverview/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProDailyOverview), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProDailyOverview(int id)
        {
            var proDailyOverview = await _context.ProDailyOverviews.FindAsync(id);
            if (proDailyOverview == null)
            {
                return NotFound();
            }

            return Ok(proDailyOverview);
        }

        // PUT: api/ProDailyOverview/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutProDailyOverview(int id, ProDailyOverview proDailyOverview)
        {
            if (id != proDailyOverview.Id)
            {
                return BadRequest();
            }

            _context.Entry(proDailyOverview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProDailyOverviewExistsById(id))
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

        // POST: api/ProDailyOverview
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(ProDailyOverview), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostProDailyOverview(ProDailyOverviewDto proDailyOverviewDto)
        {
            ProDailyOverview proDailyOverview = _mapper.Map<ProDailyOverview>(proDailyOverviewDto);
            if (ProDailyOverviewExists(proDailyOverview))
            {
                return Conflict();
            }

            _context.ProDailyOverviews.Add(proDailyOverview);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProDailyOverview), new { id = proDailyOverview.Id }, proDailyOverview);
        }

        // DELETE: api/ProDailyOverview/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProDailyOverview(int id)
        {
            var proDailyOverview = await _context.ProDailyOverviews.FindAsync(id);
            if (proDailyOverview == null) return NotFound();
            _context.ProDailyOverviews.Remove(proDailyOverview);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProDailyOverviewExists(ProDailyOverview proDailyOverview)
        {
            return (_context.ProDailyOverviews?.Any(e =>
                e.OverviewDate == proDailyOverview.OverviewDate &&
                e.TenantId == proDailyOverview.TenantId &&
                e.NumberOfIncidents == proDailyOverview.NumberOfIncidents &&
                e.HrsLostToRain == proDailyOverview.HrsLostToRain &&
                e.RainfallMm == proDailyOverview.RainfallMm &&
                e.Remarks == proDailyOverview.Remarks
            )).GetValueOrDefault();
        }

        private bool ProDailyOverviewExistsById(int id)
        {
            return (_context.ProDailyOverviews?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}