using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceManagerApi.Controllers.Esms;
using ServiceManagerApi.Data;
using ServiceManagerApi.Dtos.ProductionBlast;

namespace ServiceManagerApi.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionBlastController : BaeApiController<ProductionBlastController>
    {
        private readonly EnpDbContext _context;

        public ProductionBlastController(EnpDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductionBlast
        [HttpGet("tenant/{tenantId}")]
        public Task<List<ProBlast>> GetProBlasts(string tenantId)
        {
         var proBlasts = _context.ProBlasts.Where(leav => leav.TenantId == tenantId)
                .ToListAsync();
            return proBlasts;
        }

        // GET: api/ProductionBlast/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProBlast), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ProBlast>> GetById(int id)
        {
          var proBlast = await _context.ProBlasts.FindAsync(id);
    
                if (proBlast == null)
                {
                    return NotFound();
                }
    
                return Ok(proBlast);
        }

        // PUT: api/ProductionBlast/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutProBlast(int id, ProBlast proBlast)
        {
            if (id != proBlast.Id)
            {
                return BadRequest();
            }

            _context.Entry(proBlast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProBlastExists(id))
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

        // POST: api/ProductionBlast
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<ProBlast>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostProBlast(IEnumerable<ProductionBlastDto> productionBlastDtos)
        {
            try
            {
                var proBlasts = _mapper.Map<IEnumerable<ProBlast>>(productionBlastDtos);
                
                var validationResults = new List<ValidationResult>();
                foreach (var proBlast in proBlasts)
                {
                    var isValid = Validator.TryValidateObject(proBlast, new ValidationContext(proBlast), validationResults, true);
                    if (!isValid)
                    {
                        return BadRequest(validationResults);
                    }
                }
                
                _context.ProBlasts.AddRange(proBlasts);
                await _context.SaveChangesAsync();
                
                var createIds = proBlasts.Select(x => x.Id).ToList();
                return CreatedAtAction(nameof(GetById), new {ids =  createIds}, proBlasts);
            }
            catch (DbUpdateException e)
            {
                throw new ApplicationException("Error creating Blast(s).", e);
            }
        }

        // DELETE: api/ProductionBlast/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProBlast(int id)
        {
            if (_context.ProBlasts == null)
            {
                return NotFound();
            }
            var proBlast = await _context.ProBlasts.FindAsync(id);
            if (proBlast == null)
            {
                return NotFound();
            }

            _context.ProBlasts.Remove(proBlast);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProBlastExists(int id)
        {
            return (_context.ProBlasts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
